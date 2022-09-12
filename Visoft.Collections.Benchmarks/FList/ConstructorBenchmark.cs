using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class ConstructorBenchmark : FListBenchmark
{
    private int[] _array;

    [IterationSetup]
    public void IterationSetup()
    {
        NormalList = null;
        FastList = null;
        _array = Enumerable.Range(0, ListSize).ToArray();
    }

    [Benchmark]
    public void NormalListConstructor()
    {
        NormalList = new List<int>();
    }

    [Benchmark]
    public void FastListConstructor()
    {
        FastList = new FList<int>();
    }

    [Benchmark]
    public void NormalListConstructorWithParams()
    {
        NormalList = new List<int>(_array);
    }

    [Benchmark]
    public void FastListConstructorWithParams()
    {
        FastList = new FList<int>(_array);
    }
}
