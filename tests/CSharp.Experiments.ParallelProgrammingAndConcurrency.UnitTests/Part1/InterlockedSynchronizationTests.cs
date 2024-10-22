using CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1;
using FluentAssertions;
using Xunit;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.UnitTests.Part1;

public class InterlockedSynchronizationTests
{
    [Fact]
    public void Given_WhenRun_ThenTaskIsCompleted()
    {
        var cut = new InterlockedSynchronization();
        var action = () => cut.Run();
        action.Should().NotThrow();
        cut.GetValue().Should().Be(byte.MinValue);
    }
}
