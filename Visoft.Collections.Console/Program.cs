using BenchmarkDotNet.Running;
using Microsoft.CodeAnalysis;
using static System.Console;

namespace Visoft.Collections.Console;

using Benchmarks;
using Benchmarks.FList;

public static class Program
{
    static void Main()
    {
        // Benchmarks.Run();
        BenchmarkRunner.Run<InsertBenchmark>();
    }
}
