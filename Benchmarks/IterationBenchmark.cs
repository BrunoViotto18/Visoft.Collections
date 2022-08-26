using BenchmarkDotNet.Attributes;

namespace Benchmarks;

using MyLINQ;


[MemoryDiagnoser]
public class IterationBenchmark
{
    public MyList<int> MyList { get; set; }
    public List<int> NormalList { get; set; }

    [Params(10000, 100000, 1000000)]
    public int ListSize { get; set; }


    [GlobalSetup]
    public void GlobalSetup()
    {

        NormalList = new();
        for (int i = 0; i < ListSize; i++)
            NormalList.Add(i);
        MyList = new(NormalList.ToArray());
    }


    [Benchmark]
    public void MyListIteration()
    {
        int i;
        foreach (var item in MyList)
            i = item;
    }

    [Benchmark]
    public void NormalListIteraiton()
    {
        int i;
        foreach (var item in NormalList)
            i = item;
    }
}
