﻿using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class GetBenchmark : FListBenchmark
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
    public int NormalListGet()
    {
        int temp = 0;
        for (var i = 0; i < ListSize; i++)
            temp = NormalList[i];
        return temp;
    }
    
    [Benchmark]
    public int FastListGet()
    {
        int temp = 0;
        for (var i = 0; i < ListSize; i++)
            temp = FastList[i];
        return temp;
    }
}