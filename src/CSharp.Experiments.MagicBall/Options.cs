using CommandLine;

namespace CSharp.Experiments.MagicBall;

// ReSharper disable once ClassNeverInstantiated.Global
public class Options
{
    [Option('q', "question", Required = true, HelpText = "The question you want to ask the Magic Ball.")]
    public string Question { get; init; } = null!;
}
