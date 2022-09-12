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
        NormalList.Add(-1);
    }
    
    [Benchmark]
    public void FastListAdd()
    {
        FastList.Add(-1);
    }
}
