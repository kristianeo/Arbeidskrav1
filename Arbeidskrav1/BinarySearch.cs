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
        bool targetFound = false;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            int comparison = FindOrder(GetField(array[mid], field), target);
            if (comparison > 0) high = mid -1;
            else if (comparison < 0) low = mid + 1;
            else
            {
                high = mid;
                index = high;
                targetFound = true;
                break;
            }
        }

        if (targetFound && high > 0)
        {
            
            while (high > 0 && string.Compare(target, GetField(array[high], field), 
                       StringComparison.OrdinalIgnoreCase) == 0)
            {
                high--;
            }
            index = high + 1;
        }

        Console.WriteLine($"{target} - [{index.ToString()}] - {_comparisons}");
        return index;
        }
    }