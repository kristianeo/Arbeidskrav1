namespace Arbeidskrav1;

class Program
{
    static void Main(string[] args)
    {
        var lines = File.ReadAllLines(@"..\..\..\phonebook.csv");

        string[] test = [];
        
        Phonebook phonebook = new Phonebook(lines);
        /*

        phonebook.LinearSearch(Phonebook.Field.FirstName, "Amal");        

        Console.WriteLine($"Comparisons: {phonebook.Comparisons()}");

        Console.WriteLine();
        */
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

    }
}