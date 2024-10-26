using System.Diagnostics;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter2;

public class ContinueWithExample
{
    public async Task Run()
    {
        await DoFirstThing().ContinueWith(_ => DoSecondThing());
    }

    private static Task DoFirstThing()
    {
        try
        {
            Task.Delay(TimeSpan.FromSeconds(1));
            Debug.WriteLine($"{nameof(DoFirstThing)} is working...");
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }
    }

    private static Task DoSecondThing()
    {
        try
        {
            Task.Delay(TimeSpan.FromSeconds(1));
            Debug.WriteLine($"{nameof(DoSecondThing)} is working...");
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }
    }
}
