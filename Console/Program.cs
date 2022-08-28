using BenchmarkDotNet.Running;

using static System.Console;

namespace Console;

using Benchmarks;
using MyLINQ;


public static class Program
{
    static void Main()
    {
        BenchmarkRunner.Run<IterationBenchmark>();
    }
}
