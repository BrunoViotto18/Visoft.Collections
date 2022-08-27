``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.856/21H2)
AMD Ryzen 5 5500U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.303
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


```
|              Method | ListSize |           Mean |         Error |        StdDev |   Gen0 | Allocated |
|-------------------- |--------- |---------------:|--------------:|--------------:|-------:|----------:|
|     **MyListIteration** |    **10000** |       **8.198 ns** |     **0.1864 ns** |     **0.1831 ns** | **0.0229** |      **48 B** |
| NormalListIteraiton |    10000 |   7,472.525 ns |    12.7447 ns |    10.6424 ns |      - |         - |
|     **MyListIteration** |   **100000** |       **8.002 ns** |     **0.0665 ns** |     **0.0589 ns** | **0.0229** |      **48 B** |
| NormalListIteraiton |   100000 |  75,641.521 ns | 1,001.3344 ns |   936.6488 ns |      - |         - |
|     **MyListIteration** |  **1000000** |       **7.945 ns** |     **0.0320 ns** |     **0.0299 ns** | **0.0229** |      **48 B** |
| NormalListIteraiton |  1000000 | 748,315.956 ns | 4,386.1923 ns | 3,662.6692 ns |      - |         - |
