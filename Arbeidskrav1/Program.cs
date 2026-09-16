namespace Arbeidskrav1;

class Program
{
    static void Main(string[] args)
    {
        var lines = File.ReadAllLines(@"..\..\..\phonebook.csv");

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
        int index = bSearch.BinarySearchRecursion(phonebook.Contacts(), Field.LastName, "Hansen",
            phonebook.Contacts().Length - 1, 0);
        //int index = bSearch.Search(phonebook.Contacts(), Field.LastName, "Kristoffersen");
        bSearch.Search(phonebook.Contacts(), Field.LastName, "Zloten");
        Contact check = phonebook.Contact(index-1);
        Console.WriteLine($"Check: {index-1} - {check.LastName}");
        bSearch.Search(phonebook.Contacts(), Field.Mobile, "40762016");
        
    }
};