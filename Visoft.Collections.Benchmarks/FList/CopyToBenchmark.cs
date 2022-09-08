using BenchmarkDotNet.Attributes;

namespace Visoft.Collections.Benchmarks.FList;

public class CopyToBenchmark : FListBenchmark
{
    private int[] _array;
    
    [IterationSetup]
    public void IterationSetup()
    {
        NormalList = new List<int>();
        FastList = new FList<int>();

        for (var i = 0; i < ListSize; i++)
        {
            NormalList.Add(i);
            FastList.Add(i);
        }
        
        _array = new int[ListSize];
    }

    [Benchmark]
    public void NormalListCopyTo()
    {
        NormalList.CopyTo(_array);
    }
    
    [Benchmark]
    public void FastListCopyTo()
    {
        FastList.CopyTo(_array);
    }}
