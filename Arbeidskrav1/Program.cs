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
        
        // Linear search
        Console.WriteLine("1. LINEAR SEARCH, UNSORTED: ");
        var tableLinear = new ConsoleTable("#", "Field", "Target", 
            "Matches", "Comparisons");
        LinearSearch linearSearch = new LinearSearch();
        
        // Best case - a value held by the first record  
        Contact[] results = linearSearch.Search(phonebook.Contacts(), Field.LastName, "Bjerke");
        tableLinear.AddRow(1, "Last name", "Bjerke", results.Length, linearSearch.Comparisons);
        
        // Worst case - a value held by the last record 
        results = linearSearch.Search(phonebook.Contacts(), Field.FirstName, "Camilla");
        tableLinear.AddRow(2, "First name", "Camilla", results.Length, linearSearch.Comparisons);
        
        // Surname not in the file 
        results = linearSearch.Search(phonebook.Contacts(), Field.LastName, "Etternavnsen");
        tableLinear.AddRow(3, "Last name", "Etternavnsen", results.Length, linearSearch.Comparisons);
        
        // Mobile number not in the file
        results = linearSearch.Search(phonebook.Contacts(), Field.Mobile, "12345678");
        tableLinear.AddRow(4, "Mobile", "12345678", results.Length, linearSearch.Comparisons);
        
        // Mobile number in the file
        results = linearSearch.Search(phonebook.Contacts(), Field.Mobile, "48955861");
        tableLinear.AddRow(5, "Mobile", "48955861", results.Length, linearSearch.Comparisons);
        
        tableLinear.Write();

        // Sorting
        Console.WriteLine("\n2. SORTING - BY LAST NAME ASCENDING:");
        var tableSort = new ConsoleTable("#", "Algorithm", "Shape", 
            "Comparisons", "Swaps");
        InsertionSort insertionSort = new InsertionSort();
        HeapSort heapSort = new HeapSort();
        
        // As-supplied 
        insertionSort.Sort(phonebook.Contacts(), Field.LastName);
        tableSort.AddRow(1, "Insertion sort", "As-supplied", insertionSort.Comparisons, insertionSort.Moves);
        
        heapSort.Sort(phonebook2.Contacts(), Field.LastName);
        tableSort.AddRow(2, "Heap sort", "As-supplied", heapSort.Comparisons, heapSort.Moves);
        
        // Already sorted 
        insertionSort.Sort(phonebook.Contacts(), Field.LastName);
        tableSort.AddRow(3, "Insertion sort", "Already sorted", insertionSort.Comparisons, insertionSort.Moves);

        heapSort.Sort(phonebook.Contacts(), Field.LastName);
        tableSort.AddRow(4, "Heap sort", "Already sorted", heapSort.Comparisons, heapSort.Moves);
        
        // Reverse sorted 
        InsertionSort iSortDescending = new InsertionSort(SortOrder.Descending);
        iSortDescending.Sort(phonebook.Contacts(), Field.LastName);
        tableSort.AddRow(5, "Insertion sort", "Reverse sorted", iSortDescending.Comparisons, iSortDescending.Moves);

        heapSort.Sort(phonebook.Contacts(), Field.LastName);
        tableSort.AddRow(6, "Heap sort", "Reverse sorted", heapSort.Comparisons, heapSort.Moves);
        
        tableSort.Write();
        
        // Binary search
        Console.WriteLine("\n3. BINARY SEARCH - BY LAST NAME ASCENDING");
        BinarySearch bSearch = new BinarySearch();
        var table = new ConsoleTable("#", "Sorted by", "Target", 
            "Expected", "Result", "Comparisons", "Pass/fail");

        // Sorting by mobile numbers
        insertionSort.Sort(phonebook.Contacts(), Field.Mobile);
        
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
        
        // Searching for a number above the largest 
        index = bSearch.Search(phonebook.Contacts(), Field.Mobile, "99999999");
        expectedIndex = ExpectedIndex(phonebook.Contacts(), Field.Mobile, "99999999");
        passOrFail = PassOrFail(expectedIndex, index);
        table.AddRow(3, "Mobile", "99999999", passOrFail.Item1, index, bSearch.Comparisons, passOrFail.Item2);
        
        // Sorting by last names 
        insertionSort.Sort(phonebook.Contacts(), Field.LastName);
        
        // A surname appearing several times 
        index = bSearch.Search(phonebook.Contacts(), Field.LastName, "Kristoffersen");
        expectedIndex = ExpectedIndex(phonebook.Contacts(), Field.LastName, "Kristoffersen");
        passOrFail = PassOrFail(expectedIndex, index);
        table.AddRow(4, "Last name", "Kristoffersen", passOrFail.Item1, index, bSearch.Comparisons, passOrFail.Item2);

        // Testing to check if target is first instance
        int indexTest = index - 1;
        Contact contactTest = phonebook.Contact(indexTest);
        
        // A surname not in the file 
        index = bSearch.Search(phonebook.Contacts(), Field.LastName, "Zloten");
        expectedIndex = ExpectedIndex(phonebook.Contacts(), Field.LastName, "Zloten");
        passOrFail = PassOrFail(expectedIndex, index);
        table.AddRow(5, "Last name", "Zloten", passOrFail.Item1, index, bSearch.Comparisons, passOrFail.Item2);
        
        // Sorting by first names 
        insertionSort.Sort(phonebook.Contacts(), Field.FirstName);
        
        // A first name appearing in the file 
        index = bSearch.Search(phonebook.Contacts(), Field.FirstName, "Thea");
        expectedIndex = ExpectedIndex(phonebook.Contacts(), Field.FirstName, "Thea");
        passOrFail = PassOrFail(expectedIndex, index);
        table.AddRow(6, "First name", "Thea", passOrFail.Item1, index, bSearch.Comparisons, passOrFail.Item2);
        
        // Testing to check if target is first instance
        int indexTest2 = index - 1;
        Contact contactTest2 = phonebook.Contact(indexTest2);
        
        // Any target on an empty array
        Contact[] emptyArray = [];
        index = bSearch.Search(emptyArray, Field.FirstName, "Camilla");
        expectedIndex = ExpectedIndex(emptyArray, Field.FirstName, "Camilla");
        passOrFail = PassOrFail(expectedIndex, index);
        table.AddRow(7, "First name", "Camilla", passOrFail.Item1, index, bSearch.Comparisons, passOrFail.Item2);
        
        // The only value in a one element array 
        Contact contact = new Contact("Camilla,Hansen,95877468,1975-05-12,Parkveien 31,Halden");
        Contact[] oneElementArray = [contact];
        index = bSearch.Search(oneElementArray, Field.FirstName, "Camilla");
        expectedIndex = ExpectedIndex(oneElementArray, Field.FirstName, "Camilla");
        passOrFail = PassOrFail(expectedIndex, index);
        table.AddRow(8, "First name", "Camilla", passOrFail.Item1, index, bSearch.Comparisons, passOrFail.Item2);
        
        table.Write();
        
        // Printing test results
        Console.WriteLine($"#4 test: Contact[{indexTest}] = {contactTest.LastName}");
        Console.WriteLine($"#6 test: Contact[{indexTest2}] = {contactTest2.FirstName}");

        
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