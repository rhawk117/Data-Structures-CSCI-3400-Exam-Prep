using System;
using static System.Console;
using System.Collections.Generic;

namespace _3400_DSA_Prep
{
    // Hardcoded information for each sorting algorithm
    // all derived from AlgoInfo which renders the UI and 
    // handles all of the similar UI logic 

    // bubble sort - cyan
    public class BubbleSort : AlgoInfo
    {

        public BubbleSort() : base() => this.setInfo();
        protected override void setInfo()
        {
            this.title = "Bubble Sort";
            this.bigO = "O(n^2)";
            this.description = @"
            Bubble Sort is one of the simplest sorting algorithms
            that works by repeatedly swapping the adjacent elements
            if they are in the wrong order.
                
                
            This process is repeated until the list is sorted.Despite
            its simplicity, Bubble Sort is not efficient by any means for
            sorting method for large datasets due to its higher time complexity 
            in comparison to more advanced algorithms.
            ";

            this.steps = new string[]
            {
                "The algorithm compares the current element with the next element in the array.",
                "If the current element is greater than the next element, they are swapped with one another.",
                "This process is repeated for all elements, making multiple passes through the list.",
                "With each pass, the largest unsorted element and \"bubbles\" it up to the correct position at\n\t the end of the list."
            };
            this.WorstCaseInput = new List<int> { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            this.explainWorst = @"sorted in reverse order because the algorithm must make O(n - 1) passes 
            through the list to bubble each item.";
            this.Sorter = Sort.BubbleSort;

        }

        protected override void ASCIIart()
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine(@"
            ====================================================================
                __  _           _     _     _                       _    __  
               / / | |__  _   _| |__ | |__ | | ___   ___  ___  _ __| |_  \ \ 
              / /  | '_ \| | | | '_ \| '_ \| |/ _ \ / __|/ _ \| '__| __|  \ \
              \ \  | |_) | |_| | |_) | |_) | |  __/ \__ \ (_) | |  | |_   / /
               \_\ |_.__/ \__,_|_.__/|_.__/|_|\___| |___/\___/|_|   \__| /_/ 
                
