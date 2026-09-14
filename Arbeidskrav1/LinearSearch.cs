namespace Arbeidskrav1;

public class LinearSearch: Algorithm, ISearch
{
    private readonly List<Contact> _searchResults = [];
    public Contact[] Search(Contact[] array, Field field, string target)
    {
        Console.WriteLine($"Searching for: {target} in {field}");
    
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != null && FindOrder(GetField(array[i], field), target) == 0)
            {
                _searchResults.Add(array[i]);
            }
        }

        return _searchResults.ToArray();
    }
}