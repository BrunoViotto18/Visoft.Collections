using BenchmarkDotNet.Running;

using static System.Console;

namespace Console;

using Benchmarks;
using MyLINQ;


public static class Program
{
    static void Main()
    {
        List<int> lines = new List<int>() { 1, 2, 3, 4 };
        lines.Insert(-1, -1);
        //BenchmarkRunner.Run<IterationBenchmark>();
    }
}
