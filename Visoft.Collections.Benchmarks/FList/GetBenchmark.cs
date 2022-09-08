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
        int _ = 0;
        for (var i = 0; i < ListSize; i++)
            _ = NormalList[i];
    }
    
    [Benchmark]
    public void FastListGet()
    {
        int _ = 0;
        for (var i = 0; i < ListSize; i++)
            _ = FastList[i];
    }
}
