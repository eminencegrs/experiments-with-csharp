namespace CSharp.Experiments.Cryptography.Services;

internal class CommandProvider(IEnumerable<ICommand> commands) : ICommandProvider
{
    public ICommand? GetCommand(ConsoleKey key)
    {
        return commands.FirstOrDefault(command => command.CanExecute(key));
    }
}
