namespace CSharp.Experiments.Cryptography.Commands;

public class ExitCommand : ICommand
{
    private readonly CancellationTokenSource cancellationTokenSource;

    public ExitCommand(CancellationTokenSource cancellationTokenSource)
    {
        this.cancellationTokenSource = cancellationTokenSource;
    }

    public bool CanExecute(ConsoleKey key)
    {
        return key is ConsoleKey.D3 or ConsoleKey.NumPad3;
    }

    public Task ExecuteAsync()
    {
        Console.WriteLine("\nExiting the application...");

        this.cancellationTokenSource.Cancel();
        this.cancellationTokenSource.Dispose();

        return Task.CompletedTask;
    }
}
