using CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter1.Synchronization.MonitorExamples;
using FluentAssertions;
using Xunit;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.UnitTests.Part1.Chapter1.Synchronization.MonitorExamples;

public class ThreadRunnerTests
{
    [Theory]
    [InlineData(10, 10, 0)]
    [InlineData(100, 100, 0)]
    [InlineData(1000, 100, 900)]
    public void Given_WhenRunDecrementer_ThenResultAsExpected(int number, int threadNumber, int expectedResult)
    {
        var decrementer = new Decrementer(number);
        var cut = new ThreadRunner();

        var action = () => cut.RunDecrementer(threadNumber, decrementer);
        action.Should().NotThrow();
        decrementer.GetValue().Should().Be(expectedResult);
    }

    [Fact]
    public void Given_WhenRunProducerConsumer_ThenResultAsExpected()
    {
        var producerConsumer = new ProducerConsumer();
        var cut = new ThreadRunner();

        var action = () => cut.RunProducerConsumer(producerConsumer);
        action.Should().NotThrow();
    }
}
