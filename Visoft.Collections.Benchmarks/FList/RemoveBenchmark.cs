using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class RemoveBenchmark : FListBenchmark
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
    public void NormalListRemoveStart()
    {
        NormalList.Remove(ListSize / 5);
    }

    [Benchmark]
    public void FastListRemoveStart()
    {
        FastList.Remove(ListSize / 5);
    }

    [Benchmark]
    public void NormalListRemoveMiddle()
    {
        NormalList.Remove(ListSize / 2);
    }

    [Benchmark]
    public void FastListRemoveMiddle()
    {
        FastList.Remove(ListSize / 2);
    }

    [Benchmark]
    public void NormalListRemoveEnd()
    {
        NormalList.Remove(ListSize * 4 / 5);
    }

    [Benchmark]
    public void FastListRemoveEnd()
    {
        FastList.Remove(ListSize * 4 / 5);
    }
}
