using BenchmarkDotNet.Attributes;

namespace Benchmarks;

using MyLINQ;


[MemoryDiagnoser]
public class ContainsBenchmark : ListBenchmark
{
    private int RandomNumber { get; set; }
    private bool RandomFlag { get; set; }


    [IterationSetup]
    public void IterationSetup()
    {
        for (int i = 0; i < ListSize; i++)
        {
            MyList.Add(i);
            NormalList.Add(i);
        }

        if (!RandomFlag)
            RandomNumber = new Random().Next(ListSize);
        RandomFlag = !RandomFlag;
    }

    [IterationCleanup]
    public void IterationCleanup()
    {
        MyList = new MyList<int>();
        NormalList = new List<int>();
    }


    [Benchmark]
    public bool MyListContains()
    {
        return MyList.Contains(RandomNumber);
    }

    [Benchmark]
    public bool NormalListContains()
    {
        return NormalList.Contains(RandomNumber);
    }
}
