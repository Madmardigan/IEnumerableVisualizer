using System;

public class CustomObject: IComparable
{
    public string Field1;
    public string Field2;
    public string Field3;
    public string Field4;
    public int Error { get { throw new Exception("test"); } }
    public string Property1 { get; set; }
    public string Property2 { get; set; }
    public string Property3 { get; set; }
    public string Property4 { get; set; }

    public int CompareTo(object obj)
    {
        return 1;
    }
}
