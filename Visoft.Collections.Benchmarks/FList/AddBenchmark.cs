using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class AddBenchmark : FListBenchmark
{
    [IterationCleanup]
    public void IterationCleanup()
    {
        FastList = new FList<int>();
        NormalList = new List<int>();
    }

    
    [Benchmark]
    public void NormalListAdd()
    {
        for (var i = 0; i < ListSize; i++)
            NormalList.Add(i);
    }
    
    [Benchmark]
    public void FastListAdd()
    {
        for (var i = 0; i < ListSize; i++)
            FastList.Add(i);
    }
}
