using CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter1.Synchronization.MutexExamples;
using FluentAssertions;
using Shouldly;
using Xunit;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.UnitTests.Part1.Chapter1.Synchronization.MutexExamples;

public class AggregatorTests
{
    [Fact]
    public void Given_WhenGetKeyValues_ThenResultAsExpected()
    {
        var expectedResult = new Dictionary<string, int>()
        {
            ["100"] = 115,
            ["200"] = 215,
            ["300"] = 315,
            ["400"] = 415,
            ["500"] = 515
        };

        using var cut = new Aggregator();
        IDictionary<string, int>? actualResult = null;
        var action = () => actualResult = cut.GetKeyValues();
        action.Should().NotThrow();
        actualResult.ShouldNotBeNull();
        actualResult.Should().BeEquivalentTo(expectedResult);
    }
}
