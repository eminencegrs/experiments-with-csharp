namespace CSharp.Experiments.Cryptography.Services;

internal class CommandHandler(ICommandProvider commandProvider) : ICommandHandler
{
    public async Task HandleAsync(CancellationToken cancellationToken)
    {
        Console.Clear();

        while (true)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Available options:");
            Console.WriteLine("Press `1` to generate a key");
            Console.WriteLine("Press `2` to encrypt the text");
            Console.WriteLine("Press `3` to decrypt the text");
            Console.WriteLine("Press `x` to exit");
            Console.Write("Please press the corresponding key (1/2/3/x): ");

            var key = Console.ReadKey(intercept: true).Key;
            Console.Write(key.ToString());

            var command = commandProvider.GetCommand(key);
            if (command != null)
            {
                await command.ExecuteAsync();
            }
            else
            {
                Console.WriteLine("\nInvalid option. Please try again.");
            }
        }
    }
}
