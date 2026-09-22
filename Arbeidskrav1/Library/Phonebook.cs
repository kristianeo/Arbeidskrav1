namespace Arbeidskrav1;

public class Phonebook
{
    private Contact[] _contacts;

    public Phonebook(string[] phonebook)
    {
        _contacts = new Contact[200];
        for (int i = 1; i < phonebook.Length; i++)
        {
            try
            {
                Contact contact = new Contact(phonebook[i]);
                _contacts[i - 1] = contact;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not load phonebook properly: {e.Message}" +
                                  $"\nPlease try again with a valid phonebook.");
                Environment.Exit(1);
            }
            
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