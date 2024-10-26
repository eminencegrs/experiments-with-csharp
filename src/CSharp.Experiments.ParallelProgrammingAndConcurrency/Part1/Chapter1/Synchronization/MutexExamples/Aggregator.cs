using System.Collections.Concurrent;
using System.Diagnostics;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter1.Synchronization.MutexExamples;

public class Aggregator : IDisposable
{
    private readonly Mutex mutex = new();
    private readonly ConcurrentDictionary<string, int> counter = new();

    private bool disposed;

    public IDictionary<string, int> GetKeyValues()
    {
        var threads = new List<Thread>();
        for (int i = 100; i <= 500; i += 100)
        {
            Thread thread = new Thread(this.PrintNumbers)
            {
                Name = i.ToString(),
                IsBackground = true
            };

            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return this.counter.ToDictionary();
    }

    private void PrintNumbers()
    {
        this.mutex.WaitOne();

        var threadKey = Thread.CurrentThread.Name!;

        Debug.WriteLine($"The thread {threadKey} has entered the critical section.");

        for (int i = 1; i <= 5; i++)
        {
            this.counter.AddOrUpdate(threadKey, i, (k, v) => i + v);
            Debug.Write($"{i} ");
            Thread.Sleep(100);
        }

        var threadNumber = int.Parse(threadKey);
        this.counter.AddOrUpdate(threadKey, threadNumber, (k, v) => threadNumber + v);

        Debug.WriteLine($"\nThe thread {threadKey} is leaving the critical section.");

        this.mutex.ReleaseMutex();
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this.disposed)
        {
            return;
        }

        if (disposing)
        {
            this.mutex?.Dispose();
        }

        this.disposed = true;
    }

    ~Aggregator()
    {
        this.Dispose(false);
    }
}
