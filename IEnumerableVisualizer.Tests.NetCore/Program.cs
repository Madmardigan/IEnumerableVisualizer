using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

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
                list.Add(new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                });
            }

            Console.WriteLine(list);

            var dictionary = new Dictionary<string, CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                dictionary.Add(i.ToString(), list[i]);
            };

            Console.WriteLine(dictionary);

            var list2 = new List<CustomObjectNoFields>();

            for (int i = 1; i <= COUNT; i++)
            {
                list2.Add(new CustomObjectNoFields()
                {
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", i),
                });
            }

            Console.WriteLine(list2);

            var list3 = new List<CustomObjectNoProperties>();

            for (int i = 1; i <= COUNT; i++)
            {
                list3.Add(new CustomObjectNoProperties()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", i),
                });
            }

            Console.WriteLine(list3);

            var list4 = new List<CustomObjectNoPropertiesOrFields>();

            for (int i = 1; i <= COUNT; i++)
            {
                list4.Add(new CustomObjectNoPropertiesOrFields());
            }

            Console.WriteLine(list4);

            var dictionary2 = new Dictionary<string, string>();

            for (int i = 0; i < COUNT; i++)
            {
                dictionary2.Add(i.ToString(), i.ToString());
            };

            Console.WriteLine(dictionary2);

            var array = new CustomObject[COUNT];

            for (int i = 0; i < COUNT; i++)
            {
                array[i] = new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                };
            }

            Console.WriteLine(array);

            var arrayList = new ArrayList();

            for (int i = 0; i <= COUNT; i++)
            {
                arrayList.Add(new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                });
            }

            Console.WriteLine(arrayList);
            var bitArray = new BitArray(new bool[] { false, false, false, true, true, false, true });
            Console.WriteLine(bitArray);

            var blockingCollection = new BlockingCollection<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                blockingCollection.Add(new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                });
            }

            Console.WriteLine(blockingCollection);

            var concurrentBag = new ConcurrentBag<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                concurrentBag.Add(new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                });
            }

            Console.WriteLine(concurrentBag);

            var concurrentDictionary = new ConcurrentDictionary<CustomObject, CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                concurrentDictionary.TryAdd(new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                }, new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                });
            }

            Console.WriteLine(concurrentDictionary);

            var concurrentQueue = new ConcurrentQueue<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                concurrentQueue.Enqueue(new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                });
            }

            Console.WriteLine(concurrentQueue);

            var concurrentStack = new ConcurrentStack<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                concurrentStack.Push(new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                });
            }

            Console.WriteLine(concurrentStack);

            Console.WriteLine(dictionary);

            Console.WriteLine(list);

            var linkedList = new LinkedList<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                linkedList.AddLast(new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                });
            }

            Console.WriteLine(linkedList);

            var stack1 = new Stack<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                stack1.Push(new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                });
            }

            Console.WriteLine(stack1);

            var stack2 = new Stack();

            for (int i = 0; i <= COUNT; i++)
            {
                stack2.Push(new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                });
            }

            Console.WriteLine(stack2);

            var sortedList1 = new SortedList();

            for (int i = 0; i <= COUNT; i++)
            {
                sortedList1.Add(i, new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                });
            }

            Console.WriteLine(sortedList1);

            var sortedList2 = new SortedList<CustomObject, CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                sortedList2.Add(new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                }, new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                });
            }


            Console.WriteLine(sortedList2);

            var sortedSet = new SortedSet<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                sortedSet.Add(new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                });
            }


            Console.WriteLine(sortedSet);

            var queue1 = new Queue();

            for (int i = 0; i <= COUNT; i++)
            {
                queue1.Enqueue(new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                });
            }

            Console.WriteLine(queue1);

            var queue2 = new Queue<CustomObject>();

            for (int i = 0; i <= COUNT; i++)
            {
                queue2.Enqueue(new CustomObject()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field3 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field4 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}", i)
                });
            }

            Console.WriteLine(queue2);

            //todo: test
            //var collectionBase = _ as CollectionBase;
            //Console.WriteLine(collectionBase);
            //var dictionaryBase = dictionary as DictionaryBase;
            //Console.WriteLine(dictionaryBase);
            //var readOnlyCollectionBase = new ReadOnlyCollectionBase();
            //Console.WriteLine(readOnlyCollectionBase);
        }
    }
}
