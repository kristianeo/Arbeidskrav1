using System.Security.Cryptography;

namespace Arbeidskrav1;

public class Phonebook
{
    private Contact[] _contacts;

    private List<Contact>? _searchResults;

    private int _comparisons;

    private int _moves;

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

    public int Moves()
    {
        return _moves;
    }
    
    public Contact[] LinearSearch(Field field, string target)
    {
        Console.WriteLine($"Searching for: {target} in {field}");
        _searchResults = [];
        
        for (int i = 0; i < _contacts.Length; i++)
        {
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

    public void InsertionSort(Field field, SortOrder order)
    {
        _comparisons = 0;
        _moves = 0;
        
        for (int i = 1; i < _contacts.Length; i++)
        {
            if (_contacts[i] == null) continue;
            int j = i - 1;
            var current = _contacts[i].GetProperty(field);
            var insert = _contacts[i];

            while (j >= 0 && _contacts[j] != null)
            {
                if (FindOrder(_contacts[j].GetProperty(field), current, order))
                {
                    _moves++;
                    _contacts[j + 1] = _contacts[j];
                    j--;
                }
                else break;
            }
            
            _contacts[j + 1] = insert;
        }
    }

    public void HeapSort(Field field, SortOrder order)
    {
        _moves = 0;
        _comparisons = 0;
        
        //Constructs Max heap
        for (int i = (_contacts.Length - 1) / 2; i >= 0; i--)
        {
            if (_contacts[i] == null) return;
            MaxHeapify(field, order, _contacts.Length, i);
        }
        
        // Moves largest node (first one) to the end and shortens the available array
        for (int i = _contacts.Length - 1; i >= 1; i--)
        {
            if (_contacts[i] == null) return;
            (_contacts[i], _contacts[0]) = (_contacts[0], _contacts[i]);
            _moves++;
            MaxHeapify(field, order, i, 0);
        }
    }

    public void ConstructMaxHeap(Field field, SortOrder order, int lenght)
    {
        for (int i = (lenght - 1) / 2; i >= 0; i--)
        {
            MaxHeapify(field, order, lenght, i);
        }
    }

    private void MaxHeapify(Field field, SortOrder order, int length, int i)
    {
        if (i > (length - 1) / 2) return;
        
        int current = i;
        int leftChild = 2 * i + 1;
        int rightChild = 2 * i + 2; 
        int biggestChild;

        if (rightChild > length - 1 || FindOrder(_contacts[leftChild].GetProperty(field),
                _contacts[rightChild].GetProperty(field),order))
        {
            biggestChild = leftChild;
        }

        else biggestChild = rightChild;
        
        
        if (FindOrder(_contacts[biggestChild].GetProperty(field), 
                _contacts[current].GetProperty(field), order))
        {
            (_contacts[current], _contacts[biggestChild]) = (_contacts[biggestChild], _contacts[current]);
            _moves++;
            MaxHeapify(field, order, length, biggestChild);
        }
    }

    private bool FindOrder(string property, string current, SortOrder order)
    {
        switch (order)
        {
            case SortOrder.Ascending when string.Compare(property, current,
                StringComparison.OrdinalIgnoreCase) > 0:
            case SortOrder.Descending when string.Compare(property, current,
                StringComparison.OrdinalIgnoreCase) < 0:
                _comparisons++;
                return true;
            default:
                _comparisons++;
                return false;
        }
    }
    
}