using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class GetBenchmark : FListBenchmark
{
    [IterationSetup]
    public void IterationSetup()
    {
        NormalList = new List<int>();
        FastList = new FList<int>();
        
        for (var i = 0; i < ListSize; i++)
        {
            FastList.Add(i);
            NormalList.Add(i);
        }
    }
    
    
    [Benchmark]
    public void NormalListGet()
    {
        var _ = NormalList[ListSize / 2];
    }
    
    [Benchmark]
    public void FastListGet()
    {
        var _ = FastList[ListSize / 2];
    }
}
