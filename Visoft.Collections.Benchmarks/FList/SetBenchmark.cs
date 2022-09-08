using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class SetBenchmark : FListBenchmark
{
    [GlobalSetup]
    public void GlobalSetup()
    {
        for (var i = 0; i < ListSize; i++)
        {
            FastList.Add(i);
            NormalList.Add(i);
        }
    }
    
    
    [Benchmark]
    public void NormalListSet()
    {
        int temp = 0;
        for (var i = 0; i < ListSize; i++)
            NormalList[i] = temp;
    }

    [Benchmark]
    public void FastListSet()
    {
        int temp = 0;
        for (var i = 0; i < ListSize; i++)
            FastList[i] = temp;
    }
}
