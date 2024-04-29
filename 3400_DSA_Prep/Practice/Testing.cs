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
        // or don't (lol)


        // NOTE TestCase Constructor 
        // Title: Title of the test case
        // ExpectedOutput: The expected output of the test case
        // Collection: The collection to generate and test

        private static TestCase[] GenerateCases()
        {
            // Use this method to generate test cases (e.g)
            TestCase[] cases = new TestCase[]
            {
                new TestCase(
                    title: "Empty Case",
                    expectedOutput: "false",
                    collection: new int[] { }
                ),
                new TestCase(
                    title: "Single Element",
                    expectedOutput: "true",
                    collection: new int[] { 1 }
               ),
                new TestCase("Working Case", "True", new int[] { 1, 2, 3, 4, 5 }),
            };
            return cases;
        }

        public static void RunTests()
        {
            var cases = GenerateCases();
            foreach (var c in cases)
            {
                // replace with the generator for the class your testing
                var collection = Generator.LinkedList(c.Collection);

                var result = collection.Contains(1); // call method your testing 
                Console.WriteLine(c);
                Console.WriteLine($"Actual Output: {result}\n");
            }
        }

    }





    // use this to generate test cases
    public static class Generator
    {

        public static OurList<int> LinkedList(int[] thingsToAdd)
        {
            var list = new OurList<int>();
            for (int i = 0; i < thingsToAdd.Length; i++)
            {
                list.AddFirst(thingsToAdd[i]);
            }
            return list;
        }

        public static CircularQueue<int> CircularQueue(int[] thingsToAdd)
        {
            var queue = new CircularQueue<int>(thingsToAdd.Length);
            for (int i = 0; i < thingsToAdd.Length; i++)
            {
                queue.Enqueue(thingsToAdd[i]);
            }
            return queue;
        }

        public static OurStack<int> Stack(int[] thingsToAdd)
        {
            var stack = new OurStack<int>();
            for (int i = 0; i < thingsToAdd.Length; i++)
            {
                stack.Push(thingsToAdd[i]);
            }
            return stack;
        }

        public static PriorQ<int, int> PrioQ(int[] thingsToAdd)
        {
            var pq = new PriorQ<int, int>();
            for (int i = 0; i < thingsToAdd.Length; i++)
            {
                pq.Add(thingsToAdd[i], thingsToAdd[i]);
            }
            return pq;
        }

        public static Dict<int, int> Dictionary(int[] keys, int[] values = null)
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

        public static BST<int> BST(int[] thingsToAdd)
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

        public static AVL<int> AVL(int[] thingsToAdd)
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

    public class TestCase
    {
        public string Title { get; set; }
        public string ExpectedOutput { get; set; }
        public int[] Collection { get; set; }
        public string For { get; set; }

        public TestCase(string title, string expectedOutput, int[] collection)
        {
            Title = title;
            ExpectedOutput = expectedOutput;
            Collection = collection;
        }

        public override string ToString()
        {
            return $"Case {Title}\nExpected Output: {ExpectedOutput}\nItems: {string.Join(", ", Collection)}";
        }
    }
}
