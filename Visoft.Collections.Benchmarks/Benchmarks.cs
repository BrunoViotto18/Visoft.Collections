using BenchmarkDotNet.Running;
using System.Reflection;

namespace Visoft.Collections.Benchmarks;

using Visoft.Collections.Benchmarks.Exceptions;

public static class Benchmarks
{
    private static readonly Type BenchmarkType = typeof(BenchmarkRunner);
    private static readonly MethodInfo RunMethod = BenchmarkType.GetMethods()
        .First(method => method.Name == nameof(BenchmarkRunner.Run) && method.ContainsGenericParameters);
    
    public static void Run()
    {
        var types = Assembly.GetExecutingAssembly().ExportedTypes
            .Where(t => t.GetCustomAttribute<BenchmarkRunAttribute>() is not null && !t.IsAbstract).ToArray();

        Console.WriteLine($"Found benchmarks: {types.Length}");
        Task.Delay(2000);
        
        foreach (var type in types)
        {
            var genericRunMethod = RunMethod.MakeGenericMethod(type);
            genericRunMethod.Invoke(null, new object?[]{ null, null });
        }
    }

    public static void Run<T>()
    {
        if (typeof(T).GetCustomAttribute<BenchmarkRunAttribute>() is null)
            throw new TypeAttributeException<T>(nameof(BenchmarkRunAttribute));
        if (typeof(T).IsAbstract)
            throw new AbstractTypeException<T>();
        
        var genericRunMethod = RunMethod.MakeGenericMethod(typeof(T));
        genericRunMethod.Invoke(null, null);
    }
}
