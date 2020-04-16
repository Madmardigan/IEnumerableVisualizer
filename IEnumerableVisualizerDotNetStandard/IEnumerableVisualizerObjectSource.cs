using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

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
            DataTable results;

            if (target is Array array)
            {
                results = Serialize(array.Cast<object>());
            }
            else if (target is ArrayList arrayList)
            {
                results = Serialize(arrayList.Cast<object>());
            }
            else if (target is BitArray bitArray)
            {
                results = Serialize(bitArray.Cast<object>());
            }
            else if(target is BindingList<object> bindingList)
            {
                results = Serialize(bindingList);
            }
            else if (target is BlockingCollection<object> blockingCollection)
            {
                results = Serialize(blockingCollection);
            }
            else if (target is CollectionBase collectionBase)
            {
                results = Serialize(collectionBase.Cast<object>());
            }
            else if (target is ConcurrentBag<object> concurrentBag)
            {
                results = Serialize(concurrentBag);
            }
            else if (target is ConcurrentDictionary<object, object> concurrentDictionary)
            {
                results = Serialize(concurrentDictionary);
            }
            else if (target is ConcurrentQueue<object> concurrentQueue)
            {
                results = Serialize(concurrentQueue);
            }
            else if (target is ConcurrentStack<object> concurrentStack)
            {
                results = Serialize(concurrentStack);
            }
            else if (target is DataRow dataRow && dataRow.Table != null)
            {
                results = dataRow.Table.Clone();
                results.Rows.Add(dataRow.ItemArray);
            }
            else if (target is DataRowCollection dataRowCollection && dataRowCollection.Count > 0 && dataRowCollection[0].Table != null)
            {
                results = dataRowCollection[0].Table.Clone();
                dataRowCollection.Cast<DataRow>().ToList().ForEach(x => results.Rows.Add(x.ItemArray));
            }
            else if (target is Dictionary<object, object> dictionary1)
            {
                results = Serialize(dictionary1);
            }
            else if(target is Dictionary<object, object>.ValueCollection valueCollection)
            {
                results = Serialize(valueCollection);
            }
            else if (target is DictionaryBase dictionaryBase)
            {
                results = Serialize(dictionaryBase);
            }
            else if (target is LinkedList<object> linkedList)
            {
                results = Serialize(linkedList);
            }
            else if (target is List<object> list)
            {
                results = Serialize(list);
            }
            else if (target is ReadOnlyCollectionBase readOnlyCollectionBase)
            {
                results = Serialize(readOnlyCollectionBase.Cast<object>());
            }
            else if (target is SortedList<object, object> sortedList1)
            {
                results = Serialize(sortedList1);
            }
            else if (target is SortedList sortedList2)
            {
                results = Serialize(sortedList2);
            }
            else if (target is Stack<object> stack1)
            {
                results = Serialize(stack1);
            }
            else if (target is Stack stack2)
            {
                results = Serialize(stack2.Cast<object>());
            }
            else if (target is SortedSet<object> sortedSet)
            {
                results = Serialize(sortedSet);
            }
            else if (target is Queue<object> queue1)
            {
                results = Serialize(queue1);
            }
            else if (target is Queue queue2)
            {
                results = Serialize(queue2.Cast<object>());
            }
            else if (target is IDictionary dictionary2)
            {
                results = Serialize(dictionary2);
            }
            else if (target is IList<object> iList1)
            {
                results = Serialize(iList1);
            }
            else if (target is IList iList2)
            {
                results = Serialize(iList2.Cast<object>());
            }
            else if (target is ICollection<object> iCollection1)
            {
                results = Serialize(iCollection1);
            }
            else if (target is ICollection iCollection2)
            {
                results = Serialize(iCollection2.Cast<object>());
            }
            else if (target is IQueryable<object> iQueryable1)
            {
                results = Serialize(iQueryable1);
            }
            else if (target is IQueryable iQueryable2)
            {
                results = Serialize(iQueryable2.Cast<object>());
            }
            else if (target is IEnumerable<object> iEnumerable1)
            {
                results = Serialize(iEnumerable1);
            }
            else if (target is IEnumerable iEnumerable2)
            {
                results = Serialize(iEnumerable2.Cast<object>());
            }
            else
            {
                results = new DataTable();
            }

            results.Namespace = target.GetType().ToString();
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
                    results.Columns.Add(string.Format("[{0}]", column.ColumnName), column.DataType);
                }

                foreach (DataColumn column in dataTable2.Columns)
                {
                    results.Columns.Add(column.ColumnName, column.DataType);
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
            var isHeterogeneous = objects.Select(x => x.GetType()).Distinct().Count() > 1;

            if (isHeterogeneous)
            {
                result.Columns.Add(typeof(object).Name);

                for (int i = 0; i < objects.Length; i++)
                {
                    result.Rows.Add(objects[i]?.ToString());
                }
            }
            else
            {
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

                        if (type.IsPrimitive || type.IsValueType || type == typeof(string) || type == typeof(IntPtr))
                        {
                            result.Columns.Add(type.ToString(), GetColumnType(type));
                        }
                        else
                        {
                            for (int j = 0; j < fieldInfosLength; j++)
                            {
                                var fieldType = fieldInfos[j].FieldType;
                                result.Columns.Add(fieldInfos[j].Name, GetColumnType(fieldType));
                            }

                            for (int j = 0; j < propertyInfosLength; j++)
                            {
                                var propertyType = propertyInfos[j].PropertyType;
                                result.Columns.Add(propertyInfos[j].Name, GetColumnType(propertyType));
                            }
                        }

                        for (int i = 0; i < objects.Length; i++)
                        {
                            var values = new List<object>();

                            if (type.IsPrimitive || type.IsValueType || type == typeof(string))
                            {
                                var value = default(object);

                                try
                                {
                                    value = GetValue(type, objects[i]);
                                }
                                catch (Exception ex)
                                {
                                    value = ex.Message;
                                }

                                values.Add(value);
                            }
                            else
                            {
                                for (int j = 0; j < fieldInfosLength; j++)
                                {
                                    var value = default(object);

                                    try
                                    {
                                        value = GetValue(result.Columns[values.Count].DataType, fieldInfos[j].GetValue(objects[i]));
                                    }
                                    catch (Exception ex)
                                    {
                                        value = ex.Message;
                                    }

                                    values.Add(value);
                                }

                                for (int j = 0; j < propertyInfosLength; j++)
                                {
                                    var value = default(object);

                                    try
                                    {
                                        value = GetValue(result.Columns[values.Count].DataType, propertyInfos[j].GetValue(objects[i]));
                                    }
                                    catch (Exception ex)
                                    {
                                        value = ex.Message;
                                    }

                                    values.Add(value);
                                }
                            }

                            for (int j = 0; j < values.Count(); j++)
                            {
                                if(values[j] is string && result.Columns[j].DataType != typeof(string))
                                {
                                    result.Columns[j].DataType = typeof(string);
                                }
                            }

                            result.Rows.Add(values.ToArray());
                        }
                    }
                }
            }

            return result;
        }

        private object GetValue(Type type, object value)
        {
            object result;

            if (IsSerializable(type))
            {
                result = value;
            }
            else
            {
                result = value?.ToString();
            }

            return result;
        }

        private bool IsSerializable(Type type)
        {
            var result = false;

            if ((type is IXmlSerializable || type.IsPrimitive) && type != typeof(IntPtr))
            {
                result = true;
            }

            return result;
        }

        private Type GetColumnType(Type type)
        {
            var result = typeof(string);

            if (IsSerializable(type))
            {
                result = type;
            }

            return result;
        }
    }
}