namespace Arbeidskrav1;
using ConsoleTables;

class Program
{
    static void Main(string[] args)
    {
        var lines = File.ReadAllLines(@"..\..\..\Library\phonebook.csv");

        string[] test = ["Camilla,Hansen,95877468,1975-05-12,Parkveien 31,Halden"];
        
        Phonebook phonebook = new Phonebook(lines);
        Phonebook phonebook2 = new Phonebook(lines);
        // må fikse print for resultatliste hvis tomt array 
        
        Console.WriteLine("1. LINEAR SEARCH, UNSORTED: ");
        Console.WriteLine("field - target - matches - comparisons");
        LinearSearch linearSearch = new LinearSearch();
        linearSearch.Search(phonebook.Contacts(), Field.LastName, "Bjerke");
        linearSearch.Search(phonebook.Contacts(), Field.FirstName, "Camilla");
        linearSearch.Search(phonebook.Contacts(), Field.LastName, "Etternavn");
        linearSearch.Search(phonebook.Contacts(), Field.Mobile, "12345678");
        linearSearch.Search(phonebook.Contacts(), Field.Mobile, "48955861");

        Console.WriteLine("\n2. SORTING - BY LAST NAME ASCENDING:");
        Console.WriteLine("algorithm - shape - comparisons - swaps");
        InsertionSort iSort = new InsertionSort();
        Console.Write("Insertion sort - as-supplied - ");
        iSort.Sort(phonebook.Contacts(), Field.LastName);
        Console.Write("\nInsertion sort - already-sorted - ");
        iSort.Sort(phonebook.Contacts(), Field.LastName);
        InsertionSort iSortDescending = new InsertionSort(SortOrder.Descending);
        Console.Write("\nInsertion sort - reverse-sorted - ");
        iSortDescending.Sort(phonebook.Contacts(), Field.LastName);
        Console.Write("\nHeap sort - as-supplied - ");
        HeapSort hSort = new HeapSort();
        hSort.Sort(phonebook2.Contacts(), Field.LastName);
        HeapSort hSortDescending = new HeapSort(SortOrder.Descending);
        Console.Write("\nHeap sort - already-sorted - ");
        Console.Write("\nHeap sort - reverse-sorted - ");

        Console.WriteLine("\n3. BINARY SEARCH - BY LAST NAME ASCENDING");
        BinarySearch bSearch = new BinarySearch();
        var table = new ConsoleTable("#", "Sorted by", "Target", 
            "Expected", "Result", "Comparisons", "Pass/fail");

        iSort.Sort(phonebook.Contacts(), Field.Mobile);
        // Searching a number that's in the array 
        int index = bSearch.Search(phonebook.Contacts(), Field.Mobile, "90468543");
        int expectedIndex = ExpectedIndex(phonebook.Contacts(), Field.Mobile, "90468543");
        var passOrFail = PassOrFail(expectedIndex, index);
        table.AddRow(1, "Mobile", "90468534", passOrFail.Item1, index, bSearch.Comparisons, passOrFail.Item2);
        
        // Searching for a number below the smallest
        index = bSearch.Search(phonebook.Contacts(), Field.Mobile, "00000000");
        expectedIndex = ExpectedIndex(phonebook.Contacts(), Field.Mobile, "00000000");
        passOrFail = PassOrFail(expectedIndex, index);
        table.AddRow(2, "Mobile", "00000000", passOrFail.Item1, index, bSearch.Comparisons, passOrFail.Item2);
        
        
        index = bSearch.Search(phonebook.Contacts(), Field.LastName, "Kristoffersen");
        //var passOrFail = PassOrFail("Kristoffersen", phonebook.Contact(index).LastName);
        
        bSearch.Search(phonebook.Contacts(), Field.LastName, "Zloten");
        //Contact check = phonebook.Contact(index-1);
        //Console.WriteLine($"Check: {index-1} - {check.LastName}");
        bSearch.Search(phonebook.Contacts(), Field.Mobile, "40762016");
        
        table.Write();
        return;

        (int, string) PassOrFail(int expected, int searchResult)
        {
            if (expected == searchResult) return (expected, "pass");
            return (expected, "fail");
        }

        int ExpectedIndex(Contact[] array, Field field, string target)
        {
            return Array.FindIndex(array, contact => contact.GetField(field).Contains(target));
        }
        
    }
};