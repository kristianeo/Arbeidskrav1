namespace Arbeidskrav1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        string phonebookCsv = @"..\..\..\phonebook.csv";
        
        var lines = File.ReadAllLines(phonebookCsv);

        Phonebook phonebook = new Phonebook(lines);

        var result = phonebook.LinearSearch(Phonebook.Field.FirstName, "Ola");

        Console.WriteLine(result.Length);
    }
}