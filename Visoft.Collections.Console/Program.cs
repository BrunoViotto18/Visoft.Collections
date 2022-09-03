using System.Runtime.CompilerServices;
using BenchmarkDotNet.Running;

namespace Visoft.Collections.Console;

using Benchmarks.FList;

public static class Program
{
    static void Main()
    {
        List<int> list = new List<int>();
        list.Contains(10);
        BenchmarkRunner.Run<AddBenchmark>();
    }
}
