using Microsoft.VisualStudio.DebuggerVisualizers;
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
        private int _page = 0;
        public const int PAGE_COUNT = 50;

        public override void GetData(object target, Stream outgoingData)
        {
            var results = default(DataTable);

            if (target is IEnumerable<object> objects)
            {
                results = GetDataTable(objects);
            }
            else if (target is IDictionary dictionary)
            {
                results = GetDataTable(dictionary);
            }

            base.GetData(results, outgoingData);
        }

        private DataTable GetDataTable(IEnumerable<object> objects)
        {
            var results = default(DataTable);

            if (objects != null)
            {
                results = GetSerializableObjects(objects.ToArray());
                _page++;
            }

            return results;
        }

        private DataTable GetDataTable(IDictionary dictionary)
        {
            var results = default(DataTable);

            if (dictionary != null)
            {
                var dataTable1 = GetSerializableObjects(dictionary.Keys.Cast<object>().ToArray());
                var dataTable2 = GetSerializableObjects(dictionary.Values.Cast<object>().ToArray());
                _page++;
                results = new DataTable();

                foreach (DataColumn column in dataTable1.Columns)
                {
                    results.Columns.Add(string.Format("Key.{0}", column.ColumnName));
                }

                foreach (DataColumn column in dataTable2.Columns)
                {
                    results.Columns.Add(string.Format("Value.{0}", column.ColumnName));
                }

                if(dataTable1.Rows.Count == dataTable2.Rows.Count)
                { 
                    for (int i = 0; i < dataTable1.Rows.Count; i++)
                    {
                        var values = dataTable1.Rows[i].ItemArray.ToList();
                        values.AddRange(dataTable2.Rows[i].ItemArray);
                        results.Rows.Add(values.ToArray());
                    }
                }
                else if(dataTable1.Rows.Count > 0)
                {
                    results.Rows.Add(dataTable1.Rows);
                }
                else if(dataTable2.Rows.Count > 0 )
                {
                    results.Rows.Add(dataTable2.Rows);
                }
            }

            return results;
        }

        private DataTable GetSerializableObjects(object[] objects)
        {
            var result = new DataTable();
            objects = objects.Skip(_page * PAGE_COUNT).Take(PAGE_COUNT).ToArray();

            var first = objects.FirstOrDefault();

            if (first != null)
            {
                var type = first.GetType();

                if (type != null)
                {
                    var propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                        .Where(x => x.CanRead && !x.GetIndexParameters().Any()).ToArray();

                    var fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                        .ToArray();

                    if (type.IsPrimitive || type.IsValueType || type == typeof(string))
                    {
                        result.Columns.Add(type.ToString());
                    }
                    else
                    {
                        if (propertyInfos != null)
                        {
                            for (int j = 0; j < propertyInfos.Length; j++)
                            {
                                result.Columns.Add(propertyInfos[j].Name);
                            }

                            for (int j = 0; j < fieldInfos.Length; j++)
                            {
                                result.Columns.Add(fieldInfos[j].Name);
                            }
                        }
                    }

                    for (int i = 0; i < objects.Length; i++)
                    {
                        if (type.IsPrimitive || type.IsValueType || type == typeof(string))
                        {
                            result.Rows.Add(objects[i]);
                        }
                        else
                        {
                            var values = new List<string>();

                            if (propertyInfos != null)
                            {
                                for (int j = 0; j < propertyInfos.Length; j++)
                                {
                                    string value = null;

                                    try
                                    {
                                        value = propertyInfos[j].GetValue(objects[i])?.ToString();
                                    }
                                    catch(Exception ex)
                                    {
                                        value = ex.Message;
                                    }

                                    values.Add(value);
                                }
                            }

                            if (fieldInfos != null)
                            {
                                for (int j = 0; j < fieldInfos.Length; j++)
                                {
                                    values.Add(fieldInfos[j].GetValue(objects[i])?.ToString());
                                }
                            }

                            result.Rows.Add(values.ToArray());
                        }
                    }
                }
            }

            return result;
        }
    }
}