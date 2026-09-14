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
        
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == null) continue;
            int j = i - 1;
            var current = array[i];
            var insert = array[i];

            while (j >= 0 && array[j] != null)
            {
                if (FindOrder(array[j], current, field, Order))
                {
                    _moves++;
                    array[j + 1] = array[j];
                    j--;
                }
                else break;
            }
            
            array[j + 1] = insert;
        }

        return array;
    }
}