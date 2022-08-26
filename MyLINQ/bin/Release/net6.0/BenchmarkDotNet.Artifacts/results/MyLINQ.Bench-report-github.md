``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 5500U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.303
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  Job-OLQMMX : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|        Method |      Mean |     Error |    StdDev | Allocated |
|-------------- |----------:|----------:|----------:|----------:|
|     MyListAdd |  8.193 μs | 0.1624 μs | 0.1439 μs |     480 B |
| NormalListAdd | 34.101 μs | 1.4685 μs | 3.8429 μs | 131,848 B |
