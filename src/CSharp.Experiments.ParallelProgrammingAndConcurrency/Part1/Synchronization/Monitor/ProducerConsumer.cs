using System.Diagnostics;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Synchronization.Monitor;

public class ProducerConsumer
{
    private readonly object syncLock = new();
    private readonly Queue<int> dataQueue = new();

    public void Produce()
    {
        for (int i = 0; i < 100; i++)
        {
            System.Threading.Monitor.Enter(this.syncLock);
            this.dataQueue.Enqueue(i);
            Debug.WriteLine($"Produced: {i}");
            System.Threading.Monitor.PulseAll(this.syncLock);
            System.Threading.Monitor.Exit(this.syncLock);
            Thread.Sleep(10);
        }
    }

    public void Consume(CancellationToken token)
    {
        while (token.IsCancellationRequested == false)
        {
            System.Threading.Monitor.Enter(this.syncLock);
            Debug.WriteLine($"Consumer {Environment.CurrentManagedThreadId}: Entered.");
            Debug.WriteLine($"Consumer {Environment.CurrentManagedThreadId}: Waiting...");
            System.Threading.Monitor.Wait(this.syncLock, TimeSpan.FromSeconds(1));

            if (token.IsCancellationRequested)
            {
                Debug.WriteLine(
                    $"Consumer {Environment.CurrentManagedThreadId}: Cancellation requested during wait.");
                System.Threading.Monitor.Exit(this.syncLock);
                Debug.WriteLine($"Consumer {Environment.CurrentManagedThreadId}: Monitor Exited.");
                return;
            }

            if (this.dataQueue.Count > 0)
            {
                var data = this.dataQueue.Dequeue();
                Debug.WriteLine($"Consumer {Environment.CurrentManagedThreadId} consumed: {data}");
            }

            System.Threading.Monitor.Exit(this.syncLock);
            Debug.WriteLine($"Consumer {Environment.CurrentManagedThreadId}: Monitor Exited.");
        }
    }
}
