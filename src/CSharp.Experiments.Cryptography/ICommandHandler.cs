namespace CSharp.Experiments.Cryptography;

public interface ICommandHandler
{
    Task HandleAsync(CancellationToken cancellationToken);
}
