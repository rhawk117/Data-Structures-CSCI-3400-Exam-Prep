// Linked List
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3400_Exam1_Prep
{
    public class SinglyLinkedList<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
            public Node(T val = default, Node ptr = null)
            {
                this.Data = val;
                this.Next = ptr;
            }
            public override string ToString()
            {
                string nxt = " -> ";
                if (Next == null)
                    nxt = "NULL";
                return $" | {Data} | {nxt}";
            }
        }

        private Node head;

        /// <summary> Resets the linked list by setting head to null </summary>
        public void Reset() => head = null;

        public SinglyLinkedList() => Reset();

        /// <summary> a linked list empty when the head node is null </summary>
        public bool IsEmpty() => (head == null);

        /// <summary>
        /// Adds a node to the front of the linked list
        /// by reassigning head to the new node pointing 
        /// to the previous head 
        /// </summary>

        public void AddFirst(T val) => head = new Node(val, head);

        /// <summary>
        /// Adds a node to the end of the linked list 
        /// by hopping down the list until reaching the 
        /// end of the data where .Next is null
        /// </summary>
        public void Append(T val)
        {
            if (IsEmpty()) // head == null
            {
                AddFirst(val);
            }
            else
            {
                Node ptr = head;
                while (ptr.Next != null)
                {
                    ptr = ptr.Next;
                }
                ptr.Next = new Node(val, null);
            }
        }
        /// <summary>
        /// Takes an Index and the value we want to insert.
        /// When the list is empty and the index is not 0 we can 
        /// return false and if it is 0 we can reassign our head to
        /// point to the node of the value we want to insert.
        /// In any other case we'll stop at the Node at index before 
        /// we want to insert and reassign it's .Next property to point
        /// to the Node we want to insert
        /// </summary>
        public bool AddAt(uint index, T val)
        {
            if (IsEmpty() && index != 0)
            {
                return false;
            }
            else if (index == 0)
            {
                head = new Node(val, head);
                return true;
            }

            Node ptr = head;
            uint counter = 0;
            while (counter < index - 1)
            {
                if (ptr == null) return false;
                counter++;
                ptr = ptr.Next;
            }
            ptr.Next = new Node(val, ptr.Next);
            return true;
        }

        /// <summary>
        /// Moves the heads reference over one if the list 
        /// isn't empty
        /// </summary>
        public void RemoveFirst()
        {
            if (IsEmpty()) return;

            head = head.Next;
        }

        /// <summary>
        /// If we only have one node we will just call remove first
        /// otherwise we hop to the Node before the last and set it's
        /// pointer to null
        /// </summary>
        public void RemoveLast()
        {
            if (IsEmpty()) return;

            else if (head.Next == null) RemoveFirst();

            else
            {
                Node ptr = head;
                while (ptr.Next.Next != null)
                {
                    ptr = ptr.Next;
                }
                ptr.Next = null;
            }
        }

        /// <summary>
        /// Removes the Node with the value of the parameter,
        /// returns true if a Node with the value is found and removed
        /// false otherwise 
        /// </summary>
        public bool Remove(T val)
        {
            if (IsEmpty())
            {
                return false;
            }
            else if (head.Data.Equals(val))
            {
                head = head.Next;
                return true;
            }
            else
            {
                Node ptr = head;
                while (ptr.Next != null)
                {
                    if (ptr.Next.Data.Equals(val))
                    {
                        ptr.Next = ptr.Next.Next;
                        return true;
                    }
                    ptr = ptr.Next;
                }
                return false;
            }
        }

        /// <summary> 
        /// iterates and counts each node, property
        /// uses uint since count will always be positive 
        /// </summary>
        public uint Count
        {
            get
            {
                uint count = 0;
                Node ptr = head;
                while (ptr != null)
                {
                    count++;
                    ptr = ptr.Next;
                }
                return count;
            }
        }
        /// <summary> public contains which makes recursive call to private method </summary>
        public bool Contains(T val) => _Contains(val, head);
        private bool _Contains(T val, Node ptr)
        {
            if (ptr == null) return false;

            else if (ptr.Data.Equals(val)) return true;

            else return _Contains(val, ptr.Next);
        }

        /// <summary>
        /// Returns a string Visually representing the Linked List 
        /// </summary>
        public override string ToString()
        {
            if (IsEmpty())
                return "| EMPTY |";
            StringBuilder sb = new StringBuilder();
            Node ptr = head;
            sb.Append("| HEAD | ->");
            while (ptr != null)
            {
                sb.Append(ptr.ToString());
                ptr = ptr.Next;
            }
            return sb.ToString();
        }


        // PRACTICE PROBLEMS - Do not use any class methods or properties


        // 1. Make a method that Inserts the contents of an array at the 
        // specified index. 

        public void InsertArrayAt(uint index, T[] array)
        {
            if (array.Length == 0 || head == null && index != 0)
                return;

            else if (index == 0)
            {
                _insertArray(head, array);
            }

            else
            {
                Node ptr = head;
                int count = 0;
                while (count < index - 1)
                {
                    if (ptr == null)
                        throw new ArgumentException("Index provided exceeds list length!");

                    ptr = ptr.Next;
                    count++;
                }
                _insertArray(ptr.Next, array);
            }
        }
        private void _insertArray(Node ptr, T[] array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                ptr = new Node(array[i], ptr);
            }
        }



        //2. Make a method that inserts another
        //   linked list at the "middle" of this one
        public void InsertAtMiddle(SinglyLinkedList<T> Other)
        {
            if (head == null || Other.head == null)
                return;

            Node Fast = head, Middle = head;

            while (Fast != null && Fast.Next != null)
            {
                Fast = Fast.Next.Next;
                Middle = Middle.Next;
            }

            Node otherPtr = Other.head;

            while (otherPtr.Next != null)
            {
                otherPtr = otherPtr.Next;
            }

            otherPtr.Next = Middle.Next;
            Middle.Next = Other.head;
        }

        // 3. Make a method that returns the index of the first 
        // occurence of the parameter. If no nodes with the value of
        // the parameter exist in the list the method should return 
        // -1.

        // 3a => Non-Recursive
        public int FirstOccurrence(T val)
        {
            if (head == null) return -1;

            Node ptr = head;
            int indexOf = 0;
            while (ptr != null)
            {
                if (ptr.Data.Equals(val))
                    return indexOf;

                indexOf++;
                ptr = ptr.Next;
            }
            return -1;
        }
        // 3b => Recursive Imp
        public int RecursiveFirstOccurrence(T val) => RecursiveFirstOccurence(val, head, 0);
        private int RecursiveFirstOccurence(T val, Node ptr, int count = 0)
        {
            if (ptr == null)
            {
                return -1;
            }
            else if (ptr.Data.Equals(val))
            {
                return count;
            }
            else
            {
                return RecursiveFirstOccurence(val, ptr.Next, count);
            }
        }


    }
}
