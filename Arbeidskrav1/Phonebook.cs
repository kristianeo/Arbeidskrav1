namespace Arbeidskrav1;

public class Phonebook
{
    private Contact[] _contacts;

    private List<Contact> _searchResults;

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
        for (int i = 1; i < phonebook.Length - 1; i++)
        {
            Contact contact = new Contact(phonebook[i]);
            _contacts[i] = contact;
        }
    }
    public Contact[] LinearSearch(Field field, string target)
    {
        _searchResults = [];
        for (int i = 1; i < _contacts.Length; i++)
        {
            if (string.Compare(_contacts[i].GetProperty(field), target, StringComparison.OrdinalIgnoreCase) == 0)
            {
                _searchResults.Add(_contacts[i]);
                _comparisons++;
            }
        }

        return _searchResults.ToArray();
    }

}