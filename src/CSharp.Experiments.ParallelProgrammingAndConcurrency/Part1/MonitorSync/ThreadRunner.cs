using System.Diagnostics;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.MonitorSync;

public class ThreadRunner
{
    private readonly int threadsNumber;
    private readonly Dictionary<int, Thread> threads = new();
    private readonly Decrementer decrementer;

    public ThreadRunner(Decrementer decrementer, int threadsNumber)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(threadsNumber);

        this.decrementer = decrementer;
        this.threadsNumber = threadsNumber;
    }

    public void Run()
    {
        for (var i = 0; i < this.threadsNumber; i++)
        {
            var newThread = new Thread(() => this.decrementer.Decrement());
            this.threads.Add(newThread.ManagedThreadId, newThread);
            Thread.Sleep(10);
            newThread.Start();
        }

        foreach (var thread in this.threads.Values)
        {
            thread.Join();
        }

        Debug.WriteLine("All threads finished.");
    }
}
