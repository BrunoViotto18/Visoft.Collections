using BenchmarkDotNet.Running;

using static System.Console;

namespace Console;

using Benchmarks;
using MyLINQ;


public static class Program
{
    static void Main()
    {
        //MyList<int> myList = new MyList<int>();
        //for (int i = 0; i < 10000; i++)
        //    myList.Add(i);

        //List<int> list = new List<int>();
        //foreach (int i in myList)
        //    list.Add(myList[i]);

        //for(int i = 0; i < 100; i++)
        //{
        //    TesteMyList(myList);
        //    TesteList(list);
        //}

        //var myTime = TesteMyList(myList);
        //var time = TesteList(list);

        //WriteLine($"MyList: {myTime}");
        //WriteLine($"List: {time}");

        BenchmarkRunner.Run<IterationBenchmark>();
    }

    static long TesteMyList(MyList<int> myList)
    {
        long start = DateTime.Now.Ticks;
        foreach(var item in myList)
        {
            int i = item;
        }
        var end = DateTime.Now.Ticks;
        return end - start;
    }

    static long TesteList(List<int> List)
    {
        long start = DateTime.Now.Ticks;
        foreach (var item in List)
        {
            int i = item;
        }
        var end = DateTime.Now.Ticks;
        return end - start;
    }
}
