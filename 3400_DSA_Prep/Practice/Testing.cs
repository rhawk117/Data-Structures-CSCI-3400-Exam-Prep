using _3400_Exam_Prep.Practice;
using _3400_Exam1_Prep.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3400_DSA_Prep.Practice
{
    public static class Testing
    {
        // Use this class to test methods you write while practicing 


    }


    // use this to generate test cases
    public static class Generator
    {

        public static OurList<int> GenerateLinkedList(int[] thingsToAdd)
        {
            var list = new OurList<int>();
            for (int i = 0; i < thingsToAdd.Length; i++)
            {
                list.AddFirst(thingsToAdd[i]);
            }
            return list;
        }

        public static CircularQueue<int> GenerateCircularQueue(int[] thingsToAdd)
        {
            var queue = new CircularQueue<int>(thingsToAdd.Length);
            for (int i = 0; i < thingsToAdd.Length; i++)
            {
                queue.Enqueue(thingsToAdd[i]);
            }
            return queue;
        }

        public static OurStack<int> GenerateStack(int[] thingsToAdd)
        {
            var stack = new OurStack<int>();
            for (int i = 0; i < thingsToAdd.Length; i++)
            {
                stack.Push(thingsToAdd[i]);
            }
            return stack;
        }

        public static PriorQ<int, int> GeneratePrioQ(int[] thingsToAdd)
        {
            var pq = new PriorQ<int, int>();
            for (int i = 0; i < thingsToAdd.Length; i++)
            {
                pq.Add(thingsToAdd[i], thingsToAdd[i]);
            }
            return pq;
        }

        public static Dict<int, int> GenerateDictionary(int[] keys, int[] values = null)
        {

            if (values == null)
            {
                values = new int[keys.Length];
                for (int i = 0; i < keys.Length; i++)
                {
                    values[i] = i;
                }
            }
            else if (keys.Length != values.Length)
            {
                throw new ArgumentException("Keys and Values must be the same length");
            }

            var d = new Dict<int, int>();
            for (int i = 0; i < keys.Length; i++)
            {
                d.Add(keys[i], values[i]);
            }
            return d;
        }

        public static BST<int> GenerateBST(int[] thingsToAdd)
        {
            if (thingsToAdd.ToHashSet().Count != thingsToAdd.Length)
            {
                throw new ArgumentException("No duplicates allowed in a BST");
            }
            var d = new BST<int>();
            for (int i = 0; i < thingsToAdd.Length; i++)
            {
                d.Insert(thingsToAdd[i]);
            }
            return d;
        }

        public static AVL<int> GenerateAVL(int[] thingsToAdd)
        {
            if (thingsToAdd.ToHashSet().Count != thingsToAdd.Length)
            {
                throw new ArgumentException("No duplicates allowed in a BST");
            }
            var d = new AVL<int>();
            for (int i = 0; i < thingsToAdd.Length; i++)
            {
                d.Insert(thingsToAdd[i]);
            }
            return d;
        }



    }
}
