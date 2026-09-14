using System.Security.Cryptography;

namespace Arbeidskrav1;

public class Phonebook
{
    private Contact[] _contacts;

    private List<Contact>? _searchResults;

    private int _comparisons;

    private int _moves;
    
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

    public int Moves()
    {
        return _moves;
    }
    
}