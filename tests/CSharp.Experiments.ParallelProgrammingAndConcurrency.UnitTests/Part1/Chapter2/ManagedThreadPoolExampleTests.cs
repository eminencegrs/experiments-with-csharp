using CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter2;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.UnitTests.Part1.Chapter2;

public class ManagedThreadPoolExampleTests
{
    [Fact]
    public void Given_WhenRunSuccessfully_ThenNoExceptionThrown()
    {
        int? actualResult = null;
        var action = () => actualResult = new ManagedThreadPoolExample().CountTo10();
        
        using (new AssertionScope())
        {
            action.Should().NotThrow();
            actualResult.Should().NotBeNull();
            actualResult.Should().Be(10);
        }
    }
}
