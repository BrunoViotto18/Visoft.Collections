``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.856/21H2)
AMD Ryzen 5 5500U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.303
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


```
|              Method | ListSize |           Mean |          Error |        StdDev |   Gen0 | Allocated |
|-------------------- |--------- |---------------:|---------------:|--------------:|-------:|----------:|
|     **MyListIteration** |    **10000** |       **8.519 ns** |      **0.1247 ns** |     **0.1166 ns** | **0.0229** |      **48 B** |
| NormalListIteration |    10000 |   8,176.289 ns |     54.6287 ns |    51.0997 ns |      - |         - |
|     **MyListIteration** |   **100000** |       **8.331 ns** |      **0.0600 ns** |     **0.0561 ns** | **0.0229** |      **48 B** |
| NormalListIteration |   100000 |  79,948.595 ns |  1,558.9101 ns | 1,301.7605 ns |      - |         - |
|     **MyListIteration** |  **1000000** |       **8.571 ns** |      **0.1784 ns** |     **0.1582 ns** | **0.0229** |      **48 B** |
| NormalListIteration |  1000000 | 807,759.540 ns | 10,201.8053 ns | 8,518.9694 ns |      - |         - |
