using BenchmarkDotNet.Attributes;

namespace Benchmarks;


[MemoryDiagnoser]
public class IterationBenchmark : ListBenchmark
{
    [GlobalSetup]
    public void GlobalSetup()
    {
        for (var i = 0; i < ListSize; i++)
        {
            MyList.Add(i);
            NormalList.Add(i);
        }
    }


    [Benchmark]
    public int MyListIteration()
    {
        int i = 0;
        foreach (var item in MyList)
            i += item;
        
        return i;
    }

    [Benchmark]
    public int NormalListIteration()
    {
        int i = 0;
        foreach (var item in NormalList)
            i += item;

        return i;
    }
}
