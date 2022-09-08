using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class ContainsBenchmark : FListBenchmark
{
    private int RandomNumber { get; set; }
    private bool RandomFlag { get; set; }


    [IterationSetup]
    public void IterationSetup()
    {
        FastList = new FList<int>();
        NormalList = new List<int>();
        
        for (int i = 0; i < ListSize; i++)
        {
            FastList.Add(i);
            NormalList.Add(i);
        }

        if (!RandomFlag)
            RandomNumber = new Random().Next(ListSize);
        RandomFlag = !RandomFlag;
    }
    

    [Benchmark]
    public bool NormalListContains()
    {
        return NormalList.Contains(RandomNumber);
    }
    
    [Benchmark]
    public bool FastListContains()
    {
        return FastList.Contains(RandomNumber);
    }
}
