using System.Diagnostics;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1;

public class InterlockedSynchronization
{
    private const int ThreadsNumber = 10;
    private readonly Dictionary<int, Thread> threads = new();
    private static int value = byte.MaxValue;

    public int GetValue() => value;

    public void Run()
    {
        for (var i = 0; i < ThreadsNumber; i++)
        {
            var newThread = new Thread(DoWork);
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

    private static void DoWork()
    {
        while (true)
        {
            if (Interlocked.CompareExchange(ref value, 0, 0) == 0)
            {
                Debug.WriteLine("Value has ALREADY reached zero.");
                break;
            }

            var currentValue = Interlocked.Decrement(ref value);
            if (currentValue >= 0)
            {
                Debug.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} decremented value to {currentValue}.");
            }

            if (currentValue == 0)
            {
                Debug.WriteLine("Value has JUST reached zero.");
                break;
            }

            if (currentValue < 0)
            {
                throw new InvalidOperationException("Invalid state.");
            }

            Thread.Sleep(100);
        }
    }
}
