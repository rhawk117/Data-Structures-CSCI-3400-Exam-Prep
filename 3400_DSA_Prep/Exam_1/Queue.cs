// Queue
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3400_Exam1_Prep
{
    public class CircularQueue<T>
    {
        /// <summary>
        /// The front points to the first empty cell
        /// The end points to the last cell with data
        /// The size is the number of items in the queue
        /// </summary>
        public int front, end, size;
        /// <summary>
        /// The array holds the data but the data is from front to end and NOT always starting at array position 0
        /// </summary>
        private T[] myArray;


        /// <summary>
        /// Construct an emtpy queue with a specified size
        /// </summary>
        /// <param name="capacity"></param>
        public CircularQueue(int capacity = 10)
        {
            myArray = new T[capacity];
        }

        /// <summary>
        /// Clears or "removes" the contents of the queue
        /// </summary>
        /// <remarks>Doesn't actually erase anything just makes it inaccessible and write over it later</remarks>
        public void Clear()
        {
            front = 0;
            end = 0;
            size = 0;
        }

        /// <summary>
        /// Since the user can't look at the private variable, we need to provide a way to tell if the queue is empty
        /// </summary>
        /// <returns>Returns true if empty; otherwise returns false</returns>
        public bool IsEmpty()
        {
            return size == 0;
        }

        /// <summary>
        /// Removes and returns the item in the front of the queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            size--;
            T data = myArray[front];
            Increment(ref front);
            return data;
        }
        /// <summary>
        /// Inserts the new item at the end of the queue
        /// </summary>
        /// <param name="newItem"></param>
        public void Enqueue(T newItem)
        {
            if (this.size < myArray.Length)
            {
                myArray[end] = newItem;
                Increment(ref end);
                size++;
            }
            else
                throw new Exception("Queue is full");
        }

        /// <summary>
        /// If the array is full (e.g. size = array.Length) then create a new, larger array and copy the data into it.
        /// </summary>

        public void Resize()
        {
            throw new Exception("Queue Resize is not implemented - you could implement it");
        }


        private void Increment(ref int value)
        {
            if (++value == myArray.Length)
                value = 0;
        }


        /// <summary>
        /// Method jumps in line to the spot specified and 
        /// moves and adjusts the order of the elements queue 
        /// by moving each item up one upon reaching the spot parameter
        /// accordingly. 
        /// </summary>
        /// <param name="spot"></param>
        /// <param name="val"></param>

        public bool FastPass(int spot, T val)
        {
            if (size == myArray.Length || spot < 0 || spot > size)
                return false;

            T prev = val;
            int runner = front;
            for (int counter = 0; counter < size + 1; Increment(ref runner), counter++)
            {
                if (counter >= spot)
                {
                    T temp = myArray[runner];
                    myArray[runner] = prev;
                    prev = temp;
                }
            }
            Increment(ref end);
            size++;
            return true;
        }

        public void DisplayAsArr()
        {
            Console.WriteLine("[i] Queue contents:");
            int currentIndex = front;
            int counter = 0;
            for (; counter < size; Increment(ref currentIndex), counter++)
            {
                Console.Write($" {myArray[currentIndex]} |");
            }
            Console.Write("< END >");
        }

        public void DisplayByOrder()
        {
            Console.WriteLine("\t\t[i] Queue Contents [i]");
            Console.WriteLine("*--------------------*");
            for (int i = front; i < size + 1; i++)
            {
                string prefix = string.Empty;
                if (i == front)
                {
                    prefix = "< front >";
                }
                if (i == end)
                {
                    prefix = "< end >";
                }
                Console.WriteLine($"| #{i} | {myArray[i]} | {prefix}");
                Console.WriteLine("*--------------------*");
            }
        }

        private void Decrement(ref int count)
        {
            if (--count == -1)
                count = myArray.Length - 1;
        }


        public void Remove(T val)
        {
            if (size == 0) return;
            else if (myArray[front].Equals(val))
                Increment(ref front);

            bool valFound = false;
            int runner = front;
            for (int i = 0; i < size; i++)
            {
                int tmp = runner;
                if (myArray[runner].Equals(val))
                    valFound = true;

                if (valFound)
                {
                    Increment(ref tmp);
                    myArray[runner] = myArray[tmp];
                }
                Increment(ref runner);

            }
            if (valFound)
            {
                Decrement(ref end);
                size--;
            }
        }


        public void RemoveNth(uint index)
        {
            if (index > size)
            {
                return;
            }
            int spot = front;
            for (int i = 0; i < index; i++)
            {
                Increment(ref spot);
            }
            int Next = spot;
            Increment(ref Next);
            for (int i = 0; i < size - index; i++)
            {

            }


        }




    }
}
