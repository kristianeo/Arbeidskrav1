namespace Arbeidskrav1;

public class Phonebook
{
    Contact[] _contacts = new Contact[200];

    public enum Field
    {
        FirstName,
        LastName, 
        Mobile
    }
    public enum SortOrder { Ascending, Descending }

    public Phonebook(string[] phonebook)
    {
        for (int i = 1; i < 202; i++)
        {
            Contact contact = new Contact(phonebook[i]);
            _contacts = _contacts.Append(contact).ToArray();
        }
    }

}