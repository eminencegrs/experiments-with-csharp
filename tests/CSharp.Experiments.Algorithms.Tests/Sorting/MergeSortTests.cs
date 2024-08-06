using CSharp.Experiments.Algorithms.Sorting;
using Shouldly;

namespace CSharp.Experiments.Algorithms.Tests.Sorting;

public class MergeSortTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void GiveArray_WhenCallRun_ThenResultAsExpected(int[] numbers, int[] expectedResult)
    {
        new MergeSort().Run(numbers);
        numbers.ShouldBeEquivalentTo(expectedResult);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return
        [
            new int[] { },
            new int[] { }
        ];
        yield return
        [
            new[] { 5 },
            new[] { 5 },
        ];
        yield return
        [
            new[] { 1, 2, 3, 4, 5 },
            new[] { 1, 2, 3, 4, 5 },
        ];
        yield return
        [
            new[] { 5, 4, 3, 2, 1 },
            new[] { 1, 2, 3, 4, 5 },
        ];
        yield return
        [
            new[] { 3, 1, -4, 2, 5, 9, -7, 6, 8, 0, -5 },
            new[] { -7, -5, -4, 0, 1, 2, 3, 5, 6, 8, 9 }
        ];
        yield return
        [
            new[] { 5, 2, 3, 3, 2, 2, 1, 4, 4, 4, 5 },
            new[] { 1, 2, 2, 2, 3, 3, 4, 4, 4, 5, 5 }
        ];
        yield return
        [
            new[] { -3, -1, -4, -1, -5, -9, -2, -6, -5, -3, -5 },
            new[] { -9, -6, -5, -5, -5, -4, -3, -3, -2, -1, -1 }
        ];
    }
}
