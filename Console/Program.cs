using BenchmarkDotNet.Running;

using static System.Console;

namespace Console;

using Benchmarks;
using MyLINQ;


public class Program
{
    static void Main()
    {
        BenchmarkRunner.Run<AddBenchmark>();
    }
}
