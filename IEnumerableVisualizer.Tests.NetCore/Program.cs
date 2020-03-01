using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumerableVisualizer.Tests.NetCore
{
    /// <summary>
    /// This is a .NET Core application.
    /// </summary>
    class Program
    {
        private const int COUNT = 777;

        static void Main(string[] args)
        {
            var objects = new List<CustomObject>();

            for (int i = 1; i <= COUNT; i++)
            {
                objects.Add(new CustomObject()
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

            Console.WriteLine(objects);

            var dictionary = new Dictionary<string, CustomObject>();

            for (int i = 0; i < COUNT; i++)
            {
                dictionary.Add(i.ToString(), objects[i]);
            };

            Console.WriteLine(dictionary);

            var objects2 = new List<CustomObjectNoFields>();

            for (int i = 1; i <= COUNT; i++)
            {
                objects2.Add(new CustomObjectNoFields()
                {
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", i),
                });
            }

            Console.WriteLine(objects2);

            var objects3 = new List<CustomObjectNoProperties>();

            for (int i = 1; i <= COUNT; i++)
            {
                objects3.Add(new CustomObjectNoProperties()
                {
                    Field1 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Field2 = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", i),
                });
            }

            Console.WriteLine(objects3);

            var objects4 = new List<CustomObjectNoPropertiesOrFields>();

            for (int i = 1; i <= COUNT; i++)
            {
                objects4.Add(new CustomObjectNoPropertiesOrFields());
            }

            Console.WriteLine(objects4);

            var dictionary2 = new Dictionary<string, string>();

            for (int i = 0; i < COUNT; i++)
            {
                dictionary2.Add(i.ToString(), i.ToString());
            };

            Console.WriteLine(dictionary2);            
            byte[] byteArray = new byte[] { 0x01, 0x1e };
            Console.WriteLine(byteArray);

            var bitArray = new BitArray(new bool[] { false, false, false, true, true, false, true });
            Console.WriteLine(bitArray);
        }
    }

    class CustomObjectNoFields
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }

    class CustomObjectNoProperties
    {
        public string Field1;
        public string Field2;
    }

    class CustomObjectNoPropertiesOrFields
    {

    }
}
