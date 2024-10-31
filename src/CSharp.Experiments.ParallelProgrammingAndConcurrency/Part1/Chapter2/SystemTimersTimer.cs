using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter2;

// This timer will raise an 'Elapsed' event on a thread pool thread at the interval specified in the 'Interval' property.
// The mechanism can be stopped or started by using the bool 'Enabled' property.
// If you need the 'Elapsed' event to only fire once, the 'AutoReset' property can be set to 'false'.
public sealed class SystemTimersTimer : IDisposable
{
    private readonly ConcurrentBag<long> signalTimes = [];
    private System.Timers.Timer? timer;
    private bool disposed;

    public void StartTimer(uint interval)
    {
        if (this.timer == null)
        {
            this.Initialize(interval);
        }

        if (this.timer != null && !this.timer.Enabled)
        {
            this.timer.Enabled = true;
        }
    }

    public void StopTimer()
    {
        if (this.timer != null && this.timer.Enabled)
        {
            this.timer.Enabled = false;
        }
    }

    public IReadOnlyCollection<long> GetSignalTimes()
    {
        return new ReadOnlyCollection<long>(this.signalTimes.ToArray());
    }

    private void Initialize(uint interval)
    {
        this.timer = new System.Timers.Timer()
        {
            Interval = interval
        };

        this.timer.Elapsed += this.TimerElapsed;
    }

    private void TimerElapsed(object? sender, System.Timers.ElapsedEventArgs eventArgs)
    {
        Debug.WriteLine($"Timer Elapsed at {eventArgs.SignalTime}");
        this.signalTimes.Add(eventArgs.SignalTime.Ticks);
    }

    private void Dispose(bool disposing)
    {
        if (this.disposed)
        {
            return;
        }

        if (disposing)
        {
            if (this.timer != null)
            {
                this.timer.Stop();
                this.timer.Elapsed -= this.TimerElapsed;
                this.timer.Dispose();
                this.timer = null;
            }
        }

        this.disposed = true;
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }
}
