using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class IterationBenchmark : FListBenchmark
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
    public int NormalListForLoop()
    {
        int i = 0;
        for (var j = 0; j < NormalList.Count; j++)
            i += NormalList[j];

        return i;
    }

    [Benchmark]
    public int NormalListForeach()
    {
        int i = 0;
        foreach (var item in NormalList)
            i += item;

        return i;
    }
    
    [Benchmark]
    public int FastListForLoop()
    {
        int i = 0;
        for (var j = 0; j < FastList.Count; j++)
            i += FastList[j];
        
        return i;
    }
    
    [Benchmark]
    public int FastListForeach()
    {
        int i = 0;
        foreach (var item in FastList)
            i += item;
        
        return i;
    }
}
