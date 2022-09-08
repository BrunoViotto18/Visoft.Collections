using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class RemoveAtBenchmark : FListBenchmark
{
    [IterationSetup]
    public void IterationSetup()
    {
        NormalList = new List<int>();
        FastList = new FList<int>();

        for (int i = 0; i < ListSize; i++)
        {
            NormalList.Add(i);
            FastList.Add(i);
        }
    }
    
    
    [Benchmark]
    public void NormalListRemoveAtStart()
    {
        NormalList.RemoveAt(ListSize / 5);
    }

    [Benchmark]
    public void FastListRemoveAtStart()
    {
        FastList.RemoveAt(ListSize / 5);
    }
    
    [Benchmark]
    public void NormalListRemoveAtMiddle()
    {
        NormalList.RemoveAt(ListSize / 2);
    }

    [Benchmark]
    public void FastListRemoveAtMiddle()
    {
        FastList.RemoveAt(ListSize / 2);
    }
    
    [Benchmark]
    public void NormalListRemoveAtEnd()
    {
        NormalList.RemoveAt(ListSize * 4 / 5);
    }

    [Benchmark]
    public void FastListRemoveAtEnd()
    {
        FastList.RemoveAt(ListSize * 4 / 5);
    }
}
