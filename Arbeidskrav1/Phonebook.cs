namespace Arbeidskrav1;

public class Phonebook
{
    private Contact[] _contacts;

    private List<Contact>? _searchResults;

    private int _comparisons;

    public enum Field
    {
        FirstName,
        LastName, 
        Mobile
    }
    public enum SortOrder { Ascending, Descending }

    public Phonebook(string[] phonebook)
    {
        _contacts = new Contact[200];
        for (int i = 1; i < phonebook.Length; i++)
        {
            Contact contact = new Contact(phonebook[i]);
            _contacts[i - 1] = contact;
        }
    }
    public Contact[] LinearSearch(Field field, string target)
    {
        Console.WriteLine($"Searching for: {target} in {field}");
        _searchResults = [];
        
        for (int i = 0; i < _contacts.Length; i++)
        {
            _comparisons++;
            if (_contacts[i] != null && string.Compare(_contacts[i].GetProperty(field), target, StringComparison.OrdinalIgnoreCase) == 0)
            {
                _searchResults.Add(_contacts[i]);
            }
        }

        if (_searchResults.Count == 0)
        {
            Console.WriteLine("No results found...");
            return _searchResults.ToArray();
        }
        
        foreach (var contact in _searchResults)
        {
            Console.WriteLine(contact.ToString());
        }

        return _searchResults.ToArray();
    }

    public int Comparisons()
    {
        return _comparisons;
    }

}