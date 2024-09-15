namespace CSharp.Experiments.Cryptography;

public interface IKeyGenerator
{
    Task<string> GenerateKeyAsync();
}