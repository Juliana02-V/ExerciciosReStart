```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2894)
Intel Core i5-8400 CPU 2.80GHz (Coffee Lake), 1 CPU, 6 logical and 6 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2


```
| Method | Mean     | Error    | StdDev   |
|------- |---------:|---------:|---------:|
| Sha256 | 25.84 μs | 0.323 μs | 0.286 μs |
| Md5    | 18.56 μs | 0.238 μs | 0.222 μs |
