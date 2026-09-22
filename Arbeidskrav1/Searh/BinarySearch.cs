namespace Arbeidskrav1;

public class BinarySearch:Algorithm
{
    public BinarySearch(SortOrder order = SortOrder.Ascending)
    {
        Order = order;
    }

    /// <summary>
    /// Searches an array for a target string in given field.
    /// The method uses InsertionSort to ensure the array is sorted by
    /// given field before searching. 
    /// </summary>
    /// /// <param name="array"></param>
    /// <param name="field">FirstName, LastName or Mobile</param>
    /// <param name="target"></param>
    /// <returns>index of first contact in the array matching target,
    /// or -1 if criteria is not met</returns>
    public int Search(Contact[] array, Field field, string target)
    {
        if (!IsSorted(array, field))
        {
            Console.WriteLine("Error: the array is not sorted by given field...");
            return -1;
        }
        _comparisons = 0;

        int high = array.Length - 1;
        int low = 0;
        int index = -1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            int comparison = FindOrder(GetField(array[mid], field), target);
            if (comparison > 0) high = mid -1;
            else if (comparison < 0) low = mid + 1;
            else
            {
                index = FindFirstInstance(array, field, mid, target);
                return index;
            }
        }
        return index;
        }

    public int BinarySearchRecursion(Contact[] array, Field field, string target, int high, int low)
    {
        int index;
        if (low > high)
        {
            index = -1;
            return index;
        }
    
        int mid = (low + high) / 2;
        int comparison = FindOrder(GetField(array[mid], field), target);
        switch (comparison)
        {
            case > 0:
                return BinarySearchRecursion(array, field, target, mid-1, low);
            case < 0:
                return BinarySearchRecursion(array, field, target, high, mid+1);
            case 0:
                int comparisons = _comparisons;
                index = FindFirstInstance(array, field, mid, target);
                return index;
        }
    }

    private int FindFirstInstance(Contact[] array, Field field, int index, string target)
    {
        if (array.Length == 1) return index;
        // Finding the first instance should not count as comparisons in the search methods
        _comparisons--;
        // If the value on the previous index is smaller than the target, the index is the first instance
        if (FindOrder(GetField(array[index - 1], field), target) < 0) return index;
        // Checks recursively all the previous indices until one is smaller 
        return FindFirstInstance(array, field, index - 1, target);
    }
    
    private bool IsSorted(Contact[] arr, Field field)
    {
        int last = arr.Length - 1;
        if (last < 1) return true;

        int i = 0;

        while(i < last && FindOrder(GetField(arr[i], field), GetField(arr[i + 1], field)) <= 0)
            i++;

        return i == last;
    }
}