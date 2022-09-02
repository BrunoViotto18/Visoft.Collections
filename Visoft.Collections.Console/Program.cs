using BenchmarkDotNet.Running;

using static System.Console;

namespace Visoft.Collections.Console;

using Collections.Benchmarks.FList;
using Visoft.Collections;

public static class Program
{
    static void Main()
    {
        BenchmarkRunner.Run<AddBenchmark>();
    }
}
