using BenchmarkDotNet.Attributes;

namespace Benchmarks;

using MyLINQ;


[MemoryDiagnoser]
public class ContainsBenchmark : ListBenchmark
{
    public int RandomNumber { get; set; }
    public bool RandomFlag { get; set; }


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
        MyList = new();
        NormalList = new();
    }


    [Benchmark]
    public void MyListContains()
    {
        MyList.Contains(RandomNumber);
    }

    [Benchmark]
    public void NormalListContains()
    {
        NormalList.Contains(RandomNumber);
    }
}
