using BenchmarkDotNet.Attributes;

namespace Benchmarks;

using MyLINQ;


[MemoryDiagnoser]
public class ClearBenchmark : ListBenchmark
{
    [IterationSetup]
    public void IterationSetup()
    {
        for (int i = 0; i < ListSize; i++)
        {
            MyList.Add(i);
            NormalList.Add(i);
        }
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
