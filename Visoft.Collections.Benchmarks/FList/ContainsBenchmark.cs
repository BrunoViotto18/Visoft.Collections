using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class ContainsBenchmark : FListBenchmark
{
    [IterationSetup]
    public void IterationSetup()
    {
        FastList = new FList<int>();
        NormalList = new List<int>();
        
        for (int i = 0; i < ListSize; i++)
        {
            FastList.Add(i);
            NormalList.Add(i);
        }
    }
    
    
    [Benchmark]
    public bool NormalListContainsStart()
    {
        return NormalList.Contains(ListSize / 5);
    }
    
    [Benchmark]
    public bool FastListContainsStart()
    {
        return FastList.Contains(ListSize / 5);
    }

    [Benchmark]
    public bool NormalListContainsMiddle()
    {
        return NormalList.Contains(ListSize / 2);
    }
    
    [Benchmark]
    public bool FastListContainsMiddle()
    {
        return FastList.Contains(ListSize / 2);
    }
    
    [Benchmark]
    public bool NormalListContainsEnd()
    {
        return NormalList.Contains(ListSize * 4 / 5);
    }
    
    [Benchmark]
    public bool FastListContainsEnd()
    {
        return FastList.Contains(ListSize * 4 / 5);
    }
}
