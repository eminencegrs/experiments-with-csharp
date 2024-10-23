using System.Collections.Concurrent;
using System.Diagnostics;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.SchedulingAndPriorities;

public class ThreadScheduler
{
    public List<(long, long)> GetResults()
    {
        var results = new ConcurrentBag<(long, long)>();

        var calculators = new[]
        {
            new Calculator(1),
            new Calculator(2),
            new Calculator(3)
        };

        var threads = new Thread[calculators.Length];

        threads[0] = new Thread(() =>
        {
            var result = calculators[0].Calculate();
            results.Add(result);
        })
        {
            Name = "HighPriorityThread",
            Priority = ThreadPriority.Highest
        };

        threads[1] = new Thread(() =>
        {
            var result = calculators[1].Calculate();
            results.Add(result);
        })
        {
            Name = "NormalPriorityThread",
            Priority = ThreadPriority.Normal
        };

        threads[2] = new Thread(() =>
        {
            var result = calculators[2].Calculate();
            results.Add(result);
        })
        {
            Name = "LowPriorityThread",
            Priority = ThreadPriority.Lowest
        };

        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        Debug.WriteLine("All calculations are complete.");

        return results.ToList();
    }
}
