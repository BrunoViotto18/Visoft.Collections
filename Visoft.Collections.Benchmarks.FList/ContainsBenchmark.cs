using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

using Visoft.Collections;


[MemoryDiagnoser]
public class ContainsBenchmark : FListBenchmark
{
    private int RandomNumber { get; set; }
    private bool RandomFlag { get; set; }


    [IterationSetup]
    public void IterationSetup()
    {
        for (int i = 0; i < ListSize; i++)
        {
            FastList.Add(i);
            NormalList.Add(i);
        }

        if (!RandomFlag)
            RandomNumber = new Random().Next(ListSize);
        RandomFlag = !RandomFlag;
    }

    [IterationCleanup]
    public void IterationCleanup()
    {
        FastList = new FList<int>();
        NormalList = new List<int>();
    }


    [Benchmark]
    public bool FastListContains()
    {
        return FastList.Contains(RandomNumber);
    }

    [Benchmark]
    public bool NormalListContains()
    {
        return NormalList.Contains(RandomNumber);
    }
}
