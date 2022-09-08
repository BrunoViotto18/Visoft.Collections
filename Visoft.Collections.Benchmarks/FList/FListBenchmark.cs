using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

using Collections.Benchmarks;

[BenchmarkRun]
[MemoryDiagnoser]
[RankColumn]
public abstract class FListBenchmark
{
    protected FList<int> FastList { get; set; }
    protected List<int> NormalList { get; set; }

    [Params(10000, 100000, 1000000)]
    public int ListSize { get; set; }


    protected FListBenchmark()
    {
        FastList = new FList<int>();
        NormalList = new List<int>();
    }
}
