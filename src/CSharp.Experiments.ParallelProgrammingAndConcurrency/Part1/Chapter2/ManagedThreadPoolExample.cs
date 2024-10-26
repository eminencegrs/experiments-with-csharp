using System.Diagnostics;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter2;

public class ManagedThreadPoolExample
{
    // ThreadPool.QueueUserWorkItem:
    // There is no need to set 'IsBackground' to true, and we do not call 'Start()'.
    // The process will start either as soon as the item is queued on ThreadPool
    // or when the next ThreadPool becomes available.
    // One of the common .NET features that use ThreadPool is timers.
    public int? CountTo10()
    {
        int? result = null;
        var manualResetEvent = new ManualResetEvent(false);
        ThreadPool.QueueUserWorkItem(_ =>
        {
            result = DoWorkAndCount();
            manualResetEvent.Set();
        });

        manualResetEvent.WaitOne();

        return result;
    }

    private static int DoWorkAndCount()
    {
        int counter = 0;
        do
        {
            var isNetworkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            Debug.WriteLine($"Network is up: '{isNetworkUp}'.");
            Task.Delay(TimeSpan.FromMilliseconds(100));
            counter++;
        } while (counter < 10);

        return counter;
    }
}
