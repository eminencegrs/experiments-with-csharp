namespace CSharp.Experiments.Cryptography.Commands;

public class DecryptCommand(IEncryptionService encryptionService) : ICommand
{
    public bool CanExecute(ConsoleKey key)
    {
        return key is ConsoleKey.D2 or ConsoleKey.NumPad2;
    }

    public Task ExecuteAsync()
    {
        // TODO: add implementation.
        // Console.WriteLine("\nEnter ciphertext to decrypt:");
        // var ciphertext = Console.ReadLine();
        //
        // Console.WriteLine("Enter the base64-encoded key (256-bit key):");
        // var base64Key = Console.ReadLine();
        //
        // var decryptedText = encryptionService.Decrypt(ciphertext, base64Key);
        // Console.WriteLine($"Decrypted text: {decryptedText}");

        Console.WriteLine("\nDecryptCommand. Completed.");
        return Task.CompletedTask;
    }
}
