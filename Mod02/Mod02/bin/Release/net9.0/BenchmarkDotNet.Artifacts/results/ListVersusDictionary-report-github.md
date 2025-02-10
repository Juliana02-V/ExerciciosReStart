```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2894)
Intel Core i5-8400 CPU 2.80GHz (Coffee Lake), 1 CPU, 6 logical and 6 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2


```
| Method                 | Mean      | Error    | StdDev   |
|----------------------- |----------:|---------:|---------:|
| GetValueFromList       | 247.60 ns | 4.464 ns | 4.176 ns |
| GetValueFromDictionary |  18.52 ns | 0.149 ns | 0.117 ns |
| GetValueFromLinq       | 237.99 ns | 2.807 ns | 2.626 ns |
