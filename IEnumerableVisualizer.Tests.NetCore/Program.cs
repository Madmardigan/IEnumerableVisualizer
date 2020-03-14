using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace IEnumerableVisualizer.Tests.NetCore
{
    /// <summary>
    /// This is a .NET Core application.
    /// </summary>
    class Program
    {
        private const int COUNT = 50;

        static void Main(string[] args)
        {
            var list = new List<CustomObject>();

            for (int i = 1; i <= COUNT; i++)
            {
                list.Add(GetCustomObject(i));
            }

            var dictionary = new Dictionary<string, CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                dictionary.Add(i.ToString(), list[i]);
            };

            var list2 = new List<CustomObjectNoFields>();

            for (int i = 1; i <= COUNT; i++)
            {
                list2.Add(new CustomObjectNoFields()
                {
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property2 = i
                });
            }

            var list3 = new List<CustomObjectNoProperties>();

            for (int i = 1; i <= COUNT; i++)
            {
                list3.Add(new CustomObjectNoProperties()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = i
                });
            }

            var list4 = new List<CustomObjectNoPropertiesOrFields>();

            for (int i = 1; i <= COUNT; i++)
            {
                list4.Add(new CustomObjectNoPropertiesOrFields());
            }

            var dictionary2 = new Dictionary<string, string>();

            for (int i = 0; i < COUNT; i++)
            {
                dictionary2.Add(i.ToString(), i.ToString());
            };

            var array = new CustomObject[COUNT];

            for (int i = 0; i < COUNT; i++)
            {
                array[i] = GetCustomObject(i);
            }

            var arrayList = new ArrayList();

            for (int i = 0; i <= COUNT; i++)
            {
                arrayList.Add(GetCustomObject(i));
            }

            var bitArray = new BitArray(new bool[] { false, false, false, true, true, false, true });
            var blockingCollection = new BlockingCollection<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                blockingCollection.Add(GetCustomObject(i));
            }

            var concurrentBag = new ConcurrentBag<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                concurrentBag.Add(GetCustomObject(i));
            }

            var concurrentDictionary = new ConcurrentDictionary<CustomObject, CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                concurrentDictionary.TryAdd(GetCustomObject(i), GetCustomObject(i));
            }

            var concurrentQueue = new ConcurrentQueue<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                concurrentQueue.Enqueue(GetCustomObject(i));
            }

            var concurrentStack = new ConcurrentStack<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                concurrentStack.Push(GetCustomObject(i));
            }

            var linkedList = new LinkedList<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                linkedList.AddLast(GetCustomObject(i));
            }

            var stack1 = new Stack<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                stack1.Push(GetCustomObject(i));
            }

            var stack2 = new Stack();

            for (int i = 0; i <= COUNT; i++)
            {
                stack2.Push(GetCustomObject(i));
            }

            var sortedList1 = new SortedList();

            for (int i = 0; i <= COUNT; i++)
            {
                sortedList1.Add(i, GetCustomObject(i));
            }

            var sortedList2 = new SortedList<CustomObject, CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                sortedList2.Add(GetCustomObject(i), GetCustomObject(i));
            }

            var sortedSet = new SortedSet<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                sortedSet.Add(GetCustomObject(i));
            }
            
            var queue1 = new Queue();

            for (int i = 0; i <= COUNT; i++)
            {
                queue1.Enqueue(GetCustomObject(i));
            }

            var queue2 = new Queue<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                queue2.Enqueue(GetCustomObject(i));
            }

            var dataTable = new DataTable();
            dataTable.Columns.Add("Column1");
            dataTable.Columns.Add("Column2");
            dataTable.Rows.Add(1, 2);
            dataTable.Rows.Add(11, 22);
            var dataRow = dataTable.Rows[0];
            var twoDimentionalArray = new object[][] { new object[] { 1 } };
            arrayList.Add(1);

            Console.Write(dataRow);
            Console.WriteLine(list);
            Console.WriteLine(dictionary);
            Console.WriteLine(list2);
            Console.WriteLine(list3);
            Console.WriteLine(list4);
            Console.WriteLine(dictionary2);
            Console.WriteLine(array);
            Console.WriteLine(arrayList);
            Console.WriteLine(bitArray);
            Console.WriteLine(blockingCollection);
            Console.WriteLine(concurrentBag);
            Console.WriteLine(concurrentDictionary);
            Console.WriteLine(concurrentQueue);
            Console.WriteLine(concurrentStack);
            Console.WriteLine(linkedList);
            Console.WriteLine(stack1);
            Console.WriteLine(stack2);
            Console.WriteLine(sortedList1);
            Console.WriteLine(sortedList2);
            Console.WriteLine(sortedSet);
            Console.WriteLine(queue1);            
            Console.WriteLine(queue2);
            Console.WriteLine(twoDimentionalArray);
            Console.WriteLine(dataTable.Rows);
            
            //todo: test
            //var collectionBase = _ as CollectionBase;
            //Console.WriteLine(collectionBase);
            //var dictionaryBase = dictionary as DictionaryBase;
            //Console.WriteLine(dictionaryBase);
            //var readOnlyCollectionBase = new ReadOnlyCollectionBase();
            //Console.WriteLine(readOnlyCollectionBase);
        }

        public static  CustomObject GetCustomObject(int i)
        {
            return new CustomObject()
            {
                Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                Field2 = i,
                Field3 = i % 2 == 1 ? (int?)i : null,
                Field4 = null,
                Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                Property2 = i,
                Property3 = i % 2 == 1 ? (int?)i : null,
                Property4 = new object[][] { new object[] { i } }
        };
        }
    }
}
