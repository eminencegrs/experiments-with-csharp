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

            
            Console.WriteLine("Available options:");
            Console.WriteLine("1. Encrypt text");
            Console.WriteLine("2. Decrypt text");
            Console.WriteLine("3. Exit");
            Console.Write("Please press the corresponding key (1/2/3): ");

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
