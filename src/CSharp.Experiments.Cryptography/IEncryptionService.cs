namespace CSharp.Experiments.Cryptography;

public interface IEncryptionService
{
    string Encrypt(string plainText, string base64Key);
    string Decrypt(string cypherText, string base64Key);
}
