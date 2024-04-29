// BST
using System;
using System.Collections;
using System.Collections.Generic;

namespace _3400_Exam1_Prep.Practice
{
    public class BST<T> where T : IComparable<T>
    {
        /// <summary>
        /// A priave node class to hide the internal implementation details
        /// </summary>
        public class Node  // shown in class
        {
            /// <summary>
            /// The data for each node
            /// </summary>
            public T Data { get; set; }
            /// <summary>
            /// Pointer to the left child which must be < parent
            /// </summary>
            public Node Left;
            /// <summary>
            /// Pointer to the right child which must be < parent
            /// </summary>
            public Node Right;
            public Node(T d = default, Node leftnode = null, Node rightnode = null)
            {
                Data = d;
                Left = leftnode;
                Right = rightnode;
            }

            /// <summary>
            /// Needed to print the data
            /// </summary>
            /// <returns>a string representing the data</returns>
            public override string ToString()
            {
                return Data.ToString();
            }
        }

        /// <summary>
        /// Points to the root or null if tree is empty
        /// </summary>
        private Node root;

        public BST()
        {
            root = null;
        }
        public void Clear()
        {
            root = null;
        }

        /// <summary>
        /// Returns the min data in the tree. The algorithm is non-recursive
        /// </summary>
        /// <returns></returns>
        public T FindMinNR()
        {
            if (root == null)
                throw new ApplicationException("Can find min on empty tree");
            else
            {
                Node pTmp = root;
                while (pTmp.Left != null)  // keep going left until there is no left child
                    pTmp = pTmp.Left;
                return pTmp.Data;
            }
        }
        /// <summary>
        /// Returns the min data in the tree but uses recursion.
        /// </summary>
        /// <returns></returns>
        public T FindMin()
        {
            if (root == null)
                throw new ApplicationException("FindMin called on empty BinSearchTree");
            else
                return FindMin(root);
        }
        private T FindMin(Node pTmp)
        {
            // if no left child, return the min data in the tree up the recusion chain
            if (pTmp.Left == null)
                return pTmp.Data;
            else
                return FindMin(pTmp.Left);  // this node has a left child, so "go left"
        }

        /// <summary>
        /// public find method
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Find(T value)
        {
            return Find(value, root);
        }
        /// <summary>
        /// private, recursive find method
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pTmp"></param>
        /// <returns>returns the data</returns>
        private T Find(T value, Node pTmp)
        {
            if (pTmp == null)
                throw new ApplicationException("BinSearchTree could not find " + value);   // Item not found
            else if (value.CompareTo(pTmp.Data) < 0) // value < pTmp.Data
                return Find(value, pTmp.Left);		// search left subtree
            else if (value.CompareTo(pTmp.Data) > 0) // value > pTmp.Data
                return Find(value, pTmp.Right); 	// search right subtree
            else
                return pTmp.Data;    			// Found it
        }

        /// <summary>
        /// Non-recursive find that does not throw
        /// </summary>
        /// <param name="value"></param>
        /// <returns>false is value not found, true and value stored in the tree</returns>
        public bool TryFind(ref T value)
        {
            Node pTmp = root;
            int result;
            while (pTmp != null)
            {
                result = value.CompareTo(pTmp.Data);
                if (result == 0)
                {           // found it
                    value = pTmp.Data;
                    return true;
                }
                else if (result < 0)        // value < pTmp.Data, search left subtree
                    pTmp = pTmp.Left;
                else if (result > 0)        // value > pTmp.Data, search right subtree
                    pTmp = pTmp.Right;
            }
            return false;       // didn't find it
        }
        /// <summary>
        /// Insert an item 
        /// </summary>
        /// <param name="newItem"></param>
        public void Insert(T newItem)
        {
            root = Insert(newItem, root);
        }
        /// <summary>
        /// Recursive version
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="pTmp"></param>
        /// <returns></returns>
        /// <remarks>Goes down tree until it falls off
        ///          Then, it creates a new node and passes back to its caller 
        ///          The caller then attaches it</remarks>
        private Node Insert(T newItem, Node pTmp)
        {
            if (pTmp == null)
                return new Node(newItem, null, null);

            else if (newItem.CompareTo(pTmp.Data) < 0) // newItem < pTmp.Data
                pTmp.Left = Insert(newItem, pTmp.Left);

            else if (newItem.CompareTo(pTmp.Data) > 0) // newItem > pTmp.Data 
                pTmp.Right = Insert(newItem, pTmp.Right);

            else   // Duplicate
                throw new ApplicationException("Tree did not insert " + newItem + " since an item with that value is already in the tree");

            return pTmp;
        }

        /// <summary>
        /// Removes a value from the tree
        /// </summary>
        /// <param name="value"></param>

        public void Remove(T value)
        {
            Remove(value, ref root);
        }
        /// <summary>
        /// Recursive remove method
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pTmp"></param>
        private void Remove(T value, ref Node pTmp)
        {
            if (pTmp == null)
                throw new ApplicationException("BinSearchTree could not remove " + value);
            // Item not found
            else if (value.CompareTo(pTmp.Data) < 0) // value < pTmp.Data
                Remove(value, ref pTmp.Left);

            else if (value.CompareTo(pTmp.Data) > 0) // value > pTmp.Data
                Remove(value, ref pTmp.Right);

            else if (pTmp.Left != null && pTmp.Right != null) // Two children, replace with min in right subtree
            {
                pTmp.Data = FindMin(pTmp.Right); // Replace this node with min in right subtree
                Remove(pTmp.Data, ref pTmp.Right); // Remove old min in this node's right subtree
            }
            else
                // pTmp is the left child unless there is no left child, then it becomes the right child
                pTmp = (pTmp.Left != null) ? pTmp.Left : pTmp.Right;
            // if (pTmp.Left != null) pTmp = pTmp.Left else pTmp = pTmp.Right;
        }

