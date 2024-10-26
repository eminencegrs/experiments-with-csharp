using CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter2;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.UnitTests.Part1.Chapter2;

public class ContinueWithExampleTests
{
    [Fact]
    public async Task Given_WhenRunSuccessfully_ThenNoExceptionThrown()
    {
        var cut = new ContinueWithExample();
        Task? actualResult = null;
        Func<Task> action = () => actualResult = cut.Run();

        using (new AssertionScope())
        {
            await action.Should().NotThrowAsync();
            actualResult.Should().NotBeNull();
            actualResult!.Status.Should().Be(TaskStatus.RanToCompletion);
        }
    }
}
