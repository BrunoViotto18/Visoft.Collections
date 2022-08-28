``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.856/21H2)
AMD Ryzen 5 5500U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.303
  [Host] : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


```
|          Method | ListSize | Mean | Error |
|---------------- |--------- |-----:|------:|
| MyListIteration |     1000 |   NA |    NA |

Benchmarks with issues:
  IterationBenchmark.MyListIteration: DefaultJob [ListSize=1000]
