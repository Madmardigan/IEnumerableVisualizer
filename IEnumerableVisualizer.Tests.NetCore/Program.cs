using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using IEnumerableVisualizer.Tests.Shared;

namespace IEnumerableVisualizer.Tests.NetCore
{
    /// <summary>
    /// This is a .NET Core application.
    /// </summary>
    class Program
    {
        private const int COUNT = 51;
        public static List<CustomObject> List { get; } = new List<CustomObject>();

        static void Main(string[] args)
        {
            var list = new List<CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                List.Add(CustomObject.Get(i));
                list.Add(CustomObject.Get(i));
            }

            var dictionary = new Dictionary<string, CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                dictionary.Add(i.ToString(), list[i]);
            };

            var list2 = new List<CustomObjectNoFields>();

            for (int i = 0; i < COUNT; i++)
            {
                list2.Add(new CustomObjectNoFields()
                {
                    Property1 = string.Format("Property {0}", i),
                    Property2 = i
                });
            }

            var list3 = new List<CustomObjectNoProperties>();

            for (int i = 0; i < COUNT; i++)
            {
                list3.Add(new CustomObjectNoProperties()
                {
                    Field1 = string.Format("Field {0}", i),
                    Field2 = i
                });
            }

            var list4 = new List<CustomObjectNoPropertiesOrFields>();

            for (int i = 0; i < COUNT; i++)
            {
                list4.Add(new CustomObjectNoPropertiesOrFields());
            }

            var dictionary2 = new Dictionary<CustomObject, CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                dictionary2.Add(CustomObject.Get(i), CustomObject.Get(i));
            };

            var array = new CustomObject[COUNT];

            for (int i = 0; i < COUNT; i++)
            {
                array[i] = CustomObject.Get(i);
            }

            var arrayList = new ArrayList();

            for (int i = 0; i < COUNT; i++)
            {
                arrayList.Add(CustomObject.Get(i));
            }

            var bitArray = new BitArray(new bool[] { false, false, false, true, true, false, true });
            var blockingCollection = new BlockingCollection<CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                blockingCollection.Add(CustomObject.Get(i));
            }

            var concurrentBag = new ConcurrentBag<CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                concurrentBag.Add(CustomObject.Get(i));
            }

            var concurrentDictionary = new ConcurrentDictionary<CustomObject, CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                concurrentDictionary.TryAdd(CustomObject.Get(i), CustomObject.Get(i));
            }

            var concurrentQueue = new ConcurrentQueue<CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                concurrentQueue.Enqueue(CustomObject.Get(i));
            }

            var concurrentStack = new ConcurrentStack<CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                concurrentStack.Push(CustomObject.Get(i));
            }

            var linkedList = new LinkedList<CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                linkedList.AddLast(CustomObject.Get(i));
            }

            var stack1 = new Stack<CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                stack1.Push(CustomObject.Get(i));
            }

            var stack2 = new Stack();

            for (int i = 0; i < COUNT; i++)
            {
                stack2.Push(CustomObject.Get(i));
            }

            var sortedList1 = new SortedList();

            for (int i = 0; i < COUNT; i++)
            {
                sortedList1.Add(i, CustomObject.Get(i));
            }

            var sortedList2 = new SortedList<CustomObject, CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                sortedList2.Add(CustomObject.Get(i), CustomObject.Get(i));
            }

            var sortedSet = new SortedSet<CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                sortedSet.Add(CustomObject.Get(i));
            }

            var queue1 = new Queue();

            for (int i = 0; i < COUNT; i++)
            {
                queue1.Enqueue(CustomObject.Get(i));
            }

            var queue2 = new Queue<CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                queue2.Enqueue(CustomObject.Get(i));
            }

            var dataTable = new DataTable();
            dataTable.Columns.Add("Column1");
            dataTable.Columns.Add("Column2");
            dataTable.Rows.Add(1, 2);
            dataTable.Rows.Add(11, 22);
            var dataRow = dataTable.Rows[0];
            var twoDimentionalArray = new object[][] { new object[] { 1, default(IntPtr) } };
            arrayList.Add(1);
            var bindingList = new BindingList<CustomObject>(list);
            var valueCollection = new Dictionary<string, CustomObject>.ValueCollection(dictionary);
            var form = new Form();
            form.Controls.Add(new System.Windows.Forms.TextBox());
            form.Controls.Add(new System.Windows.Forms.TextBox());
            var controlCollection = form.Controls;
            var oneDimentionalArray = new CustomObject[] { new CustomObject(), new CustomObject() };
            var hashSet = new HashSet<CustomObject>(list);
            var iList = bindingList as IList<CustomObject>;
            IEnumerable<object> iEnumerable = bindingList as IEnumerable<object>;
            var whereSelectListIterator = list.Where(x => x != null).Select(x => x);
            var whereSelectArrayIterator = array.Where(x => x != null).Select(x => x);
            var whereArrayIterator = array.Where(x => x != null);
            var whereEnumerableIterator = iEnumerable.Where(x => x != null);
            var whereListIterator = array.Where(x => x != null);
            var selectEnumerableIterator = iEnumerable.Select(x => x);
            var selectArrayIterator = array.Select(x => x);
            var selectListIterator = list.Select(x => x);
            var selectIListIterator = iList.Select(x => x);

            Console.WriteLine(selectIListIterator);
            Console.WriteLine(selectListIterator);
            Console.WriteLine(selectArrayIterator);
            Console.WriteLine(selectEnumerableIterator);
            Console.WriteLine(whereListIterator);
            Console.WriteLine(whereEnumerableIterator);
            Console.WriteLine(whereArrayIterator);
            Console.WriteLine(whereSelectArrayIterator);
            Console.WriteLine(whereSelectListIterator);
            Console.WriteLine(iEnumerable);
            Console.WriteLine(hashSet);
            Console.WriteLine(oneDimentionalArray);
            Console.WriteLine(controlCollection);
            Console.WriteLine(valueCollection);
            Console.WriteLine(bindingList);
            Console.WriteLine(dataRow);
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
        }
    }
}