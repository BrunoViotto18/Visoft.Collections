``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.1889/21H2/November2021Update)
Intel Core i5-7500T CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT AVX2
  Job-BEGQSX : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|          Method | ListSize |       Mean |    Error |   StdDev | Allocated |
|---------------- |--------- |-----------:|---------:|---------:|----------:|
|     **MyListClear** |    **10000** | **1,136.7 ns** | **67.74 ns** | **197.6 ns** |     **544 B** |
| NormalListClear |    10000 |   208.5 ns | 45.59 ns | 130.1 ns |     480 B |
|     **MyListClear** |   **100000** | **1,380.5 ns** | **56.49 ns** | **154.6 ns** |     **544 B** |
| NormalListClear |   100000 |   321.3 ns | 50.00 ns | 142.6 ns |     480 B |
|     **MyListClear** |  **1000000** | **1,457.8 ns** | **92.05 ns** | **256.6 ns** |     **544 B** |
| NormalListClear |  1000000 |   547.7 ns | 71.56 ns | 197.1 ns |     480 B |
