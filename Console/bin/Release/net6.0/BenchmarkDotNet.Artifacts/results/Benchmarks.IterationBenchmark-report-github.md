``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.856/21H2)
AMD Ryzen 5 5500U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.303
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


```
|              Method | ListSize |           Mean |         Error |        StdDev |   Gen0 | Allocated |
|-------------------- |--------- |---------------:|--------------:|--------------:|-------:|----------:|
|     **MyListIteration** |     **1000** |       **7.890 ns** |     **0.0337 ns** |     **0.0281 ns** | **0.0229** |      **48 B** |
| NormalListIteraiton |     1000 |     761.783 ns |     6.9745 ns |     6.5239 ns |      - |         - |
|     **MyListIteration** |    **10000** |       **7.981 ns** |     **0.1204 ns** |     **0.1126 ns** | **0.0229** |      **48 B** |
| NormalListIteraiton |    10000 |   7,492.296 ns |    30.6551 ns |    25.5984 ns |      - |         - |
|     **MyListIteration** |   **100000** |       **7.892 ns** |     **0.0489 ns** |     **0.0433 ns** | **0.0229** |      **48 B** |
| NormalListIteraiton |   100000 |  75,373.126 ns |   546.9737 ns |   511.6396 ns |      - |         - |
|     **MyListIteration** |  **1000000** |       **8.015 ns** |     **0.1829 ns** |     **0.1957 ns** | **0.0229** |      **48 B** |
| NormalListIteraiton |  1000000 | 748,615.290 ns | 1,478.9161 ns | 1,311.0206 ns |      - |       1 B |
