namespace Arbeidskrav1;

public class LinearSearch: Algorithm, ISearch
{
    private List<Contact> _searchResults;
    public Contact[] Search(Contact[] array, Field field, string target)
    {
        _searchResults = [];
        _comparisons = 0;
    
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != null && FindOrder(GetField(array[i], field), target) == 0)
            {
                _searchResults.Add(array[i]);
                if (field == Field.Mobile) break;
            }
        }

        return _searchResults.ToArray();
    }
}