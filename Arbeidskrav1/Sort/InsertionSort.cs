namespace Arbeidskrav1;

public class InsertionSort : Algorithm, ISort
{
    public InsertionSort(SortOrder order = SortOrder.Ascending)
    {
        Order = order;
    }
    public Contact[] Sort(Contact[] array, Field field)
    {
        _moves = 0;
        _comparisons = 0;
        
        for (int i = 1; i < array.Length; i++)
        {
            int j = i - 1;
            if (array[i] == null | array[j] == null) continue;
            var current = array[i];

            while (j >= 0 && FindOrder(GetField(array[j], field), GetField(current, field)) > 0)
            {
                _moves++;
                array[j + 1] = array[j];
                j--;
                
            }
            
            array[j + 1] = current;
        }
        return array;
    }
}