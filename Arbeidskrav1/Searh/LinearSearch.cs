namespace Arbeidskrav1;

public class LinearSearch: Algorithm, ISearch
{
    private List<Contact> _searchResults;
    /// <summary>
    /// Compares the target to every single index in the array.
    /// If it searches for a target with no duplicates, it can early exit.
    /// Best-case complexity O(1), first index matched target.
    /// Average- and worst-case complexity O(n) = 200. 
    /// </summary>
    /// <param name="array"></param>
    /// <param name="field"></param>
    /// <param name="target"></param>
    /// <returns>Array of contacts that match the criteria, empty
    /// array if there are none</returns>
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