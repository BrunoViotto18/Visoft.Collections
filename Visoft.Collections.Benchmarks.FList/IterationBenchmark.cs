using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;


[MemoryDiagnoser]
public class IterationBenchmark : FListBenchmark
{
    [GlobalSetup]
    public void GlobalSetup()
    {
        for (var i = 0; i < ListSize; i++)
        {
            FastList.Add(i);
            NormalList.Add(i);
        }
    }


    [Benchmark]
    public int FastListIteration()
    {
        int i = 0;
        foreach (var item in FastList)
            i += item;
        
        return i;
    }

    [Benchmark]
    public int NormalListIteration()
    {
        int i = 0;
        foreach (var item in NormalList)
            i += item;

        return i;
    }
}
