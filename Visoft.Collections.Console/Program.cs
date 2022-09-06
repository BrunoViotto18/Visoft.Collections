using BenchmarkDotNet.Running;

namespace Visoft.Collections.Console;

using Benchmarks.FList;

public static class Program
{
    static void Main()
    {
        int[] arr = new int[10];
        List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        list.CopyTo(arr);
        // BenchmarkRunner.Run<SetBenchmark>();
    }
}
