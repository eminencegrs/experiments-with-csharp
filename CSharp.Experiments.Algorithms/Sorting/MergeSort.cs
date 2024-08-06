namespace CSharp.Experiments.Algorithms.Sorting;

public class MergeSort
{
    public void Sort(int[] numbers)
    {
        if (numbers.Length <= 1) { return; }

        int mid = numbers.Length / 2;
        int[] left = GetSubarray(numbers, 0, mid - 1);
        int[] right = GetSubarray(numbers, mid, numbers.Length - 1);

        this.Sort(left);
        this.Sort(right);

        int i = 0;
        int j = 0;
        int k = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                numbers[k] = left[i++];
            }
            else
            {
                numbers[k] = right[j++];
            }

            k++;
        }

        while (i < left.Length)
        {
            numbers[k++] = left[i++];
        }

        while (j < right.Length)
        {
            numbers[k++] = right[j++];
        }
    }

    private static int[] GetSubarray(int[] numbers, int start, int end)
    {
        int length = end - start + 1;
        int[] result = new int[length];
        Array.Copy(numbers, start, result, 0, length);
        return result;
    }
}
