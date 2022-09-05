using BenchmarkDotNet.Running;

namespace Visoft.Collections.Console;

using Benchmarks.FList;

public static class Program
{
    static void Main()
    {
        BenchmarkRunner.Run<IterationBenchmark>();
    }
}
