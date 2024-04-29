using System;
using System.Collections.Generic;

namespace _3400_DSA_Prep.Practice
{
    public class AVL<T> where T : IComparable<T>
    {
        public class Node  // shown in class
        {
            public T Data { get; set; }
            public Node Left; // { get; set; }
            public Node Right; // { get; set; }
            public Node(T d = default, Node leftnode = null, Node rightnode = null, int aHeight = 0)
            {
                Data = d;
                Left = leftnode;
                Right = rightnode;
                Height = aHeight;
            }
            private int height;
            public int Height
            {
                get { return height; }
                set
                {
                    if (value >= 0)
                        height = value;
                    else
                        throw new ApplicationException("TreeNode height can't be < 0");
                }
            }

            public override string ToString() => Data.ToString();
        }

        private Node root;

        public T rootData
        {
            get
            {
                if (root == null)
                {
                    return default;
                }
                return root.Data;
            }
        }

        public AVL() => root = null;

        public void Clear() => root = null;

        public bool IsEmpty() => root == null;
        /// <summary>
        /// Returns the Height of a Node, if null returns -1
        /// </summary>
        private int GetHeight(Node ptr)
        {
            if (ptr == null)
            {
                return -1;
            }
            return ptr.Height;
        }

        public void Insert(T newItem) => root = Insert(newItem, root);
        private Node Insert(T newItem, Node pTmp)
        {
            if (pTmp == null)
            {
                return new Node(newItem, null, null);
            }
            else if (newItem.CompareTo(pTmp.Data) < 0) // newItem < pTmp.Data --> go Left
            {
                pTmp.Left = Insert(newItem, pTmp.Left);
                if ((GetHeight(pTmp.Left) - GetHeight(pTmp.Right)) == 2)
                {
                    if (newItem.CompareTo(pTmp.Left.Data) < 0)
                    {
                        pTmp = RotateLeftChild(pTmp);
                    }
                    else
                    {
                        pTmp = doubleLeftChild(pTmp);
                    }
                }

            }
            else if (newItem.CompareTo(pTmp.Data) > 0) // newItem > pTmp.Data --> go right
            {
                pTmp.Right = Insert(newItem, pTmp.Right);
                if ((GetHeight(pTmp.Right) - GetHeight(pTmp.Left)) == 2)
                {
                    if (newItem.CompareTo(pTmp.Right.Data) > 0)
                        pTmp = rotateRightChild(pTmp);

                    else
                        pTmp = doubleRightChild(pTmp);
                }
            }
            else   // Duplicate  
                throw new ApplicationException("Tree did not insert " + newItem + " since an item with that value is already in the tree");

            pTmp.Height = Math.Max(GetHeight(pTmp.Left), GetHeight(pTmp.Right)) + 1;
            return pTmp;
        }

        /*
         *   Before                 After
         *   pTop -->   *             *  <-- pLeft
         *             /             / \
         *   PLeft--> *             *   * <-- pTop 
         *           /
         *          *
         */
        private Node RotateLeftChild(Node pTop)
        {
            Console.WriteLine("Rotating Left Child -> " + pTop.Data);
            Node pLeft = pTop.Left;
            pTop.Left = pLeft.Right;
            pLeft.Right = pTop;

            // update heights
            pTop.Height = Math.Max(GetHeight(pTop.Left), GetHeight(pTop.Right)) + 1;
            pLeft.Height = Math.Max(GetHeight(pLeft.Left), GetHeight(pTop)) + 1;

            return pLeft;  // attached to caller as the new top of this subtree
        }
        /*
       *   Before             After
       *     pTop --> *                  *  <-- pRight
       *               \                / \
       *      pRight--> *     pTop --> *   * 
       *                 \
       *                  *
       */

        private Node rotateRightChild(Node pTop)
        {
            Console.WriteLine("Right Child Rotate -> " + pTop.Data);
            Node pRight = pTop.Right;
            pTop.Right = pRight.Left;
            pRight.Left = pTop;

            // update heights
            pTop.Height = Math.Max(GetHeight(pTop.Left), GetHeight(pTop.Right)) + 1;
            pRight.Height = Math.Max(GetHeight(pRight.Left), GetHeight(pTop)) + 1;

            return pRight; // attached to caller as the new top of this subtree
        }

        private Node doubleLeftChild(Node pTop)
        {
            Console.WriteLine($"Double Left Rotate on {pTop.Data}");
            pTop.Left = rotateRightChild(pTop.Left);
            return RotateLeftChild(pTop);
        }

        private Node doubleRightChild(Node pTop)
        {
            Console.WriteLine("Rotating Right Child To Left-> " + pTop.Right.Data);
            pTop.Right = RotateLeftChild(pTop.Right);
            return rotateRightChild(pTop);
        }

