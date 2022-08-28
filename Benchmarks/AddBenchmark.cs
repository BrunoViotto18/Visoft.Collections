using BenchmarkDotNet.Attributes;

namespace Benchmarks;

using MyLINQ;


[MemoryDiagnoser]
public class AddBenchmark : ListBenchmark
{
    [IterationCleanup]
    public void IterationCleanup()
    {
        MyList = new MyList<int>();
        NormalList = new List<int>();
    }


    [Benchmark]
    public void MyListAdd()
    {
        for (var i = 0; i < ListSize; i++)
            MyList.Add(i);
    }

    [Benchmark]
    public void NormalListAdd()
    {
        for (var i = 0; i < ListSize; i++)
            NormalList.Add(i);
    }
}
