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
        var value = ListSize / 2;
        NormalList[value] = value;
    }

    [Benchmark]
    public void FastListSet()
    {
        var value = ListSize / 2;
        FastList[value] = value;
    }
}
