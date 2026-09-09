namespace Arbeidskrav1;

class Program
{
    static void Main(string[] args)
    {
        var lines = File.ReadAllLines(@"..\..\..\phonebook.csv");

        Phonebook phonebook = new Phonebook(lines);

        var result = phonebook.LinearSearch(Phonebook.Field.Mobile, "97756218");

        if (result.Length > 0)
        {
            foreach (var contact in result)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        else Console.WriteLine("No results found...");

        Console.WriteLine($"Comparisons: {phonebook.Comparisons()}");
        Console.WriteLine();
        
        phonebook.InsertionSort(Phonebook.Field.FirstName, Phonebook.SortOrder.Descending);
        Console.WriteLine(phonebook.Comparisons());
        Console.WriteLine();
        phonebook.InsertionSort(Phonebook.Field.FirstName, Phonebook.SortOrder.Ascending);
        Console.WriteLine(phonebook.Comparisons());
        
        
    }
}