        /// <summary>
        /// An insert that doesn't throw
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryInsert(T value)
        {
            if (root == null)  // empty tree, put new value at root
                root = new Node(value, null, null);
            else
            {
                Node pTmp = root, parent;
                while (pTmp != null) // keep going down until you fall off the tree
                {
                    parent = pTmp; // this is a trailing pointer (e.g. drop an anchor)
                    if (value.CompareTo(pTmp.Data) == 0)        // trying to insert duplicate key
                        return false;
                    else if (value.CompareTo(pTmp.Data) < 0)    // value < pTmp.Data, search left subtree
                    {
                        pTmp = pTmp.Left;
                        if (pTmp == null)  // fell off the tree
                            parent.Left = new Node(value, null, null); // use trailing pointer to attach new node
                    }
                    else                                        // value > pTmp.Data, search right subtree
                    {
                        pTmp = pTmp.Right;
                        if (pTmp == null) // fell off the tree
                            parent.Right = new Node(value, null, null); // use trailing pointer to attach new node
                    }
                }
            }
            return true;
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException("BST Contains not implemented");
        }

        public T FindMax()
        {
            return FindMax(root).Data;
        }
        private Node FindMax(Node pTmp)
        {
            if (pTmp == null)
                throw new ApplicationException("FindMax called on empty BinSearchTree");
            if (pTmp.Right == null)
                return pTmp;
            return FindMax(pTmp.Right);
        }


        // Tree Printer Class / Visualization
        public void Prints()
        {
            try
            {
                TreePrinter.Print(root);
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"

                An Exception was thrown in the AVL Tree Prints Method 
                which has a tendancy to throw randomly. It works great
                when it does work however it isn't perfect :/

                Your changes to tree have occured if you inserted
                however if you are removing, it likely did not.
                
                I apologize for the inconvience and I'm working to 
                fix the issue.

                ");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("[ Press ENTER to Continue.. ]");
                Console.ReadLine();
            }
        }
        public void Prints(Node subRoot) => TreePrinter.Print(subRoot);


        public bool IsEmpty => root == null;
        public static class TreePrinter
        {
            private class NodeInfo
            {
                public Node node;
                public string Text;
                public int StartPos;
                public int Size { get { return Text.Length; } }
                public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }

                public NodeInfo Parent, Left, Right;
            }

            public static void Print(Node root, int topMargin = 2, int leftMargin = 2)
            {
                if (root == null) return;

                int rootTop = 0;
                int consoleHeight = Console.WindowHeight;
                int consoleWidth = Console.WindowWidth;

                var last = new List<NodeInfo>();
                var next = root;
                for (int level = 0; next != null; level++)
                {
                    var item = new NodeInfo { node = next, Text = next.Data.ToString() };
                    if (level < last.Count)
                    {
                        item.StartPos = last[level].EndPos + 1;
                        last[level] = item;
                    }
                    else
                    {
                        item.StartPos = leftMargin;
                        last.Add(item);
                    }
                    if (level > 0)
                    {
                        item.Parent = last[level - 1];
                        if (next == item.Parent.node.Left)
                        {
                            item.Parent.Left = item;
                            item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                        }
                        else
                        {
                            item.Parent.Right = item;
                            item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                        }
                    }
                    next = next.Left ?? next.Right;
                    for (; next == null; item = item.Parent)
                    {
                        int currentTop = rootTop + 2 * level;
                        if (currentTop < consoleHeight)
                        {
                            Print(item, currentTop);
                        }
                        if (--level < 0) break;
                        if (item == item.Parent.Left)
                        {
                            item.Parent.StartPos = item.EndPos;
                            next = item.Parent.node.Right;
                        }
                        else
                        {
                            if (item.Parent.Left == null)
                                item.Parent.EndPos = item.StartPos;
                            else
                                item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                        }
                    }
                }

                Console.SetCursorPosition(0, Math.Min(rootTop + 2 * last.Count - 1, consoleHeight - 1));
            }

            private static void Print(NodeInfo item, int top)
            {
                SwapColors();
                Print(item.Text, top, item.StartPos);
                SwapColors();
                if (item.Left != null)
                    PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
                if (item.Right != null)
                    PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
            }

            private static void PrintLink(int top, string start, string end, int startPos, int endPos)
            {
                Print(start, top, startPos);
                Print("─", top, startPos + 1, endPos);
                Print(end, top, endPos);
            }

            private static void Print(string s, int top, int left, int right = -1)
            {
                if (top >= 0 && top < Console.WindowHeight)
                {
                    Console.SetCursorPosition(left, top);
                    if (right < 0) right = left + s.Length;
                    while (Console.CursorLeft < right && Console.CursorLeft < Console.WindowWidth) Console.Write(s);
                }
            }

            private static void SwapColors()
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = Console.BackgroundColor;
                Console.BackgroundColor = color;
            }
        }
    }
}

