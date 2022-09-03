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
        int count = 0;
        for (var i = 0; i < NormalList.Count; i++)
            count++;

        return count;
    }

    [Benchmark]
    public int NormalListForeach()
    {
        int count = 0;
        foreach (var _ in NormalList)
            count++;

        return count;
    }
    
    [Benchmark]
    public int FastListForLoop()
    {
        int count = 0;
        for (var i = 0; i < FastList.Count; i++)
            count++;
        
        return count;
    }
    
    [Benchmark]
    public int FastListForeach()
    {
        int count = 0;
        foreach (var _ in FastList)
            count++;
        
        return count;
    }
}
