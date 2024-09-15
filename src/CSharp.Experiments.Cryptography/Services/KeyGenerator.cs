using System.Security.Cryptography;

namespace CSharp.Experiments.Cryptography.Services;

public class KeyGenerator : IKeyGenerator
{
    public Task<string> GenerateKeyAsync()
    {
        using var aesAlgorithm = Aes.Create();
        aesAlgorithm.KeySize = 256;
        aesAlgorithm.GenerateKey();
        var base64Key = Convert.ToBase64String(aesAlgorithm.Key);
        return Task.FromResult(base64Key);
    }
}
