``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.856/21H2)
AMD Ryzen 5 5500U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.303
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  Job-ULJRPE : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|             Method | ListSize |          Mean |         Error |         StdDev |       Median | Allocated |
|------------------- |--------- |--------------:|--------------:|---------------:|-------------:|----------:|
|     **MyListContains** |    **10000** |      **75.56 ns** |     **15.503 ns** |      **43.216 ns** |     **100.0 ns** |     **480 B** |
| NormalListContains |    10000 |   1,874.49 ns |    306.435 ns |     893.887 ns |   1,900.0 ns |     480 B |
|     **MyListContains** |   **100000** |     **100.00 ns** |      **0.000 ns** |       **0.000 ns** |     **100.0 ns** |     **480 B** |
| NormalListContains |   100000 |  18,663.27 ns |  3,827.333 ns |  11,164.509 ns |  17,650.0 ns |     480 B |
|     **MyListContains** |  **1000000** |     **532.65 ns** |    **101.811 ns** |     **296.987 ns** |     **500.0 ns** |     **480 B** |
| NormalListContains |  1000000 | 283,666.00 ns | 59,805.680 ns | 176,338.396 ns | 305,550.0 ns |     480 B |
