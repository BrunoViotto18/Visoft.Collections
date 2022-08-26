using BenchmarkDotNet.Attributes;

namespace Benchmarks;

using MyLINQ;


[MemoryDiagnoser]
public class ClearBenchmark
{
    public MyList<int> MyList { get; set; }
    public List<int> NormalList { get; set; }

    [Params(10000, 100000, 1000000)]
    public int ListSize { get; set; }


    [IterationSetup]
    public void IterationSetup()
    {
        NormalList = new();
        for (int i = 0; i < ListSize; i++)
            NormalList.Add(i);
        MyList = new(NormalList.ToArray());
    }


    [Benchmark]
    public void MyListClear()
    {
        MyList.Clear();
    }

    [Benchmark]
    public void NormalListClear()
    {
        NormalList.Clear();
    }
}
