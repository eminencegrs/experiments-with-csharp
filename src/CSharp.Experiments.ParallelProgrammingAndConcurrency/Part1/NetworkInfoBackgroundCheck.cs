using System.Diagnostics;
using System.Net.NetworkInformation;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1;

public class NetworkInfoBackgroundCheck
{
    private readonly ReaderWriterLockSlim syncLock = new();
    private CheckStatus status;

    public NetworkInfoBackgroundCheck()
    {
        this.Status = CheckStatus.Pending;
    }

    public CheckStatus Status
    {
        get
        {
            this.syncLock.EnterReadLock();
            try
            {
                return this.status;
            }
            finally
            {
                this.syncLock.ExitReadLock();
            }
        }

        private set
        {
            this.syncLock.EnterWriteLock();
            try
            {
                this.status = value;
            }
            finally
            {
                this.syncLock.ExitWriteLock();
            }
        }
    }

    public void Run()
    {
        this.Status = CheckStatus.Running;

        Debug.WriteLine($"{nameof(NetworkInfoBackgroundCheck)}: STARTED.");

        var backgroundThread = new Thread(DoBackgroundWork)
        {
            IsBackground = true
        };

        backgroundThread.Start();

        for (var i = 0; i < 10; i++)
        {
            Debug.WriteLine("The main thread is working...");
            Thread.Sleep(100);
        }

        Debug.WriteLine($"{nameof(NetworkInfoBackgroundCheck)}: FINISHED.");

        this.Status = CheckStatus.Completed;
    }

    private void DoBackgroundWork()
    {
        try
        {
            for (var i = 0; i < 10; i++)
            {
                Debug.WriteLine("Checking network status...");
                var status = NetworkInterface.GetIsNetworkAvailable() ? "OK" : "Fail";
                Debug.WriteLine($"Network status: {status}");

                Thread.Sleep(200);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception occured in background thread: {ex.Message}");
        }
    }
}

public enum CheckStatus
{
    Pending,
    Running,
    Completed
}
