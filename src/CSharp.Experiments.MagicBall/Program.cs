using CommandLine;
using CSharp.Experiments.MagicBall;

await Parser.Default
    .ParseArguments<Options>(args)
    .WithParsedAsync(options =>
    {
        Console.Clear();
        Console.WriteLine($"Question: {options.Question}");
        Console.WriteLine($"Answer: {Answers.GetAnswer()}");
        return Task.CompletedTask;
    });
