namespace CSharp.Experiments.Cryptography.Commands;

public class DecryptCommand(IEncryptionService encryptionService) : ICommand
{
    public bool CanExecute(ConsoleKey key) => key is ConsoleKey.D3 or ConsoleKey.NumPad3;

    public Task ExecuteAsync()
    {
        Console.WriteLine("\nEnter a ciphertext to decrypt:");
        var ciphertext = Console.ReadLine();

        Console.WriteLine("Enter the Base64-encoded (256-bit) key:");
        var base64Key = Console.ReadLine();

        var decryptedText = encryptionService.Decrypt(ciphertext, base64Key);
        Console.WriteLine($"Decrypted text: {decryptedText}");

        Console.WriteLine("DecryptCommand. Completed.");
        return Task.CompletedTask;
    }
}
