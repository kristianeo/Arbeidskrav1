namespace Arbeidskrav1;

class Program
{
    static void Main(string[] args)
    {
        var lines = File.ReadAllLines(@"..\..\..\phonebook.csv");

        string[] test = ["Camilla,Hansen,95877468,1975-05-12,Parkveien 31,Halden"];
        
        Phonebook phonebook = new Phonebook(lines);
        /*

        phonebook.LinearSearch(Phonebook.Field.FirstName, "Amal");        

        Console.WriteLine($"Comparisons: {phonebook.Comparisons()}");

        Console.WriteLine();
        
        phonebook.InsertionSort(Phonebook.Field.FirstName, Phonebook.SortOrder.Descending);
        
        
        Console.WriteLine(phonebook.Comparisons());
        Console.WriteLine(phonebook.Moves());
        Console.WriteLine();
        phonebook.InsertionSort(Phonebook.Field.FirstName, Phonebook.SortOrder.Descending);
        Console.WriteLine(phonebook.Comparisons());
        Console.WriteLine(phonebook.Moves());
        Console.WriteLine();
        phonebook.InsertionSort(Phonebook.Field.FirstName, Phonebook.SortOrder.Ascending);
        
        
        Console.WriteLine(phonebook.Comparisons());
        Console.WriteLine(phonebook.Moves());
        
        phonebook.InsertionSort(Phonebook.Field.FirstName, Phonebook.SortOrder.Ascending);
        foreach (Contact contact in phonebook.Contacts())
        {
            Console.WriteLine(contact.ToString());
        }

        Console.WriteLine();
        */
        /*
        phonebook.InsertionSort(Phonebook.Field.FirstName, Phonebook.SortOrder.Ascending);
        Console.WriteLine(phonebook.Comparisons());
        Console.WriteLine(phonebook.Moves());
        */
        
    

        int index = phonebook.BinarySearch(Phonebook.Field.FirstName, "Camilla");
        if (index != -1)
        {
            Contact[] contacts = phonebook.Contacts();
            Console.WriteLine(contacts[index].ToString());
        }
        else
        {
            Console.WriteLine(index.ToString());
        }
        


        // må fikse print for resultatliste hvis tomt array 

    }
}