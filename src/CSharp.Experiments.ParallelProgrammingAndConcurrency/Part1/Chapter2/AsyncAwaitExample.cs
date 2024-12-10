namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter2;

public class AsyncAwaitExample
{
    public async Task RunSuccessfully()
    {
        await DoFirstThing();
        await DoSecondThing();
    }

    public async Task RunWithFailure()
    {
        await DoThirdThing();
    }

    private static Task DoFirstThing()
    {
        try
        {
            Task.Delay(TimeSpan.FromSeconds(1));
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
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }
    }

    private static Task DoThirdThing()
    {
        try
        {
            Task.Delay(TimeSpan.FromSeconds(1));
            throw new InvalidOperationException();
        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }
    }
}