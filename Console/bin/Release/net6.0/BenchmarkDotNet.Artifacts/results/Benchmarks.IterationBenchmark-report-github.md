``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.1889/21H2/November2021Update)
Intel Core i5-7500T CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT AVX2


```
|              Method | ListSize |      Mean |    Error |   StdDev | Allocated |
|-------------------- |--------- |----------:|---------:|---------:|----------:|
|     **MyListIteration** |    **10000** |  **50.92 μs** | **0.843 μs** | **0.789 μs** |      **48 B** |
| NormalListIteraiton |    10000 |  15.90 μs | 0.105 μs | 0.093 μs |         - |
|     **MyListIteration** |   **100000** | **515.13 μs** | **7.484 μs** | **7.001 μs** |      **48 B** |
|     MyListIteration |   100000 | 506.62 μs | 4.946 μs | 4.384 μs |      48 B |
| NormalListIteraiton |   100000 | 158.09 μs | 1.797 μs | 1.593 μs |         - |
| NormalListIteraiton |   100000 | 158.25 μs | 1.100 μs | 0.919 μs |         - |
