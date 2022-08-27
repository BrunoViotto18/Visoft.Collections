using BenchmarkDotNet.Attributes;

namespace Benchmarks;

using MyLINQ;


[MemoryDiagnoser]
public class IterationBenchmark : ListBenchmark
{
    [GlobalSetup]
    public void GlobalSetup()
    {
        for (int i = 0; i < ListSize; i++)
        {
            MyList.Add(i);
            NormalList.Add(i);
        }
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
