using System.Security.Cryptography;

namespace CSharp.Experiments.Cryptography.Commands;

public class GenerateKeyCommand(IKeyGenerator keyGenerator) : ICommand
{
    public bool CanExecute(ConsoleKey key) => key is ConsoleKey.D1 or ConsoleKey.NumPad1;

    public async Task ExecuteAsync()
    {
        Console.WriteLine("\nCreating an AES 256-bit key");
        var base64Key = await keyGenerator.GenerateKeyAsync();
        Console.WriteLine("The AES key in Base64:");
        Console.WriteLine(base64Key);
        Console.WriteLine("GenerateKeyCommand. Completed.");
    }
}
