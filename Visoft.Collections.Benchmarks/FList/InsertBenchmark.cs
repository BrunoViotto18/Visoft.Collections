using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class InsertBenchmark : FListBenchmark
{
    [IterationSetup]
    public void IterationSetup()
    {
        NormalList = new List<int>();
        FastList = new FList<int>();

        for (int i = 0; i < ListSize; i++)
        {
            NormalList.Add(i);
            FastList.Add(i);
        }
    }
    
    
    [Benchmark]
    public void NormalListInsertStart()
    {
        NormalList.Insert(ListSize / 5, -1);
    }

    [Benchmark]
    public void FastListInsertStart()
    {
        FastList.Insert(ListSize / 5, -1);
    }
    
    [Benchmark]
    public void NormalListInsertMiddle()
    {
        NormalList.Insert(ListSize / 2, -1);
    }

    [Benchmark]
    public void FastListInsertMiddle()
    {
        FastList.Insert(ListSize / 2, -1);
    }
    
    [Benchmark]
    public void NormalListInsertEnd()
    {
        NormalList.Insert(ListSize * 4 / 5, -1);
    }

    [Benchmark]
    public void FastListInsertEnd()
    {
        FastList.Insert(ListSize * 4 / 5, -1);
    }
}
