namespace CSharp.Experiments.Cryptography;

public interface ICommandProvider
{
    ICommand? GetCommand(ConsoleKey key);
}
