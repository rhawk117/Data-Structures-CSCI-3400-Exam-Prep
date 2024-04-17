using System;
using System.Collections.Generic;

namespace _3400_DSA_Prep
{
    public static class Sort
    {
        // ================================================================================
        //
        //    Insertion Algorithm
        //
        // ================================================================================
        public static void InsertionSort(List<int> aList)
        {
            int count = 0;
            Console.WriteLine("----------- Insertion Sort -------");
            AlgoUtils.PrintHeader(aList, 0, aList.Count);

            int tmp;
            int hole;
            for (int bar = 1; bar < aList.Count; bar++)
            {
                tmp = aList[bar];
                for (hole = bar; hole > 0 && tmp.CompareTo(aList[hole - 1]) < 0; hole--)
                {
                    count++;
                    aList[hole] = aList[hole - 1];
                }
                aList[hole] = tmp;
            }

            AlgoUtils.Print(aList);
            Console.WriteLine("Count = {0}", count);
        }

        // ================================================================================
        //
        //    Bubble Algorithm
        //
        // ================================================================================
        public static void BubbleSort(List<int> aList)
        {
            int count = 0;
            Console.WriteLine("----------- Bubble Sort --- Green - bubbled to correct spot starting at end");
            AlgoUtils.PrintHeader(aList, 0, aList.Count);
            AlgoUtils.Print(aList);

            for (int i = aList.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < aList.Count - 1; j++)
                {
                    if (aList[j].CompareTo(aList[j + 1]) > 0)
                        Swap(aList, j, j + 1);
                    count++;
                }
                AlgoUtils.printOne(aList, i, 0, i + 1);
                //print(aList, 0, i + 1);
            }

            AlgoUtils.Print(aList);
            Console.WriteLine("Count = {0}", count);
        }

        // ================================================================================
        //
        //    ShellSort Algorithm
        //
        // ================================================================================
        public static void ShellSort(List<int> aList)
        {
            int count = 0;
            Console.WriteLine();
            Console.Write("      ");
            AlgoUtils.PrintHeader(aList, 0, aList.Count);

            int hole;
            int tmp;
            for (int gap = aList.Count / 3 + 1; gap > 0; gap /= 2)	// determines increment sequence
            {
                Console.Write("{0}     ", gap);
                AlgoUtils.Print2(aList, 0, aList.Count);
                for (int next = gap; next < aList.Count; next++) // goes thru array by steps
                {
                    tmp = aList[next];
                    for (hole = next; hole >= gap && tmp.CompareTo(aList[hole - gap]) < 0; hole -= gap) // slides tmp until in place
                    {
                        ++count;
                        aList[hole] = aList[hole - gap];
                    }
                    aList[hole] = tmp;
                }
            }
            Console.WriteLine("Count = {0}", count);
        }

        // gaps must be sorted larger to smaller
        public static void ShellSort(List<int> aList, int[] gaps)
        {
            Console.Write("---- Shell Sort -----");
            int tmp, hole;
            int count = 0;
            Console.WriteLine();
            Console.Write("      ");
            AlgoUtils.PrintHeader(aList, 0, aList.Count);
            Console.Write("      ");
            AlgoUtils.Print(aList);
            // determines increment sequence
            foreach (int gap in gaps)
            {
                Console.Write("{0}     ", gap);
                // goes thru array by steps
                for (int next = gap; next < aList.Count; next++)
                {
                    tmp = aList[next];
                    // slides tmp until in place
                    for (hole = next; hole >= gap && tmp.CompareTo(aList[hole - gap]) < 0; hole -= gap)
                    {
                        ++count;
                        aList[hole] = aList[hole - gap];
                    }
                    aList[hole] = tmp;
                }
                AlgoUtils.printEvery(aList, 0, aList.Count, gap);
            }
            Console.WriteLine("Number of shifts = {0}", count);
        }

