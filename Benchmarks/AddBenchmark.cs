using BenchmarkDotNet.Attributes;

namespace Benchmarks;

using MyLINQ;


[MemoryDiagnoser]
public class AddBenchmark
{
    public MyList<int> MyList { get; set; }
    public List<int> NormalList { get; set; }

    [Params(10000, 100000, 1000000)]
    public int ListSize { get; set; }


    [IterationSetup]
    public void IterationSetup()
    {
        NormalList = new();
        MyList = new();
    }


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
