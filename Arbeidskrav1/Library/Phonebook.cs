namespace Arbeidskrav1;

public class Phonebook
{
    private Contact[] _contacts;

    /// <summary>
    /// Creates a phonebook class with a Contacts array.
    /// Exits the program if the supplied string array
    /// does not create Contact instances properly.  
    /// </summary>
    /// <param name="phonebook"></param>
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

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Array of contacts in phonebook</returns>
    public Contact[] Contacts()
    {
        return _contacts;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <returns>Contact in phonebook at given index</returns>
    public Contact Contact(int index)
    {
        return _contacts[index];
    }
    
}