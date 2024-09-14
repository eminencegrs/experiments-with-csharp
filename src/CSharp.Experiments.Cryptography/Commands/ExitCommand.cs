namespace CSharp.Experiments.Cryptography.Commands;

public class ExitCommand(CancellationTokenSource cts) : ICommand
{
    public bool CanExecute(ConsoleKey key)
    {
        return key is ConsoleKey.D3 or ConsoleKey.NumPad3;
    }

    public Task ExecuteAsync()
    {
        Console.WriteLine("\nExiting the application...");

        cts.Cancel();
        cts.Dispose();

        return Task.CompletedTask;
    }
}
