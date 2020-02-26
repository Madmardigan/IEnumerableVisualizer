﻿using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace IEnumerableVisualizerDotNetStandard
{

    /// <summary>
    /// debugee side
    /// </summary>
    public class IEnumerableVisualizerObjectSource : VisualizerObjectSource
    {
        private int _serializeIndex = 0;
        public const int SERIALIZE_COUNT = 50;

        public override void GetData(object target, Stream outgoingData)
        {
            var results = default(DataTable);

            if (target is IEnumerable<object> objects)
            {
                results = Serialize(objects);
            }
            else if (target is Array array)
            {
                results = Serialize(array.Cast<object>());
            }
            else if (target is IDictionary dictionary)
            {
                results = Serialize(dictionary);
            }

            base.GetData(results, outgoingData);
        }

        private DataTable Serialize(IEnumerable<object> objects)
        {
            var results = default(DataTable);

            if (objects != null)
            {
                results = Serialize(objects.ToArray());
                _serializeIndex++;
            }

            return results;
        }

        private DataTable Serialize(IDictionary dictionary)
        {
            var results = default(DataTable);

            if (dictionary != null)
            {
                var dataTable1 = Serialize(dictionary.Keys.Cast<object>().ToArray());
                var dataTable2 = Serialize(dictionary.Values.Cast<object>().ToArray());
                _serializeIndex++;
                results = new DataTable();

                foreach (DataColumn column in dataTable1.Columns)
                {
                    results.Columns.Add(string.Format("Key.{0}", column.ColumnName));
                }

                foreach (DataColumn column in dataTable2.Columns)
                {
                    results.Columns.Add(string.Format("Value.{0}", column.ColumnName));
                }

                var dataTable1Count = dataTable1.Rows.Count;
                var dataTable2Count = dataTable2.Rows.Count;

                if (dataTable1Count == dataTable2Count)
                {
                    for (int i = 0; i < dataTable1Count; i++)
                    {
                        var values = dataTable1.Rows[i].ItemArray.ToList();
                        values.AddRange(dataTable2.Rows[i].ItemArray);
                        results.Rows.Add(values.ToArray());
                    }
                }
                else if (dataTable1Count > 0)
                {
                    results.Rows.Add(dataTable1.Rows);
                }
                else if (dataTable2Count > 0)
                {
                    results.Rows.Add(dataTable2.Rows);
                }
            }

            return results;
        }

        public DataTable Serialize(object[] objects)
        {
            var result = new DataTable();
            objects = objects.Skip(_serializeIndex * SERIALIZE_COUNT).Take(SERIALIZE_COUNT).ToArray();
            var first = objects.FirstOrDefault();

            if (first != null)
            {
                var type = first.GetType();

                if (type != null)
                {
                    var propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                        .Where(x => x.CanRead && !x.GetIndexParameters().Any()).ToArray();

                    var propertyInfosLength = propertyInfos.Length;
                    var fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    var fieldInfosLength = fieldInfos.Length;

                    if (type.IsPrimitive || type.IsValueType || type == typeof(string))
                    {
                        result.Columns.Add(type.ToString());
                    }
                    else
                    {
                        for (int j = 0; j < fieldInfosLength; j++)
                        {
                            result.Columns.Add(fieldInfos[j].Name);
                        }

                        for (int j = 0; j < propertyInfosLength; j++)
                        {
                            result.Columns.Add(propertyInfos[j].Name);
                        }                        
                    }

                    for (int i = 0; i < objects.Length; i++)
                    {
                        var values = new List<string>();

                        if (type.IsPrimitive || type.IsValueType || type == typeof(string))
                        {
                            values.Add(objects[i]?.ToString());
                        }
                        else
                        {
                            for (int j = 0; j < fieldInfosLength; j++)
                            {
                                values.Add(fieldInfos[j].GetValue(objects[i])?.ToString());
                            }

                            for (int j = 0; j < propertyInfosLength; j++)
                            {
                                string value = null;

                                try
                                {
                                    value = propertyInfos[j].GetValue(objects[i])?.ToString();
                                }
                                catch (Exception ex)
                                {
                                    value = ex.Message;
                                }

                                values.Add(value);
                            }                           
                        }

                        result.Rows.Add(values.ToArray());
                    }
                }
            }

            return result;
        }
    }
}