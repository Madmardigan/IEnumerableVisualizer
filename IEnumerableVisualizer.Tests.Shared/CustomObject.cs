using System;

namespace IEnumerableVisualizer.Tests.Shared
{
    public class CustomObject : CustomObjectBase, IComparable
    {
        new public string Field1;
        public int Field2;
        public int? Field3;
        public object[][] Field4;
        public int Error { get { throw new Exception("test"); } }
        public override string Property1 { get; set; }
        public int Property2 { get; set; }
        public int? Property3 { get; set; }
        public object[][] Property4 { get; set; }
        public int? Field5;
        public int? Field6;
        public int? Field7;
        public int? Field8;
        public int? Field9;
        public int? Field10;
        public int? Field11;
        public int? Field12;
        public int? Field13;
        public int? Field14;
        public int? Field15;
        public int? Field16;
        public int? Field17;
        public int? Field18;
        public int? Field19;
        public int? Field20;

        public int CompareTo(object obj)
        {
            return 1;
        }
        public static CustomObject Get(int i)
        {
            return new CustomObject()
            {
                Field1 = string.Format("Field {0}", i),
                Field2 = i,
                Field3 = i % 2 == 1 ? (int?)i : null,
                Field4 = null,
                Property1 = string.Format("Property {0}", i),
                Property2 = i,
                Property3 = i % 2 == 1 ? (int?)i : null,
                Property4 = new object[][] { new object[] { i } },
                Field5 = i,
                Field6 = i,
                Field7 = i,
                Field8 = i,
                Field9 = i,
                Field10 = i,
                Field12 = i,
                Field13 = i,
                Field14 = i,
                Field15 = i,
                Field16 = i,
                Field17 = i,
                Field18 = i,
                Field19 = i,
                Field20 = i
            };
        }

    }
}