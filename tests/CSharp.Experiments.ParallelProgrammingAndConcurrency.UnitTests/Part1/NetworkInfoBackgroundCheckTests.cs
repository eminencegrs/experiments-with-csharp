using CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1;
using FluentAssertions;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.UnitTests.Part1;

public class NetworkInfoBackgroundCheckTests
{
    [Fact]
    public async Task GivenBackgroundCheck_WhenRun_ThenTaskIsCompleted()
    {
        var cut = new NetworkInfoBackgroundCheck();
        cut.Status.Should().Be(CheckStatus.Pending);
        var task = Task.Run(cut.Run);
        await Task.Delay(TimeSpan.FromSeconds(1));
        cut.Status.Should().Be(CheckStatus.Running);
        await Task.Delay(TimeSpan.FromSeconds(2));
        task.IsCompletedSuccessfully.Should().BeTrue();
        cut.Status.Should().Be(CheckStatus.Completed);
    }
}
