using BenchmarkDotNet.Attributes;

namespace Benchmarks;

using MyLINQ;


[MemoryDiagnoser]
public class AddBenchmark : ListBenchmark
{
    [IterationCleanup]
    public void IterationCleanup()
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
