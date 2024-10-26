using CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter2;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.UnitTests.Part1.Chapter2;

public class AsyncAwaitExampleTests
{
    [Fact]
    public async Task Given_WhenRunSuccessfully_ThenNoExceptionThrown()
    {
        var cut = new AsyncAwaitExample();
        Task? actualResult = null;
        Func<Task> action = () => actualResult = cut.RunSuccessfully();

        using (new AssertionScope())
        {
            await action.Should().NotThrowAsync();
            actualResult.Should().NotBeNull();
            actualResult!.Status.Should().Be(TaskStatus.RanToCompletion);
        }
    }

    [Fact]
    public async Task Given_WhenRunWithFailure_ThenInvalidOperationExceptionThrown()
    {
        var cut = new AsyncAwaitExample();
        Task? actualResult = null;
        Func<Task> action = () => actualResult = cut.RunWithFailure();

        using (new AssertionScope())
        {
            await action.Should().ThrowAsync<InvalidOperationException>();
            actualResult.Should().NotBeNull();
            actualResult!.Status.Should().Be(TaskStatus.Faulted);
        }
    }
}
