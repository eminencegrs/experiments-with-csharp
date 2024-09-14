namespace CSharp.Experiments.Cryptography.Commands;

public class EncryptCommand(IEncryptionService encryptionService) : ICommand
{
    public bool CanExecute(ConsoleKey key)
    {
        return key is ConsoleKey.D1 or ConsoleKey.NumPad1;
    }

    public Task ExecuteAsync()
    {
        // TODO: add implementation.
        // Console.WriteLine("\nEnter plaintext to encrypt:");
        // var plaintext = Console.ReadLine();
        //
        // Console.WriteLine("Enter the base64-encoded key (256-bit key):");
        // var base64Key = Console.ReadLine();
        //
        // var encryptedText = encryptionService.Encrypt(plaintext, base64Key);
        // Console.WriteLine($"Encrypted text: {encryptedText}");

        Console.WriteLine("\nEncryptCommand. Completed.");
        return Task.CompletedTask;
    }
}
