using CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter1.Synchronization;
using FluentAssertions;
using Xunit;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.UnitTests.Part1.Chapter1.Synchronization;

public class InterlockedExampleTests
{
    [Fact]
    public void Given_WhenRun_ThenTaskIsCompleted()
    {
        var cut = new InterlockedExample();
        var action = () => cut.Run();
        action.Should().NotThrow();
        cut.GetValue().Should().Be(byte.MinValue);
    }
}
