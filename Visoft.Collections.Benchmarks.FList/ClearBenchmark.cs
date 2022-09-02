using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class ClearBenchmark : FListBenchmark
{
    [IterationSetup]
    public void IterationSetup()
    {
        for (var i = 0; i < ListSize; i++)
        {
            FastList.Add(i);
            NormalList.Add(i);
        }
    }


    [Benchmark]
    public void FastListClear()
    {
        FastList.Clear();
    }

    [Benchmark]
    public void NormalListClear()
    {
        NormalList.Clear();
    }
}
