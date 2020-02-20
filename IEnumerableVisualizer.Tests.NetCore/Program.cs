using System;
using System.Collections.Generic;

namespace ConsoleAppWithList
{
    /// <summary>
    /// This is a .NET Core application.
    /// </summary>
    class Program
    {
        private const int COUNT = 100;

        static void Main(string[] args)
        {
            var objects = new List<CustomObject>();

            for (int i = 1; i <= COUNT; i++)
            {
                objects.Add(new CustomObject()
                {
                    Field = string.Format("Field {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property1 = string.Format("Property {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property2 = string.Format("Property {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property3 = string.Format("Property {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property4 = string.Format("Property {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", i),
                    Property5 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property6 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property7 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property8 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property9 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property11 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property12 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property13 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property14 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property15 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property16 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property17 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property18 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
                    Property19 = string.Format("Property {0}{0}{0}{0}{0}{0}", i),
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

        }
    }

    class CustomObject
    {
        public string Field;

        public int Error { get { throw new Exception("test"); } }
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
        public string Property4 { get; set; }
        public string Property5 { get; set; }
        public string Property6 { get; set; }
        public string Property7 { get; set; }
        public string Property8 { get; set; }
        public string Property9 { get; set; }
        public string Property11 { get; set; }
        public string Property12 { get; set; }
        public string Property13 { get; set; }
        public string Property14 { get; set; }
        public string Property15 { get; set; }
        public string Property16  {get; set; }
        public string Property17 { get; set; }
        public string Property18 { get; set; }
        public string Property19 { get; set; }
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
