namespace Arbeidskrav1;

public class BinarySearch:Algorithm
{
    public int Search(Contact[] array, Field field, string target)
{
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