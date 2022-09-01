using BenchmarkDotNet.Running;

using static System.Console;

namespace Visoft.Collections.Console;

using Collections.Benchmarks.FList;
using Visoft.Collections;


public static class Program
{
    static void Main()
    {
        BenchmarkRunner.Run<IterationBenchmark>();
    }

    static long TesteMyList(FList<int> fList)
    {
        long start = DateTime.Now.Ticks;
        foreach(var item in fList)
        {
            int i = item;
        }
        var end = DateTime.Now.Ticks;
        return end - start;
    }

    static long TesteList(List<int> List)
    {
        long start = DateTime.Now.Ticks;
        foreach (var item in List)
        {
            int i = item;
        }
        var end = DateTime.Now.Ticks;
        return end - start;
    }
}
