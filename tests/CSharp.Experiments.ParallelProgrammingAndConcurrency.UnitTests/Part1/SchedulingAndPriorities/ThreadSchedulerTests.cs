using CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.SchedulingAndPriorities;
using FluentAssertions;
using FluentAssertions.Execution;
using Shouldly;
using Xunit;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.UnitTests.Part1.SchedulingAndPriorities;

public class ThreadSchedulerTests
{
    [Fact]
    public void Run_WhenCalled_LogsThreadCompletionWithPriority()
    {
        var cut = new ThreadScheduler();
        List<(long, long)>? actualResult = null;

        var action = () => actualResult = cut.GetResults();

        using (new AssertionScope())
        {
            action.Should().NotThrow();
            actualResult.Should().NotBeNull();
            actualResult.Should().NotBeEmpty();
            actualResult!.Count.ShouldBe(3);
        }
    }
}
