using System.Diagnostics;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter1.Synchronization.MonitorExamples;

public class Decrementer
{
    private readonly object syncLock = new();
    private int value;

    public Decrementer(int value)
    {
        this.value = value;
    }

    public int GetValue() => this.value;

    public void Decrement()
    {
        Monitor.Enter(this.syncLock);

        try
        {
            Debug.WriteLine($"Thread {Environment.CurrentManagedThreadId} acquired the lock. IsEntered: {Monitor.IsEntered(this)}.");
            this.value--;
            Debug.WriteLine($"Thread {Environment.CurrentManagedThreadId} decremented value to {this.value}.");
        }
        finally
        {
            Monitor.Exit(this.syncLock);
            Debug.WriteLine($"Thread {Environment.CurrentManagedThreadId} released the lock. IsEntered: {Monitor.IsEntered(this)}.");
        }
    }
}
