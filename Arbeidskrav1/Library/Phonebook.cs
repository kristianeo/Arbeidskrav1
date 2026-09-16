namespace Arbeidskrav1;

public class Phonebook
{
    private Contact[] _contacts;

    public Phonebook(string[] phonebook)
    {
        _contacts = new Contact[200];
        for (int i = 1; i < phonebook.Length; i++)
        {
            Contact contact = new Contact(phonebook[i]);
            _contacts[i - 1] = contact;
        }
    }

    public Contact[] Contacts()
    {
        return _contacts;
    }

    public Contact Contact(int index)
    {
        return _contacts[index];
    }
    
}