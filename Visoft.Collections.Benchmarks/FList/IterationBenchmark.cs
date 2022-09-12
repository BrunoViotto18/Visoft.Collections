﻿using System.Collections;
using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class IterationBenchmark : FListBenchmark
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
    public void NormalListForLoop()
    {
        int _ = 0;
        for (var i = 0; i < NormalList.Count; i++)
            _++;
    }

    [Benchmark]
    public void FastListForLoop()
    {
        int _ = 0;
        for (var i = 0; i < FastList.Count; i++)
            _++;
    }
    
    [Benchmark]
    public void NormalListForeach()
    {
        int _ = 0;
        foreach (var __ in NormalList)
            _++;
    }

    [Benchmark]
    public void FastListForeach()
    {
        int _ = 0;
        foreach (var __ in FastList)
            _++;
    }
}
