namespace CSharp.Experiments.Cryptography.Commands;

public class EncryptCommand(IEncryptionService encryptionService) : ICommand
{
    public bool CanExecute(ConsoleKey key) => key is ConsoleKey.D2 or ConsoleKey.NumPad2;

    public Task ExecuteAsync()
    {
        Console.WriteLine("\nEnter a plaintext to encrypt:");
        var plaintext = Console.ReadLine();

        Console.WriteLine("Enter a base64-encoded key (256-bit key):");
        var base64Key = Console.ReadLine();

        var encryptedText = encryptionService.Encrypt(plaintext, base64Key);
        Console.WriteLine($"Encrypted text: {encryptedText}");

        Console.WriteLine("EncryptCommand. Completed.");
        return Task.CompletedTask;
    }
}
