using CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter1.Synchronization.MonitorExamples;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.UnitTests.Part1.Chapter1.Synchronization.MonitorExamples;

public class SimpleCalculatorTests
{
    [Fact]
    public void GivenNumber_WhenDouble_ThenResultAsExpected()
    {
        var cut = new SimpleCalculator();
        var result1 = 0;
        var result2 = 0;
        const int expectedResult1 = 20;
        const int expectedResult2 = 40;

        var thread1 = new Thread(() => result1 = cut.Double(10))
        {
            IsBackground = true,
            Priority = ThreadPriority.Highest
        };

        var thread2 = new Thread(() => result2 = cut.Double(20))
        {
            IsBackground = true,
            Priority = ThreadPriority.Lowest
        };

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        using (new AssertionScope())
        {
            result1.Should().Be(expectedResult1);
            result2.Should().Be(expectedResult2);

            cut.ProcessedNumbers.Should().Contain([10, 20]);
        }
    }
}
