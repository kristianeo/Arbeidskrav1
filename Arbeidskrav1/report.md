# Searching and Sorting: Report


| |                             |
|---|-----------------------------|
| Name | Kristiane Olsen             |
| Date | 18.09.2026                  |
| Data | phonebook.csv, 200 contacts |

---

## 1. Searching unsorted data

| # | Field      | Target       | Case                      | Matches | Comparisons |
|---|-----------|-------------|---------------------------|---------|----|
| 1 | Last name  | Bjerke       | first record (best case)  | 9       | 200         |
| 2 | First name | Camilla      | last record (worst case)  | 7       | 200     |
| 3 | Last name  | Etternavnsen | absent value              | 0       | 200     |
| 4 | Mobile     | 12345678     | absent value              | 0       | 200     |
| 5 | Mobile     | 48955861     | phone number in contacts| 1       | 11      |
--------------------------------------------------------- 
**Reflection.** 
Linear search goes through the whole array every time to search for the target value, 
by starting at the 0 index and comparing the target to every single item. This means
the search needs O(n) comparisons, in this case n = 200. As a result, the comparisons 
stays the same no matter if an absent or present value is the target. The exception is 
when the algorithm knows there are no duplicates, then it early exits and only compares 
until the target is reached. 

## 2. Sorting

| Algorithm | Input shape | Comparisons | Swaps or moves |
|---|---|---|---|
| 1 | Insertion sort | As-supplied    | 9691        | 9494  |
| 2 | Heap sort      | As-supplied    | 2458        | 1347  |
| 3 | Insertion sort | Already sorted | 199         | 0     |
| 4 | Heap sort      | Already sorted | 2485        | 1426  |
| 5 | Insertion sort | Reverse sorted | 17375       | 17190 |
| 6 | Heap sort      | Reverse sorted | 2248        | 1182  |
------------------------------------------------------------- 
**Reflection**

*Insertion sort:* Worst-case and average-case complexity O(n^2) = 40 000, best-case O(n) = 200. 

*Heap sort:* Consistent complexity: O(n log n) = 1528.

The results are consistent with the calculated complexities, showing that heap sort 
stays pretty consistent regardless of the input shape. Insertion sort did less work on 
an already-sorted array with 199 comparisons and 0 swaps, reflecting the best-case complexity: 200. 
Heap sort does not take into account that the array is already sorted, and yield the same 
results as if the array was unsorted. The results show that heap sort is preferred on larger and 
unsorted arrays compared to insertion sort. 

## 3. Searching sorted data
 -------------------------------------------------------------------------------- 
| # | Sorted by  | Target                                | Expected | Result | Comparisons | Pass/fail |
|---|---|---------------------------------------|---|---|---|---|
| 1 | Mobile     | 90468534 (present target)             | 108      | 108    | 6           | pass      |
| 2 | Mobile     | 00000000 (below lowest number)        | -1       | -1     | 7           | pass      |
| 3 | Mobile     | 99999999 (above highest number)       | -1       | -1     | 8           | pass      |
| 4 | Last name  | Kristoffersen (appears several times) | 129      | 129    | 5           | pass      |
| 5 | Last name  | Zloten (absent target)                | -1       | -1     | 8           | pass      |
| 6 | First name | Thea (present target)                 | 177      | 177    | 5           | pass      |
| 7 | First name | Camilla (empty array)                 | -1       | -1     | 0           | pass      |
| 8 | First name | Camilla (one element array)           | 0        | 0      | 1           | pass      |
--------------------------------------------------------------------------------

Linear search on the same targets, for comparison:

| Target | Comparisons (linear) | Comparisons (binary) |
|---|---|---|
| 90468534 | 200 | 6 |
| 00000000 | 200 | 7 | 
| Kristoffersen| 200 | 5 |
------------------------------------------------------------

**Reflection** 

Binary search complexity: Best-case O(1) when target is middle value. 
Average-case and worst-case O(log n) = 7,64. 

The big-O notation reflects how the complexity grows with increasing n values. 
On average a search takes 7-8 comparisons, and results lower than this represents 
targets closer to the root (values in the middle of the array). For targets not in
the array, they reflect the worst-case by comparing 7 or 8 times, depending on the
depth of the branch it travels down. 

Typically, binary search returns the first result it encounters, regardless if it's the first
instance or not. Before returning the result, it now runs a recursive method to check if
the value of the previous index is smaller than the target. It returns the index where
contact[index - 1] is smaller than the target, thus returning the first instance in the
sorted array. I have chosen not to count these comparisons as a part of the comparisons
for the search, as I want those to reflect the complexities. 

| Algorithm      | Comparison cost (average-case) |
|----------------|--------------------------------|
| Linear search  | 200                            | 
| Insertion sort | 40 000                         | 
| Heap sort      | 1528                           | 
| Binary search  | 8                              |
-------------------------
Binary search uses 192 less comparisons than linear search, but we need to take
into account the comparisons used for sorting.

1528/192 = 8(rounded) => 8 times using heap sort

40 000/192 = 208(rounded) => 208 times using insertion sort

[How many comparisons did binary search need against 200
contacts, and how does that compare with log2(200)? How do you guarantee the
first occurrence when a surname is duplicated? Sorting cost you the comparisons
in part 2: how many searches must you perform before sorting first pays for
itself?]

## 4. Insight

**One paragraph.** [What is the single most useful thing these figures taught you
about choosing an algorithm? Write about something your own numbers show, not
something you read.]

Sources: https://stackoverflow.com/questions/45298497/difference-between-comparisons-and-swaps-in-insertion-sort