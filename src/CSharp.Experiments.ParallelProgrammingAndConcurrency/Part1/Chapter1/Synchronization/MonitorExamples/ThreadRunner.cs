using System.Diagnostics;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter1.Synchronization.MonitorExamples;

public class ThreadRunner
{
    private readonly Dictionary<int, Thread> threads = new();

    public void RunDecrementer(int threadsNumber, Decrementer decrementer)
    {
        for (var i = 0; i < threadsNumber; i++)
        {
            var newThread = new Thread(decrementer.Decrement);
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

    public void RunProducerConsumer(ProducerConsumer producerConsumer)
    {
        var producer = new Thread(producerConsumer.Produce);
        producer.Start();

        using var cts = new CancellationTokenSource();
        var consumerThreads = new List<Thread>();
        for (int i = 0; i < 5; i++)
        {
            var consumer = new Thread(() => producerConsumer.Consume(cts.Token));
            consumerThreads.Add(consumer);
            consumer.Start();
        }

        producer.Join();

        cts.CancelAfter(TimeSpan.FromSeconds(10));

        foreach (var consumer in consumerThreads)
        {
            consumer.Join();
        }

        Debug.WriteLine("All threads finished.");
    }
}
