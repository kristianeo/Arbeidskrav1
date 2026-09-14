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
        InsertionSort insertionSort = new InsertionSort();
        insertionSort.Sort(array, field);
        
        int high = array.Length - 1;
        int low = 0;

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
            else low = mid + 1;
        }

        for (int i = high - 1; i >= 0; i--)
        {
            if (FindOrder(target, GetField(array[i], field)) == 0) continue;
            if (FindOrder(target, GetField(array[i + 1], field)) == 0) return i + 1;
        }
        
        return -1;
    }
}