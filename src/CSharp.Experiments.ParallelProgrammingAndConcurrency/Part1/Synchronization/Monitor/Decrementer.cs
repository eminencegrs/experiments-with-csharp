using System.Diagnostics;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Synchronization.Monitor;

public class Decrementer
{
    private int value;

    public Decrementer(int value)
    {
        this.value = value;
    }

    public int GetValue() => this.value;

    public void Decrement()
    {
        System.Threading.Monitor.Enter(this);
        try
        {
            Debug.WriteLine($"Thread {Environment.CurrentManagedThreadId} acquired the lock. IsEntered: {System.Threading.Monitor.IsEntered(this)}.");
            this.value--;
            Debug.WriteLine($"Thread {Environment.CurrentManagedThreadId} decremented value to {this.value}.");
        }
        finally
        {
            System.Threading.Monitor.Exit(this);
            Debug.WriteLine($"Thread {Environment.CurrentManagedThreadId} released the lock. IsEntered: {System.Threading.Monitor.IsEntered(this)}.");
        }
    }
}
