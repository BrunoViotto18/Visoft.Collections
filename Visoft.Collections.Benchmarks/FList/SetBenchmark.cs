using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class SetBenchmark : FListBenchmark
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
    public void NormalListSet()
    {
        int value = 0;
        for (var i = 0; i < ListSize; i++)
            NormalList[i] = value;
    }

    [Benchmark]
    public void FastListSet()
    {
        int value = 0;
        for (var i = 0; i < ListSize; i++)
            FastList[i] = value;
    }
}
