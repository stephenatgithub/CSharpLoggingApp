using BenchmarkDotNet.Running;
using LogBenchmark;


//LogBenchmarkTest t = new();

//t.LogWithoutIf();

//t.LogWithIf();



var summary = BenchmarkRunner.Run<LogBenchmarkTest>();