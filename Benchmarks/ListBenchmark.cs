using BenchmarkDotNet.Attributes;

namespace Benchmarks;

using MyLINQ;


public class ListBenchmark
{
    public MyList<int> MyList { get; set; }
    public List<int> NormalList { get; set; }

    [Params(1000, 10000, 100000, 1000000)]
    public int ListSize { get; set; }


    public ListBenchmark()
    {
        MyList = new();
        NormalList = new();
    }
}
