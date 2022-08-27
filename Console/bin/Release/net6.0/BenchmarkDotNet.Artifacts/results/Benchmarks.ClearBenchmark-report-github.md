``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.856/21H2)
AMD Ryzen 5 5500U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.303
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  Job-KZBUSB : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|          Method | ListSize |        Mean |      Error |     StdDev |   Median | Allocated |
|---------------- |--------- |------------:|-----------:|-----------:|---------:|----------:|
|     **MyListClear** |    **10000** |   **100.00 ns** |   **0.000 ns** |   **0.000 ns** | **100.0 ns** |     **480 B** |
| NormalListClear |    10000 |    89.29 ns |  11.582 ns |  31.115 ns | 100.0 ns |     480 B |
|     **MyListClear** |   **100000** |   **200.00 ns** |  **43.794 ns** | **124.237 ns** | **200.0 ns** |     **480 B** |
| NormalListClear |   100000 |    88.46 ns |  12.457 ns |  32.155 ns | 100.0 ns |     480 B |
|     **MyListClear** |  **1000000** | **1,017.71 ns** | **181.668 ns** | **524.152 ns** | **800.0 ns** |     **480 B** |
| NormalListClear |  1000000 |   812.37 ns | 115.746 ns | 335.801 ns | 700.0 ns |     480 B |
