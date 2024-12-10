namespace CSharp.Experiments.Algorithms.Sorting;

// It recursively divides the array into halves until each subarray contains a single element,
// which is inherently sorted. Then, it merges the sorted subarrays back together to form a fully sorted array.
//
// Time Complexity: O(n * log(n)).
//  ==> Divide Step: O(log(n)
//  ==> Merge Step: O(n)
public class MergeSort
{
    public void Run(int[] numbers)
    {
        ArgumentNullException.ThrowIfNull(numbers, nameof(numbers));

        if (numbers.Length <= 1)
        {
            return;
        }

        var (left, right) = SplitInHalf(numbers);

        this.Run(left);
        this.Run(right);

        Merge(numbers, left, right);
    }

    private static (int[] left, int[] right) SplitInHalf(int[] numbers)
    {
        var mid = numbers.Length / 2;
        var left = GetSubarray(numbers, from: 0, to: mid - 1);
        var right = GetSubarray(numbers, from: mid, to: numbers.Length - 1);
        return (left, right);
    }

    private static int[] GetSubarray(int[] array, int from, int to)
    {
        var length = to - from + 1;
        var result = new int[length];
        Array.Copy(array, from, result, 0, length);
        return result;
    }

    private static void Merge(int[] array, int[] left, int[] right)
    {
        var i = 0;
        var j = 0;
        var k = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                array[k] = left[i++];
            }
            else
            {
                array[k] = right[j++];
            }

            k++;
        }

        while (i < left.Length)
        {
            array[k++] = left[i++];
        }

        while (j < right.Length)
        {
            array[k++] = right[j++];
        }
    }
}