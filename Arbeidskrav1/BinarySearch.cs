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
        //InsertionSort insertionSort = new InsertionSort();
        //insertionSort.Sort(array, field);
        _comparisons = 0;
        
        int high = array.Length - 1;
        int low = 0;
        int index = -1;

        if (low == high)
        {
            return low;
        }

        while (low < high)
        {
            int mid = (low + high) / 2; 
            if (FindOrder(GetField(array[mid], field), target) < 0)
            {
                high = mid;
            }
            else if (FindOrder(GetField(array[mid], field), target) == 0)
            {
                high = mid;
                break;
            }
            else low = mid + 1;
        }

        for (int i = high - 1; i >= 0; i--)
        {
            if (string.Compare(target, GetField(array[i], field), StringComparison.OrdinalIgnoreCase) == 0) continue;
            if (string.Compare(target, GetField(array[i + 1], field), StringComparison.OrdinalIgnoreCase) == 0) index = i + 1;
        }

        Console.WriteLine($"{target} - [{index.ToString()}] - {_comparisons}");
        return index;
    }
}