        public static void ShellSort(List<int> aList, List<int> IncrementList)
        {
            int tmp;
            int hole;
            int count = 0;

            Console.Write("      ");
            AlgoUtils.PrintHeader(aList, 0, aList.Count);
            Console.Write("      ");
            AlgoUtils.Print2(aList, 0, aList.Count);

            for (int incNumber = IncrementList.Count - 1; incNumber >= 0; incNumber--)
            {
                int gap = IncrementList[incNumber];
                for (int next = gap; next < aList.Count; next++)
                {  		            // goes thru array by steps
                    tmp = aList[next];
                    for (hole = next; hole >= gap &&
                    tmp.CompareTo(aList[hole - gap]) < 0; hole -= gap) // slides tmp until in place 
                    {
                        ++count;
                        aList[hole] = aList[hole - gap];
                    }
                    aList[hole] = tmp;
                    Console.WriteLine("Count = {0}", count);
                }
                Console.Write("{0,3}   ", gap);
                AlgoUtils.Print2(aList, 0, aList.Count);
            }
            Console.WriteLine("Count = {0}", count);
        }

        // ================================================================================
        //
        //    Heapsort Algorithm
        //
        // ================================================================================
        public static void Heapsort(List<int> aList)
        {
            Console.WriteLine(" --- Starting HeapSort ----");
            Heapsort(aList, aList.Count);
        }

        private static int LeftChild(int i) => 2 * i + 1;

        private static void PercDown(List<int> aList, int i, int size)
        {
            int Child;
            int Tmp;

            for (Tmp = aList[i]; LeftChild(i) < size; i = Child)
            {
                Child = LeftChild(i);
                if (Child != size - 1 && aList[Child].CompareTo(aList[Child + 1]) < 0)
                {
                    Child++;
                }
                if (Tmp.CompareTo(aList[Child]) < 0)
                {
                    aList[i] = aList[Child];
                }
                else
                {
                    break;
                }
            }
            aList[i] = Tmp;
        }

        private static void Heapsort(List<int> aList, int N)
        {
            AlgoUtils.PrintHeader(aList, 0, aList.Count);
            AlgoUtils.Print(aList);

            for (int i = N / 2; i >= 0; i--) /* BuildHeap */
            {
                PercDown(aList, i, N);
            }
            Console.WriteLine("-- Max Heap is built --");
            AlgoUtils.Print(aList);
            for (int i = N - 1; i > 0; i--)
            {
                Swap(aList, 0, i); /* DeleteMax */
                PercDown(aList, 0, i);
                AlgoUtils.Print(aList);
            }
        }

        // ================================================================================
        //
        //    QuickSort Algorithm
        //
        // ================================================================================
        public static void QuickSort(List<int> aList)
        {
            // int stopOn = 3
            Console.WriteLine("-------- QuickSort ---------");

            QuickSort(aList, 0, aList.Count - 1, 3);
            Console.WriteLine("[ After QuickSort but before it calls InsertionSort ]");
            AlgoUtils.Print(aList);
            Console.WriteLine();
            InsertionSort(aList);
        }

