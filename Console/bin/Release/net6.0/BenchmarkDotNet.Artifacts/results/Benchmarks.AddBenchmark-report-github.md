``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.856/21H2)
AMD Ryzen 5 5500U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.303
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  Job-IQXRWL : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|        Method | ListSize |         Mean |      Error |      StdDev |      Gen0 |      Gen1 |      Gen2 | Allocated |
|-------------- |--------- |-------------:|-----------:|------------:|----------:|----------:|----------:|----------:|
|     **MyListAdd** |    **10000** |     **8.100 μs** |  **0.0000 μs** |   **0.0000 μs** |         **-** |         **-** |         **-** |     **480 B** |
| NormalListAdd |    10000 |    30.850 μs |  0.3254 μs |   0.2541 μs |         - |         - |         - |  131848 B |
|     **MyListAdd** |   **100000** |    **80.725 μs** |  **0.0579 μs** |   **0.0452 μs** |         **-** |         **-** |         **-** |     **480 B** |
| NormalListAdd |   100000 |   445.209 μs |  8.8675 μs |  18.5097 μs |         - |         - |         - | 1049424 B |
|     **MyListAdd** |  **1000000** |   **809.300 μs** |  **2.2173 μs** |   **1.8516 μs** |         **-** |         **-** |         **-** |     **480 B** |
| NormalListAdd |  1000000 | 4,907.077 μs | 96.8385 μs | 188.8761 μs | 1000.0000 | 1000.0000 | 1000.0000 | 8389864 B |
