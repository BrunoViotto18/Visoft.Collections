``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.856/21H2)
AMD Ryzen 5 5500U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.303
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


```
|              Method | ListSize |         Mean |      Error |     StdDev | Allocated |
|-------------------- |--------- |-------------:|-----------:|-----------:|----------:|
|     **MyListIteration** |    **10000** |    **37.792 μs** |  **0.2969 μs** |  **0.2632 μs** |      **40 B** |
| NormalListIteration |    10000 |     7.501 μs |  0.0353 μs |  0.0294 μs |         - |
|     **MyListIteration** |   **100000** |   **375.774 μs** |  **4.0459 μs** |  **3.3785 μs** |      **40 B** |
| NormalListIteration |   100000 |    99.958 μs |  0.5351 μs |  0.4744 μs |         - |
|     **MyListIteration** |  **1000000** | **3,753.557 μs** | **17.7448 μs** | **13.8540 μs** |      **42 B** |
| NormalListIteration |  1000000 | 1,037.958 μs |  5.3887 μs |  5.0406 μs |       1 B |
