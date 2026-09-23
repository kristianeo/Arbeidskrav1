# Searching and Sorting: Report

|      |                             |
|------|-----------------------------|
| Name | Kristiane Olsen             |
| Date | 23.09.2026                  |
| Data | phonebook.csv, 200 contacts |

### Complexity reference:
| Operation      | Best       | Average    | Average n = 200 | Worst      | Space |
|----------------|------------|------------|-----------------|------------|-------|
| Linear search  | O(1)       | O(n)       | 200             | O(n)       | O(1)  |
| Binary search  | O(1)       | O(log n)   | 7.64            | O(log n)   | O(1)  |
| Insertion sort | O(n)       | O(n^2)     | 40 000          | O(n^2)     | O(1)  |
| Heap sort      | O(n log n) | O(n log n) | 1528            | O(n log n) | O(1)  |

## 1. Searching unsorted data
| # | Field      | Target   | Case                     | Matches | Comparisons |
|---|------------|----------|--------------------------|---------|-------------|
| 1 | Last name  | Bjerke   | first record (best case) | 9       | 200         |
| 2 | First name | Camilla  | last record (worst case) | 7       | 200         |
| 4 | Mobile     | 12345678 | absent value             | 0       | 200         |
| 5 | Mobile     | 90468543 | phone number in contacts | 1       | 20          |

**Reflection** 

Linear search compares the target to every single index in the array. This results in the same 
comparison count if the target is present or not, reflected by the average complexity in the 
reference. The exception is when the algorithm knows there are no duplicates. If the target 
is found it early exits, and if the target is at index 0 it returns the best-case result. 

## 2. Sorting

| # | Algorithm      | Input shape       | Comparisons | Swaps or moves |
|---|----------------|-------------------|-------------|----------------|
| 1 | Insertion sort | As-supplied       | 9691        | 9494           |
| 3 | Insertion sort | Already sorted    | 199         | 0              |
| 5 | Insertion sort | Reverse sorted    | 17375       | 17190          |
| 2 | Heap sort      | As-supplied       | 2458        | 1347           |
| 4 | Heap sort      | Already sorted    | 2485        | 1426           |
| 6 | Heap sort      | Reverse sorted    | 2248        | 1182           |

**Reflection**

The results using heap sort are relatively similar regardless of the input shape, reflecting the 
consistent time complexity. When given an already sorted array, insertion sort shows the best-case
complexity, while the reverse sorted array showing the worst-case. Due to duplicates in the array, the 
worst-case results are a bit lower than expected. The average-case results are approximately in the middle
between the worst- and best case, which is expected. The results show that heap sort is the preferred 
method on unsorted and larger arrays.

Both sorting algorithms work on empty and one-element arrays, shown in the console table. 

## 3. Searching sorted data
| # | Sorted by  | Target                                | Expected | Result | Comparisons | Pass/fail |
|---|------------|---------------------------------------|----------|--------|-------------|-----------|
| 1 | Mobile     | 90468534 (present target)             | 108      | 108    | 6           | pass      |
| 2 | Last name  | Kristoffersen (appears several times) | 129      | 129    | 5           | pass      |
| 3 | Last name  | Zloten (absent target)                | -1       | -1     | 8           | pass      |
| 4 | First name | Thea                                  | 177      | 177    | 5           | pass      |

Linear search on the same targets, for comparison:

| Target        | Comparisons (linear) | Comparisons (binary) |
|---------------|----------------------|----------------------|
| 90468534      | 20                   | 6                    |
| 99999999      | 200                  | 8                    | 

**Reflection** 

In the case of binary search, the comparisons can be directly compared with the time
complexity since it is the base-2 logarithm of n. On average a search takes 7-8 comparisons, 
and results lower than this represents targets closer to the root. A target not in the array
shows the worst-case, resulting in 7 or 8 comparisons depending on the depth of the branch.

To check if the array is sorted, the search first runs a private method. If the array is unsorted, 
it shows an error message, and returns -1 since the conditions are not met. 

A binary search returns the first result it encounters, not necessarily the first instance in 
the array. My code checks if the result is the first instance by a recursive method, before 
returning it. I have chosen not to count these comparisons as a part of the search, as I want 
it to reflect the complexity.

On average, binary search uses 192 fewer comparisons than linear search, but we need to take
into account the complexity used for sorting. Calculating how many searches to 
perform before sorting pays for itself: 

1528/192 = 7,95 → 8 times using heap sort

40 000/192 = 208,33 → 208 times using insertion sort

## 4. Insight
The single most useful thing these figures taught me is the efficiency of binary search,
as every double of n increases the complexity by only 1. Compared to linear search, it needs
a sorted array, but this cost is paid off after only 8 searches sorting with heap sort. It is 
important to remember that heap sort is not stable, but if that matters another sorting 
algorithm can be used, both quick sort and merge sort has the same time complexity.

This assignment has demonstrated the scale of growth for the different algorithms at a sample
size of only 200. It has shown the stable complexity of heap sort, with stable results 
regardless of the input-shape. Insertion sort has quadratic complexity, significantly worse than
heap sort. The only benefit with insertion sort is with a small, already sorted array. 

## Sources:
https://stackoverflow.com/questions/45298497/difference-between-comparisons-and-swaps-in-insertion-sort

https://stackoverflow.com/questions/11989071/fastest-way-to-check-if-an-array-is-sorted

I did not use AI for this submission, except for some conceptual discussions. 
