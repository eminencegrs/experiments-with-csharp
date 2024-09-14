namespace CSharp.Experiments.Cryptography;

public interface ICommand
{
    bool CanExecute(ConsoleKey key);
    Task ExecuteAsync();
}
