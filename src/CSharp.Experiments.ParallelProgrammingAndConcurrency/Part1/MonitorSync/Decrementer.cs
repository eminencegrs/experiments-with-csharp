using System.Diagnostics;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.MonitorSync;

public class Decrementer
{
    private int value;

    public Decrementer(int value)
    {
        this.value = value;
    }

    public int GetValue() => value;

    public void Decrement()
    {
        Monitor.Enter(this);
        try
        {
            Debug.WriteLine($"Thread {Environment.CurrentManagedThreadId} acquired the lock. IsEntered: {Monitor.IsEntered(this)}.");
            this.value--;
            Debug.WriteLine($"Thread {Environment.CurrentManagedThreadId} decremented value to {this.value}.");
        }
        finally
        {
            Monitor.Exit(this);
            Debug.WriteLine($"Thread {Environment.CurrentManagedThreadId} released the lock. IsEntered: {Monitor.IsEntered(this)}.");
        }
    }
}
