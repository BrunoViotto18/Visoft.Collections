using BenchmarkDotNet.Attributes;

namespace Benchmarks;

using MyLINQ;


public class ListBenchmark
{
    protected MyList<int> MyList { get; set; }
    protected List<int> NormalList { get; set; }

    [Params(10000, 100000, 1000000)]
    public int ListSize { get; set; }


    protected ListBenchmark()
    {
        MyList = new MyList<int>();
        NormalList = new List<int>();
    }
}
