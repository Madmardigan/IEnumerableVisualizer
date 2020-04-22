using System;

public class CustomObject: IComparable
{
    public string Field1;
    public int Field2;
    public int? Field3;
    public object[][] Field4;
    public int Error { get { throw new Exception("test"); } }
    public string Property1 { get; set; }
    public int Property2 { get; set; }
    public int? Property3 { get; set; }
    public object[][] Property4 { get; set; }

    public int CompareTo(object obj)
    {
        return 1;
    }
}
