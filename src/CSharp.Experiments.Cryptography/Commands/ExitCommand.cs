namespace CSharp.Experiments.Cryptography.Commands;

public class ExitCommand(CancellationTokenSource cts) : ICommand
{
    public bool CanExecute(ConsoleKey key) => key is ConsoleKey.X;

    public Task ExecuteAsync()
    {
        Console.WriteLine("\nExiting the application...");
        cts.Cancel();
        cts.Dispose();
        Console.WriteLine("ExitCommand. Completed.");
        return Task.CompletedTask;
    }
}
