namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter2;

public class ContinueWithExample
{
    public void Run()
    {
        DoFirstThing().ContinueWith(_ => DoSecondThing());
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
            Task.Delay(TimeSpan.FromSeconds(2));
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }
    }
}