            ====================================================================
            ");
            ResetColor();
        }
        protected override void ViewDescription() => desc(bst: "n^2", wst: "n^2", avg: "n^2");
    }
    // insertion sort - green
    public class InsertionSort : AlgoInfo
    {
        public InsertionSort() : base() => this.setInfo();

        protected override void setInfo()
        {
            this.title = "Insertion Sort";
            this.bigO = "O(n^2)";
            this.description = @"
            Insertion Sort is a simple (yet) inefficient sorting algorithm that 
            builds the final sorted collection one item at a time. It is
            much less efficient on large lists than more advanced algorithms 
            such as QuickSort, HeapSort, or MergeSort. 
            
            However, it has advantages for small data sets or nearly sorted arrays
            where it can perform faster than more complex algorithms. It is also
            used in Quick Sort where it is used to sort the almost sorted sublists.
            ";
            this.steps = new string[]
            {
                "The algorithm divides the list into two sections with a bar that starts at index 1",
                "Everything behind the bar is the sorted section, and on each step, the bar moves one\n\t position to the right.",
                "The first element of the list (list[0]) as it will be sorted later if it isn't",
                "The index currently on the bar compares itself to the contents in the sorted section\n\tdecrementing down",
                "On each iteration the bar checks if it is less than the next item down if so it moves\n\titself down",
                "This goes on until either the bar is at index 0 or the next item down is less than the bar",
                "This process is repeated until the list is completely sorted."
            };
            this.WorstCaseInput = new List<int> { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            this.explainWorst = @"sorted in reverse order because the algorithm must make O(n - 1) passes through the 
            list to select the smallest element.";
            this.Sorter = Sort.InsertionSort;
        }
        protected override void ASCIIart()
        {
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine(@"
            ====================================================================
             __  _                     _   _                              _    __  
            / / (_)_ __  ___  ___ _ __| |_(_) ___  _ __    ___  ___  _ __| |_  \ \ 
           / /  | | '_ \/ __|/ _ \ '__| __| |/ _ \| '_ \  / __|/ _ \| '__| __|  \ \
           \ \  | | | | \__ \  __/ |  | |_| | (_) | | | | \__ \ (_) | |  | |_   / /
            \_\ |_|_| |_|___/\___|_|   \__|_|\___/|_| |_| |___/\___/|_|   \__| /_/ 
                
            ====================================================================
            ");
            ResetColor();
        }
        protected override void ViewDescription() => desc(bst: "n^2", wst: "n^2", avg: "n^2");
    }
    // selection sort - dark gray
    public class SelectionSort : AlgoInfo
    {
        public SelectionSort() : base()
        {
            this.setInfo();
        }
        protected override void setInfo()
        {
            title = "Selection Sort";
            this.WorstCaseInput = new List<int> { 0, 0, 0 };
            this.explainWorst = @"not applicable in this case as n^2 traversals will always occur no 
            matter the collection order";
            this.Sorter = Sort.SelectionSort;
            this.bigO = "O(n^2)";
            this.description = @"

            Selection Sort is a simple, intuitive and slow sorting algorithm that 
            selects the minimum element from the unsorted section of the collection and on 
            each step and places it at the current leftmost index. This process is repeated, 
            shrinking the unsorted portion of the list while growing the sorted portion on 
            each traversal. 

            Despite its simplicity, Selection Sort is not efficient and no matter the order 
            of the collection, it will always make n^2 traversals even for a sorted collection.

            ";
            this.steps = new string[]
            {
                "The algorithm starts from the left and progresses to the right on each iteration",
                "Then in a nested loop the smallest element on the right side is selected and replaced\n\t with the current index of the left portion",
                "The algorithim moves one position to the right, and the process is repeated until the\n\t list is sorted"
            };
        }
        protected override void ASCIIart()
        {
            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine(@"
            ====================================================================
            __           _           _   _                              _    __  
           / /  ___  ___| | ___  ___| |_(_) ___  _ __    ___  ___  _ __| |_  \ \ 
          / /  / __|/ _ \ |/ _ \/ __| __| |/ _ \| '_ \  / __|/ _ \| '__| __|  \ \
          \ \  \__ \  __/ |  __/ (__| |_| | (_) | | | | \__ \ (_) | |  | |_   / /
           \_\ |___/\___|_|\___|\___|\__|_|\___/|_| |_| |___/\___/|_|   \__| /_/ 
                                                                           
            ====================================================================
            ");
        }
        protected override void ViewDescription() => desc(bst: "n^2", wst: "n^2", avg: "n^2");
    }
    // shell sort - purple
    public class ShellSort : AlgoInfo
    {
        public ShellSort() : base() => this.setInfo();
        protected override void setInfo()
        {
            this.title = "Shell Sort";
            this.bigO = "O(n^2)";
            this.description = @"

            Shell sort is an algorithim that is an improvement on other algorithims
            that aims to reduce the number of comparisons. This acheived by comparing
            elements that are far apart from one another using sublists of the collection 
            that are generated by a Gap Sequence. 

            The Gap Sequence is a series of integers that are used to determine
            the sublist sizes and the distance between elements that are compared.
            There are multiple Gap Sequences that can be used, but the most common
            ones are the Knuth, Hibbard and Sedgewick Sequences. The one used in this
            program is { 1, 3, 5... } which is the Hibbard Sequence. The gap is done in
            reverse order (5, 3 ,1)

            The 'Gap' is progressively reduced after each sub sequence is sorted
            until it reaches 1. At this point, the collection will now be fully sorted

            ";
            this.steps = new string[]
            {
                "The size of the gap is determined by the Gap Sequence from greatest to least greatest",

                "Then a nested for loop iterates through each of the gaps",
                "A hole is then created at the last index of the gap (closer to the end of the array)",

                "The algorithm then compares elements that are 'gap' distance apart by subtracting the\n\tsize of the gap from the hole",
                "This allows it to move & sort <gap> number of elements on each iteration.",
                "If an item on the right is less than the item on the left, they are swapped",
                "This continues until the last hole >= gap ",

                "Then the next gap is calculated and the processed until the gap is 1",
                "After this, the next highest gap in the sequence is selected",
                "If the element on the left is greater than the element on the right, they are swapped",
                "The gap is then reduced and the process is repeats itself until the gap is 1",
            };
            this.WorstCaseInput = new List<int> { 9, 7, 5, 3, 1, 10, 8, 6, 4, 2 };
            this.Sorter = Sort.ShellSort;
            this.explainWorst = @"using a collection that inverts the gap sequence which will require 
            more comparsions.";
        }
        protected override void ViewDescription() => desc(bst: "nlogn", wst: "n^2", avg: "nlogn");

        protected override void ASCIIart()
        {
            ForegroundColor = ConsoleColor.DarkMagenta;
            WriteLine(@"
            =======================================================
               __      _          _ _                  _    __  
              / /  ___| |__   ___| | |  ___  ___  _ __| |_  \ \ 
             / /  / __| '_ \ / _ \ | | / __|/ _ \| '__| __|  \ \
             \ \  \__ \ | | |  __/ | | \__ \ (_) | |  | |_   / /
              \_\ |___/_| |_|\___|_|_| |___/\___/|_|   \__| /_/ 

            =======================================================                                                    
            ");
            ResetColor();
        }
    }
    // quick sort - dark yellow 
    public class QuickSort : AlgoInfo
    {

        public QuickSort() : base() => this.setInfo();

        protected override void setInfo()
        {
            this.title = "Quick Sort";
            this.bigO = "O(n^2)";
            this.description = @"

            Quick sort is a recursive, divide and conquer sorting algorithm that
            repeatedly divides the collection into smaller sublists and sorts them 
            independently using a pivot into smaller sublists until the collection 
            is 'almost' sorted. The pivot is selected by selecting the median of the
            first, middle and last element of the collection.

            The algorithm is efficient for large datasets and on average out performs
            other sorting algorithms. However, it is not consistent and can be slower on
            collections where the median of 3 selects the smallest or largest element in 
            requiring more swaps.
            ";
            this.WorstCaseInput = new List<int> { 33, 1, 4, 2, 55, 9, 7, 8, 66 };
            this.explainWorst = @"using a collection that ruins the median of 3 approach 
            for selecting the pivot";
            this.Sorter = Sort.QuickSort;
            this.steps = new string[]
            {
                "First, pick a pivot using the median of three strategy (leftmost, middle, rightmost)",
                "These 3 elements are then sorted with the least greatest being put on the left and \n\tthe greatest on the right",
                "The median of these 3 elements is then selected as the pivot point",
                "Then i (leftmost) and j (rightmost) are set to the left and right of the collection",
                "i is then incremented until it finds an element greater than the pivot where it will then stop",
                "j is then decremented until it finds an element less than the pivot where it will then stop",
                "The elements at i and j are swapped with one another",
                "This continues until i >= j where the stopping points of i and j are used to recursively \n\tdivide the partion size",
                "This process repeats itself until the minimum size for a sub-collection is reached",
                "Then Insertion Sort is used to sort the now 'almost' sorted collection",
            };
        }
        protected override void ViewDescription() => desc(bst: "nlogn", wst: "n^2", avg: "nlogn");

        protected override void ASCIIart()
        {
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine(@"
            =======================================================
             __              _      _                     _    __  
            / /   __ _ _   _(_) ___| | __  ___  ___  _ __| |_  \ \ 
           / /   / _` | | | | |/ __| |/ / / __|/ _ \| '__| __|  \ \
           \ \  | (_| | |_| | | (__|   <  \__ \ (_) | |  | |_   / /
            \_\  \__, |\__,_|_|\___|_|\_\ |___/\___/|_|   \__| /_/ 
                    |_|      
            =======================================================
            ");
            ResetColor();
        }
    }
    // merge sort - dark blue
    public class MergeSort : AlgoInfo
    {
        public MergeSort() : base() => this.setInfo();

        protected override void setInfo()
        {
            this.title = "Merge Sort";
            this.bigO = "O(nlogn)";
            this.steps = new string[]
            {
                "The algorithm repeatedly divides the collection into halves until the collection is of size 1",
                "Once the collection has been divided into the smallest possible sub arrays the 'merge' begins",
                "The merging involves comparing two elements of a smaller sub-array and merging them into\n\t a larger sorted array",
                "This process is repeated acrosss multiple recursive calls gradualy building up the new sorted collection",
            };
            this.description = @"

            Merge sort is a consistently efficient general purpose comparison-based sorting algorithm
            that similar to Quick Sort utilizes a divide and conquer strategy to sort the collection.
            The algorithm divides the collection into halves until the collection is of size 1 and then
            merges these sub-collections in order. 

            No matter the collection inputted merge sort will always operate in O(nlogn) time complexity
            making it a consistent and reliable sorting algorithm for large data sets.

            ";
            this.WorstCaseInput = new List<int> { 0, 0, 0 };
            this.explainWorst = @"not applicable in this case as no matter the input size the time complexity 
            will always be the same as nlogn traversals occur no matter the collection order";
            this.Sorter = Sort.MergeSort;
        }

        protected override void ViewDescription() => desc(bst: "nlogn", wst: "nlogn", avg: "nlogn");

        protected override void ASCIIart()
        {
            ForegroundColor = ConsoleColor.DarkBlue;
            WriteLine(@"
            =============================================================
             __                                                 _    __   
            / /  _ __ ___   ___ _ __ __ _  ___   ___  ___  _ __| |_  \ \  
           / /  | '_ ` _ \ / _ \ '__/ _` |/ _ \ / __|/ _ \| '__| __|  \ \ 
           \ \  | | | | | |  __/ | | (_| |  __/ \__ \ (_) | |  | |_   / / 
            \_\ |_| |_| |_|\___|_|  \__, |\___| |___/\___/|_|   \__| /_/  
                                    |___/                                 
            =============================================================
            ");
            ResetColor();
        }
    }
    // heap sort - dark red
    public class HeapSort : AlgoInfo
    {
        public HeapSort() : base() => this.setInfo();

        protected override void setInfo()
        {
            this.title = "Heap Sort";
            this.bigO = "O(nlogn)";
            this.description = @"

            Heap Sort is a comparison-based in-place sorting algorithm that utilizes a MAX binary heap 
            to sort a collection. The algorithm works by first building a max heap from the collection and then
            repeatedly extracting the maximum element from the heap at the root and places it at the end 
            of the collection.
            
            The algorithim operates in constant space complexity when optimized however it is not a stable
            sorting algorithm because it does not maintain the relative order of items with equal keys. 
            Despite its promising time complexity, Heap Sort is not suitable for smaller data sets
            due to it's overhead. However, overall it is an efficient sorting algorithm to consider.

            ";
            this.steps = new string[]
            {
                "The algorithm first builds a max heap from the collection",
                "Then the algorithm repeatedly extracts the maximum element from the heap \n\tand places it at the end of the collection",
                "This process is repeated until the collection is sorted"
            };
            this.WorstCaseInput = new List<int> { 0, 0, 0 };
            this.explainWorst = @"not applicable in this case as no matter the input size the time 
            complexity will always require nlogn traversals no matter the collection order";
            this.Sorter = Sort.Heapsort;
        }
        protected override void ViewDescription() => desc(bst: "nlogn", wst: "nlogn", avg: "nlogn");
        protected override void ASCIIart()
        {
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine(@"
            =============================================================
               __  _                                       _    __   
              / / | |__   ___  __ _ _ __    ___  ___  _ __| |_  \ \  
             / /  | '_ \ / _ \/ _` | '_ \  / __|/ _ \| '__| __|  \ \ 
             \ \  | | | |  __/ (_| | |_) | \__ \ (_) | |  | |_   / / 
              \_\ |_| |_|\___|\__,_| .__/  |___/\___/|_|   \__| /_/  
                                   |_|                               
            ============================================================             
            ");
            ResetColor();
        }
    }


    // IMPLEMENTATION NOTES 

    //protected string title; // name of algo 

    //protected string bigO; // time complexity

    //protected string description; // description of the algorithm

    //protected string[] steps; // steps of the algorithm

    //protected List<int> WorstCaseInput = new List<int>(); // worst case input for the algorithm

    //protected Action<List<int>> Sort; // sorting method

    //protected string explainWorst; // explaination of the type of worst case input

    // overrides => setInfo (ctor) , ASCIIart (custom art), ViewDescription (set avg, best and wrst case)
}