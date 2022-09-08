using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class IndexOfBenchmark : FListBenchmark
{
    [IterationSetup]
    public void IterationSetup()
    {
        NormalList = new List<int>();
        FastList = new FList<int>();

        for (var i = 0; i < ListSize; i++)
        {
            NormalList.Add(i);
            FastList.Add(i);
        }
    }
    
    
    [Benchmark]
    public void NormalListIndexOfStart()
    {
        NormalList.IndexOf(ListSize / 5);
    }

    [Benchmark]
    public void FastListIndexOfStart()
    {
        FastList.IndexOf(ListSize / 5);
    }
    
    [Benchmark]
    public void NormalListIndexOfMiddle()
    {
        NormalList.IndexOf(ListSize / 2);
    }

    [Benchmark]
    public void FastListIndexOfMiddle()
    {
        FastList.IndexOf(ListSize / 2);
    }
    
    [Benchmark]
    public void NormalListIndexOfEnd()
    {
        NormalList.IndexOf(ListSize * 4 / 5);
    }

    [Benchmark]
    public void FastListIndexOfEnd()
    {
        FastList.IndexOf(ListSize * 4 / 5);
    }
}
