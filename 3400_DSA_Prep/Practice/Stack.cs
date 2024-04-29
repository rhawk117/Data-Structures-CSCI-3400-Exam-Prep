// Stack
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3400_Exam_Prep.Practice
{
    public class OurStack<T>
    {
        /// <summary>
        /// Represents a node in the stack
        /// </summary>
        /// <remarks>This node cannot be used outside of the Stack class. The user of the class passes data into the stack but not nodes.</remarks>
        private class Node
        {
            /// <summary>  Data held by the node  </summary>
            public T Data { get; set; }
            /// <summary>
            /// Points to next node in the stack or 
            /// null if it is last node in the stack
            /// </summary>
            public Node Next { get; set; }
            public Node(T d = default(T), Node node = null)
            {
                Data = d;
                Next = node;
            }
            public override string ToString()
            {
                return $"| {Data} |";
            }
        }
        /// <summary>
        /// Points to the top node in the stack or null if the stack is empty
        /// </summary>
        private Node top;

        /// <summary>
        /// Constructor that creates an empty stack
        /// </summary>
        public OurStack()
        {
            top = null;
        }

        /// <summary>
        /// Make the stack empty (e.g. clear the contents)
        /// </summary>
        public void Clear()
        {
            top = null;
        }

        /// <summary>
        /// Since top is private, the user of class needs a way to tell if the stack is empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return top == null;
        }

        /// <summary>
        /// Inserts an item on top of the stack
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            top = new Node(value, top);
        }

        /// <summary>
        /// Removes and returns the item on the top of the stack
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (IsEmpty() == true)
                throw new ApplicationException("Error: can't pop an empty stack");

            T removedData = top.Data;
            top = top.Next;
            return removedData;
        }

        /// <summary>
        /// Returns the item on the top of the stack without reomving it
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (IsEmpty() == true)
                throw new ApplicationException("Error: can't peek at an empty stack");
            return top.Data;
        }

        /// <summary>
        /// Returns the number of items in a stack
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0;
                Node pTmp = top;
                while (pTmp != null)
                {
                    count++;
                    pTmp = pTmp.Next;
                }
                return count;
            }
        }

        /// <summary>
        /// Returns a string with every item. Each item's ToString() method is used.
        /// </summary>
        /// <returns>a string</returns>
        public override string ToString()
        {
            Node ptr = top;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"< TOP OF STACK >\n-------");

            while (ptr != null)
            {
                sb.AppendLine($"{ptr}");
                sb.AppendLine($"----------");
                ptr = ptr.Next;
            }
            return sb.ToString();
        }

    }
}
