using System.Security.Cryptography;
using CSharp.Experiments.Cryptography.Services.Models;

namespace CSharp.Experiments.Cryptography.Services;

internal class EncryptionService : IEncryptionService
{
    public string Encrypt(string plaintext, string base64Key)
    {
        var encryptionKey = Convert.FromBase64String(base64Key);
        byte[] ciphertextBytes;
        using var aes = Aes.Create();
        var encryptor = aes.CreateEncryptor(encryptionKey, aes.IV);
        using var memoryStream = new MemoryStream();
        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        {
            using (var streamWriter = new StreamWriter(cryptoStream))
            {
                streamWriter.Write(plaintext);
                    
            }
        }

        ciphertextBytes = memoryStream.ToArray();

        return new AesCiphertext(aes.IV, ciphertextBytes).ToString();
    }

    public string Decrypt(string ciphertext, string base64Key)
    {
        var encryptionKey = Convert.FromBase64String(base64Key);
        var cbcCiphertext = AesCiphertext.FromBase64String(ciphertext);
        using var aes = Aes.Create();
        using var decryptor = aes.CreateDecryptor(encryptionKey, cbcCiphertext.IV);
        using var memoryStream = new MemoryStream(cbcCiphertext.CiphertextBytes);
        using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        using var streamReader = new StreamReader(cryptoStream);
        return streamReader.ReadToEnd();
    }
}
