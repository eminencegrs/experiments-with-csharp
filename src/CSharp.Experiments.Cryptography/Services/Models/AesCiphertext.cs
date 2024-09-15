namespace CSharp.Experiments.Cryptography.Services.Models;

internal sealed class AesCiphertext(byte[] iv, byte[] ciphertextBytes)
{
    public byte[] IV => iv;

    public byte[] CiphertextBytes => ciphertextBytes;

    public override string ToString() =>
        Convert.ToBase64String(iv.Concat(ciphertextBytes).ToArray());

    public static AesCiphertext FromBase64String(string data)
    {
        var dataBytes = Convert.FromBase64String(data);
        return new AesCiphertext(dataBytes.Take(16).ToArray(), dataBytes.Skip(16).ToArray());
    }
}
