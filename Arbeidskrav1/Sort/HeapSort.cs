namespace Arbeidskrav1;

public class HeapSort: Algorithm, ISort
{
    public HeapSort(SortOrder order = SortOrder.Ascending)
    {
        Order = order;
    }
    
    /// <summary>
    /// Constructs a max heap, starting at the last index with children.
    /// Then goes into a loop where it moves the max value (index 0) to the end,
    /// shortens the length of the array and constructs a new max heap.
    /// Time complexity (log n) = 7,64. Not stable. In-place.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="field"></param>
    /// <returns>A non-stable sorted array</returns>
    public Contact[] Sort(Contact[] array, Field field)
    {
        _moves = 0;
        _comparisons = 0;
        
        //Constructs Max heap
        for (int i = (array.Length - 1) / 2; i >= 0; i--)
        {
            if (array[i] == null) continue;
            MaxHeapify(array, field, array.Length, i);
        }
        
        // Moves largest node (first one) to the end and shortens the available array,
        // before finding max heap again. 
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (array[i] == null) continue;
            (array[i], array[0]) = (array[0], array[i]);
            _moves++;
            MaxHeapify(array, field, i, 0);
        }
        return array;
    }

    private void MaxHeapify(Contact[] array, Field field, int length, int i)
    {
        if (i >= (length - 1) / 2) return;
        
        int current = i;
        int leftChild = 2 * i + 1;
        int rightChild = 2 * i + 2; 
        int biggestChild;

        if (rightChild > length - 1 || FindOrder(GetField(array[leftChild], field),
                GetField(array[rightChild], field)) > 0)
        {
            biggestChild = leftChild;
        }

        else biggestChild = rightChild;
        
        
        if (FindOrder(GetField(array[biggestChild], field),
                GetField(array[current], field)) > 0)
        {
            (array[current], array[biggestChild]) = (array[biggestChild], array[current]);
            _moves++;
            MaxHeapify(array, field, length, biggestChild);
        }
    }
}