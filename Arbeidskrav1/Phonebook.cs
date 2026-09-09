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
    
    public int Comparisons()
    {
        return _comparisons;
    }

    public Contact[] Contacts()
    {
        return _contacts;
    }
    
    public Contact[] LinearSearch(Field field, string target)
    {
        Console.WriteLine($"Searching for: {target} in {field}");
        _searchResults = [];
        for (int i = 0; i < _contacts.Length; i++)
        {
            _comparisons++;
            if (string.Compare(_contacts[i].GetProperty(field), target, StringComparison.OrdinalIgnoreCase) == 0)
            {
                _searchResults.Add(_contacts[i]);
            }
        }
        return _searchResults.ToArray();
    }

    public void InsertionSort(Field field, SortOrder order)
    {
        if (order == SortOrder.Ascending) InsertionSortAscending(field);
        else InsertionSortDescending(field);
    }

    public void InsertionSortAscending(Field field)
    {
        _comparisons = 0;
        for (int i = 1; i < _contacts.Length; i++)
        {
            if (_contacts[i] == null) continue;
            int j = i - 1;
            var current = _contacts[i].GetProperty(field);
            var insert = _contacts[i];

            while (j >= 0 && string.Compare(_contacts[j].GetProperty(field), current,
                       StringComparison.OrdinalIgnoreCase) > 0)
            {
                _comparisons++;
                _contacts[j + 1] = _contacts[j];
                j--;
            }

            _contacts[j + 1] = insert;
        }

        foreach (Contact contact in _contacts)
        {
            Console.WriteLine(contact.ToString());
        }
    }

    public void InsertionSortDescending(Field field)
    {
        _comparisons = 0;
        for (int i = 1; i < _contacts.Length; i++)
        {
            if (_contacts[i] == null) continue;
            int j = i - 1;
            var current = _contacts[i].GetProperty(field);
            var insert = _contacts[i];
            
            while (j >= 0 && string.Compare(_contacts[j].GetProperty(field), current,StringComparison.OrdinalIgnoreCase) < 0)
            {
                _comparisons++;
                _contacts[j + 1] = _contacts[j];
                j--;
            }
            _contacts[j + 1] = insert;
        }
        foreach (Contact contact in _contacts)
        {
            Console.WriteLine(contact.ToString());
        }
    }
    
}