``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.1889/21H2/November2021Update)
Intel Core i5-7500T CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT AVX2


```
|              Method | ListSize |            Mean |         Error |        StdDev |   Gen0 | Allocated |
|-------------------- |--------- |----------------:|--------------:|--------------:|-------:|----------:|
|     **MyListIteration** |    **10000** |        **13.41 ns** |      **0.252 ns** |      **0.300 ns** | **0.0153** |      **48 B** |
| NormalListIteration |    10000 |    16,541.61 ns |     67.698 ns |     63.324 ns |      - |         - |
|     **MyListIteration** |   **100000** |        **13.06 ns** |      **0.296 ns** |      **0.277 ns** | **0.0153** |      **48 B** |
| NormalListIteration |   100000 |   165,382.38 ns |  1,600.590 ns |  1,497.193 ns |      - |         - |
|     **MyListIteration** |  **1000000** |        **12.93 ns** |      **0.275 ns** |      **0.452 ns** | **0.0153** |      **48 B** |
| NormalListIteration |  1000000 | 1,738,110.68 ns | 18,850.404 ns | 17,632.680 ns |      - |       1 B |