        private static int MedianOfThree(List<int> aList, int left, int right)
        {
            Console.Write("Medians: Left={0}  Pivot={1}  Right={2}\n", aList[left], aList[(left + right) / 2], aList[right]);
            int center = (left + right) / 2;

            // center < left
            if (aList[center].CompareTo(aList[left]) < 0)
            {
                Swap(aList, left, center); // swap left with center
            }

            // right < left
            if (aList[right].CompareTo(aList[left]) < 0)
            {
                Swap(aList, left, right); // swap left with right
            }

            // right < center
            if (aList[right].CompareTo(aList[center]) < 0)
            {
                Swap(aList, center, right); // swap center with right
            }

            Swap(aList, center, right);
            Console.WriteLine($"Pivot Used -> {aList[right]}");
            return aList[right];
        }
        private static void Swap(List<int> aList, int lhs, int rhs)
        {
            int temp = aList[lhs];
            aList[lhs] = aList[rhs];
            aList[rhs] = temp;
        }
        private static void quickSortHeader(List<int> aList, int left, int right)
        {
            Console.Write("{");
            for (int j = left; j <= right; j++)
            {
                Console.Write("{0}", aList[j]);
                if (j != right)
                    Console.Write(" | ");
            }
            Console.Write("}");
            Console.WriteLine(", {0}, {1}", left, right);


            Console.WriteLine();
        }
        public static void QuickSort(List<int> aList, int left, int right, int stopOn)
        {
            if (Math.Abs(left - right) < stopOn)
            {
                return;
            }

            quickSortHeader(aList, left, right);
            int pivot = MedianOfThree(aList, left, right);
            Console.Write("{0}", new String(' ', left * 4));
            AlgoUtils.Print2(aList, left, right + 1);
            int i = left; //, j = right;
            for (int j = right; i < j;)
            {
                while (aList[++i].CompareTo(pivot) < 0) ;

                while (pivot.CompareTo(aList[--j]) < 0) ;

                if (i < j) Swap(aList, i, j);

                else break;
            }
            Console.WriteLine("[ Before pivot is moved backed... ]");
            AlgoUtils.Print3(aList, left, right + 1, i);
            Swap(aList, i, right);	// Move pivot back
            Console.WriteLine("[ Pivot moved back... ]");
            Console.Write("{0}", new String(' ', left * 4));
            AlgoUtils.Print3(aList, left, right + 1, i);

            QuickSort(aList, left, i - 1, stopOn);	// sort small partition
            QuickSort(aList, i + 1, right, stopOn);	// sort large partition
        }

        // ================================================================================
        //
        //    Selection Sort Algorithm
        //
        // ================================================================================
        public static void SelectionSort(List<int> aList) => SelectionSort(aList, 0, aList.Count - 1);

        private static void SelectionSort(List<int> aList, int low, int high)
        {
            int ptr;
            for (int i = low; i <= high; ++i)
            {
                int min = aList[i];		// smallest element so far
                int min_index = i;		// index of smallest

                for (int j = i + 1; j <= high; ++j)
                {
                    if (aList[j].CompareTo(min) < 0)
                    {
                        min = aList[j];
                        min_index = j;
                    }
                }

                if (i != min_index)
                {
                    ptr = aList[i];
                    aList[i] = min;
                    aList[min_index] = ptr;
                }
            }
        }

        // ================================================================================
        //
        //    Merge Sort Algorithm
        //
        // ================================================================================
        public static void RecMergeSort(List<int> aList) => RecMergeSort(aList, 0, aList.Count);
        private static void RecMergeSort(List<int> array, int start, int end)
        {
            if (end - start <= 1) return;
            int middle = start + (end - start) / 2;

            RecMergeSort(array, start, middle);
            RecMergeSort(array, middle, end);
            Merge(array, start, middle, end);
        }

        public static void MergeSort(List<int> aList)
        {
            AlgoUtils.Print(aList);
            for (int i = 1; i <= aList.Count / 2 + 1; i *= 2)
            {
                for (int j = i; j < aList.Count; j += 2 * i)
                {
                    Merge(aList, j - i, j, Math.Min(j + i, aList.Count));

                }
            }

        }

        private static void Merge(List<int> aList, int start, int middle, int end)
        {
            List<int> merge = new List<int>(end - start);

            for (int j = 0; j < end - start; ++j)
            {
                merge.Add(default(int));
            }

            int lft = 0, rght = 0, i = 0;

            while (lft < (middle - start) && rght < (end - middle))
            {
                if (aList[start + lft].CompareTo(aList[middle + rght]) < 0)
                {
                    merge[i++] = aList[start + lft++];
                }
                else
                {
                    merge[i++] = aList[middle + rght++];
                }
            }

            while (rght < end - middle)
            {
                merge[i++] = aList[middle + rght++];
            }

            while (lft < middle - start)
            {
                merge[i++] = aList[start + lft++];
            }

            for (int k = 0; k < merge.Count; k++)
            {
                aList[start++] = merge[k];
            }
        }
    }
}

