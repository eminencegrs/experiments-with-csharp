using System.Diagnostics;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter1.SchedulingAndPriorities;

public class Calculator
{
    private readonly int id;

    public Calculator(int id)
    {
        this.id = id;
    }

    public (long result, long elapsed) Calculate()
    {
        long sum = 0;
        Stopwatch stopwatch = Stopwatch.StartNew();

        for (var i = 1; i <= 1000000; i++)
        {
            sum += i;
        }

        stopwatch.Stop();

        Debug.WriteLine(
            $"Thread {this.id} finished with sum: {sum}. " +
            $"Priority: {Thread.CurrentThread.Priority}. " +
            $"Elapsed: {stopwatch.ElapsedMilliseconds} ms.");

        return (sum, stopwatch.ElapsedMilliseconds);
    }
}
