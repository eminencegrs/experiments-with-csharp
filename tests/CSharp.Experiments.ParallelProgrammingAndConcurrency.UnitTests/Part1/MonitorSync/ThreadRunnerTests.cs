using CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.MonitorSync;
using FluentAssertions;
using Xunit;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.UnitTests.Part1.MonitorSync;

public class ThreadRunnerTests
{
    [Theory]
    [InlineData(10, 10, 0)]
    [InlineData(100, 100, 0)]
    [InlineData(1000, 100, 900)]
    public void Given_WhenRun_ThenTaskIsCompleted(int number, int threadNumber, int expectedResult)
    {
        var decrementer = new Decrementer(number);
        var cut = new ThreadRunner(decrementer, threadNumber);

        var action = () => cut.Run();
        action.Should().NotThrow();
        decrementer.GetValue().Should().Be(expectedResult);
    }
}