        public T Find(T value) => Find(value, root);
        private T Find(T value, Node pTmp)
        {
            if (pTmp == null)
                throw new ApplicationException("BinSearchTree could not find " + value);   // Item not found
            else if (value.CompareTo(pTmp.Data) < 0) // value < pTmp.Data
                return Find(value, pTmp.Left);      // search left subtree
            else if (value.CompareTo(pTmp.Data) > 0) // value > pTmp.Data
                return Find(value, pTmp.Right);     // search right subtree
            else
                return pTmp.Data;               // Found it
        }

        public bool TryFind(ref T value)
        {
            Node pTmp = root;
            int result;
            while (pTmp != null)
            {
                result = value.CompareTo(pTmp.Data);
                if (result == 0)
                {
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
        /// Returns the minimum value in the tree (i.e leftmost node)
        /// </summary>
        public T FindMin()
        {
            if (root == null)
                throw new ApplicationException("FindMin called on empty BinSearchTree");
            else
                return FindMin(root);
        }
        private T FindMin(Node pTmp)
        {
            if (pTmp.Left == null)
                return pTmp.Data;
            else
                return FindMin(pTmp.Left);
        }

        /// <summary>
        /// Returns the maximum value in the tree (i.e rightmost node)
        /// </summary>
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
        public void Remove(T value) => Remove(value, ref root);
        private void Remove(T value, ref Node ptr)
        {
            if (ptr == null)
                throw new ApplicationException("BinSearchTree could not remove " + value);   // Item not found
            else if (value.CompareTo(ptr.Data) < 0) // value < pTmp.Data, check left subtree
            {
                Remove(value, ref ptr.Left);  // similar to BST's find and remove method
                if (SubtreeBalance(ptr) <= -2) // negative balance means heavy on right side
                {
                    if (SubtreeBalance(ptr.Right) <= 0) // children in straight line
                    {
                        ptr = rotateRightChild(ptr); //  rotate middle up to balance   
                    }
                    else
                        ptr = doubleRightChild(ptr);  // children in zig patter - needs double rotate to balance
                }
            }
            else if (value.CompareTo(ptr.Data) > 0) // value > pTmp.Data, check right subtree
            {
                Remove(value, ref ptr.Right);
                if (SubtreeBalance(ptr) >= 2)
                {
                    if (SubtreeBalance(ptr.Left) >= 0)
                        ptr = RotateLeftChild(ptr);

                    else
                        ptr = doubleLeftChild(ptr);
                }
            }
            else if (ptr.Left != null && ptr.Right != null) // Two children
            {
                ptr.Data = FindMin(ptr.Right);
                Remove(ptr.Data, ref ptr.Right);
                if (SubtreeBalance(ptr) == 2)//rebalancing
                {
                    if (SubtreeBalance(ptr.Left) >= 0)
                    {
                        ptr = RotateLeftChild(ptr);
                    }
                    else
                    {
                        ptr = doubleLeftChild(ptr);
                    }
                }
            }
            else
            {
                // replace with one or no child
                // ptr = (ptr.Left != null) ? ptr.Left : ptr.Right;
                if (ptr.Left != null)
                {
                    ptr = ptr.Left;
                }
                else
                {
                    ptr = ptr.Right;
                }
            }


        }

        /// <summary>
        /// GetBalanceFactor 
        /// 
        /// Updates the height of Nodes in Subtree and 
        /// then gets the Balance Factor of a Node
        /// 
        /// 1) If a node is null, the balance factor is 0
        /// 
        /// 2) If a node has no children, the balance factor is 0
        /// 
        /// 3) If the left node is null, the balance factor is negative 
        ///    since => bf = Left.Height - Right.Height & left is null meaning its 0
        ///    so we return the right child nodes height as negative number
        /// 
        /// 4) If the right node is null, the balance factor is the left nodes
        ///    height since => bf = Left.Height - Right.Height ( right is 0 )
        /// 
        /// 5) If the node has both children, the balance factor is the difference of
        ///    the left and right childrens height property
        ///    
        /// </summary>
        private int SubtreeBalance(Node ptr)
        {
            // Recalculate the height of subtree nodes
            UpdateHeight(ptr.Left);
            UpdateHeight(ptr.Right);

            // Case 1 - Null height => 0
            if (ptr == null)
                return 0;

            // Case 2 - No Child Nodes 
            else if (ptr.Left == null && ptr.Right == null)
                return 0;

            // Case 3 - No Left Child, right side heavy
            else if (ptr.Left == null)
                return -(ptr.Right.Height + 1);    // right side heavy represented by negative number

            // Case 4 - No Right Child, left side heavy
            else if (ptr.Right == null)
                return ptr.Left.Height + 1;

            // Case 5 - Two Children Nodes
            else
                return ptr.Left.Height - ptr.Right.Height;
        }

        private int UpdateHeight(Node ptr)
        {
            int height = -1;
            if (ptr != null)
            {
                int left = UpdateHeight(ptr.Left);
                int right = UpdateHeight(ptr.Right);
                height = Math.Max(left, right) + 1;
                ptr.Height = height;
            }
            return height;
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

