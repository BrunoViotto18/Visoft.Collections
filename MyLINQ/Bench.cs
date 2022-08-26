using BenchmarkDotNet.Attributes;

namespace MyLINQ;


[MemoryDiagnoser]
public class Bench
{
    public int ListSize = 10000;
    public MyList<int> MyList { get; set; }
    public List<int> NormalList { get; set; }

    public Bench()
    {
        MyList = new();
        NormalList = new();
    }

    //[GlobalSetup]
    public void GlobalSetup()
    {

        NormalList = new();
        for (int i = 0; i < ListSize; i++)
            NormalList.Add(i);
        MyList = new(NormalList.ToArray());
    }

    [IterationSetup]
    public void IterationSetup()
    {
        NormalList = new();
        MyList = new();
    }


    /* Iteration */

    //[Benchmark]
    public void MyListIteraion()
    {
        int i;
        foreach (var item in MyList)
            i = item;
    }

    //[Benchmark]
    public void NormalListIteraion()
    {
        int i;
        foreach (var item in NormalList)
            i = item;
    }


    /* Add */

    [Benchmark]
    public void MyListAdd()
    {
        for (int i = 0; i < ListSize; i++)
            MyList.Add(i);
    }

    [Benchmark]
    public void NormalListAdd()
    {
        for (int i = 0; i < ListSize; i++)
            NormalList.Add(i);
    }
}
