using Visoft.Collections.Benchmarks.FList;
using BenchmarkDotNet.Running;
using static System.Console;

namespace Visoft.Collections.Console;

using Benchmarks;

public static class Program
{
    static void Main()
    {
        Benchmarks.Run();
        // BenchmarkRunner.Run<AddBenchmark>();
    }
}
