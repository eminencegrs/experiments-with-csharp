using System.Collections.Concurrent;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Synchronization.MonitorExamples;

public class SimpleCalculator
{
    private readonly object syncLock = new();

    private readonly ConcurrentBag<int> processedNumbers = new();

    public int Double(int number)
    {
        var result = 0;
        var isLockTaken = false;

        try
        {
            System.Threading.Monitor.Enter(this.syncLock, ref isLockTaken);
            result = number * 2;
            this.processedNumbers.Add(number);
        }
        finally
        {
            if (isLockTaken)
            {
                System.Threading.Monitor.Exit(this.syncLock);
            }
        }

        return result;
    }

    public List<int> ProcessedNumbers => this.processedNumbers.ToList();
}
