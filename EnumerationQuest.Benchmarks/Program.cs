using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using EnumerationQuest;

BenchmarkRunner.Run<Test>();

Console.ReadLine();

[MemoryDiagnoser]
public class Test
{
    private IEnumerable<int> _data = Array.Empty<int>();

    [Params(10, 10_000, 10_000_000)]
    public int DataSize;

    [GlobalSetup]
    public void Setup()
    {
        var r = new Random(42);
        _data = Enumerable.Range(0, DataSize)
                          .Select(_ => r.Next(-100, 100))
                          .ToArray()
                          .Select(v =>
                           {
                               Thread.Sleep(0);
                               return v;
                           });
    }

    [Benchmark]
    public (int p, int q, int r) EnumerationQuestSolution() => EnumerationQuestSolution(_data);

    [Benchmark]
    public (int p, int q, int r) ForeachSolution() => ForeachSolution(_data);

    [Benchmark]
    public (int p, int q, int r) LookUpSolution() => LookUpSolution(_data);

    [Benchmark]
    public (int p, int q, int r) MultipleEnumerationSolution() => MultipleEnumeration(_data);

    private static (int p, int q, int r) EnumerationQuestSolution(IEnumerable<int> t)
    {
        var (p, q, r) = t.GetCount(v => v < 0)
                         .AndCount(v => v == 0)
                         .AndCount(v => v > 0);

        return (p, q, r);
    }

    private static (int p, int q, int r) ForeachSolution(IEnumerable<int> t)
    {
        var p = 0;
        var q = 0;
        var r = 0;
        foreach (var value in t)
        {
            switch (value)
            {
                case < 0:
                    p++;
                    break;
                case 0:
                    q++;
                    break;
                case > 0:
                    r++;
                    break;
            }
        }

        return (p, q, r);
    }

    private static (int p, int q, int r) LookUpSolution(IEnumerable<int> t)
    {
        var lookUp = t.ToLookup(Math.Sign);
        var p = lookUp[-1].Count();
        var q = lookUp[0].Count();
        var r = lookUp[1].Count();
        return (p, q, r);
    }

    private static (int p, int q, int r) MultipleEnumeration(IEnumerable<int> t)
    {
        return (t.Count(v => v < 0), t.Count(v => v == 0), t.Count(v => v > 0));
    }
}