using CSharp.Experiments.Algorithms.Sorting;
using Shouldly;

namespace CSharp.Experiments.Algorithms.Tests.Sorting;

public class MergeSortTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void GiveArray_WhenSort_ThenResultAsExpected(int[] numbers, int[] expectedResult)
    {
        new MergeSort().Sort(numbers);
        numbers.ShouldBeEquivalentTo(expectedResult);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return
        [
            new[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 },
            new[] { -42, -11, -9, 0, 1, 6, 12, 68, 90 }
        ];
    }
}
