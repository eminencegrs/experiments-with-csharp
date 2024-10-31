using CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter2;
using Xunit;
using FluentAssertions;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.UnitTests.Part1.Chapter2;

public class SystemTimersTimerTests
{
    [Fact]
    public void GivenInterval_WhenStartTimerAndStopTimer_ThenElapsedEventIsTriggered10Times()
    {
        const uint intervalInMilliseconds = 99;
        var cut = new SystemTimersTimer();
        cut.StartTimer(intervalInMilliseconds);
        Thread.Sleep(TimeSpan.FromSeconds(1));
        cut.StopTimer();
        cut.GetSignalTimes().Count.Should().Be(10);
    }

    [Fact]
    public async Task GivenIntervalAndManyTasks_WhenStartTimerAndStopTimer_ThenNoDataCorruptionOccurs()
    {
        const uint intervalInMilliseconds = 99;
        var cut = new SystemTimersTimer();

        var tasks = new List<Task>();
        for (int i = 0; i < 10; i++)
        {
            tasks.Add(Task.Run(() =>
            {
                cut.StartTimer(intervalInMilliseconds);
                Task.Delay(200).Wait();
                cut.StopTimer();
            }));
        }

        await Task.WhenAll(tasks);

        var signalTimes = cut.GetSignalTimes();

        signalTimes.Count.Should().BeGreaterThan(0);
        signalTimes.Should().OnlyHaveUniqueItems();
    }
}
