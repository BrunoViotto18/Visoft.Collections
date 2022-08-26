using BenchmarkDotNet.Running;
using static System.Console;

namespace MyLINQ;


public class Program
{
    static void Main()
    {
        BenchmarkRunner.Run<Bench>();
    }
}
