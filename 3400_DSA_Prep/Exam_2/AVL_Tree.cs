﻿using System;
using System.Collections.Generic;

namespace _3400_DSA_Prep
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

        /// <summary>
        /// Public abstracted method that calls the private method
        /// to perform the pyramid transformation on the tree
        /// </summary>
        public void ToPyramid()
        {
            ToPyramid(root);
            AdjustBalance(ref root);
            UpdateHeight(root);
        }

        /// <summary>
        /// This is the Private method called in the 
        /// public method that tilts nodes with zig zag
        /// node patterns found in "ugly" trees
        /// 
        /// A. Subtree has a left child that has a right child
        /// 
        /// 
        ///     * << SubTreePtr
        ///    /
        ///   * << SubTreePtr.Left
        ///    \
        ///     *
        ///     
        /// B. Subtree has a right child that has a left child
        /// 
        ///     * << SubTreePtr
        ///      \
        ///       * << SubTreePtr.Right
        ///      /
        ///     * 
        ///   
        /// 
        /// </summary>
        /// <param name="subTreePtr"></param>
        /// 

        // btw this solution was my lowest homework grade (heads up) i.e shit didnt work
        private void ToPyramid(Node subTreePtr)
        {
            // when we fall off or a node wont need to be balanced
            if (subTreePtr == null) return;

            Node LeftChild = subTreePtr.Left, RightChild = subTreePtr.Right;
            if (RightChild == null && LeftChild == null) return;

            // A. kinda like <
            if (LeftChild != null && LeftChild.Right != null)
            {
                LeftChild = rotateRightChild(LeftChild);
                subTreePtr.Left = LeftChild;
            }

            // B. kinda like this >
            if (RightChild != null && RightChild.Left != null)
            {
                RightChild = RotateLeftChild(subTreePtr.Right);
                subTreePtr.Right = RightChild;
            }

            ToPyramid(subTreePtr.Left);
            ToPyramid(subTreePtr.Right);
        }

        /// <summary>
        /// 
        /// After shifting the nodes, sometimes the roots 
        /// balance will requiring balancing 
        /// to be performed on the root node.
        /// 
        /// note: the logic for this method is almost identical
        /// from the Remove method. 
        /// 
        /// balance factor = Left.Height - Right.Height
        /// 
        /// - RightChildRotations: when the balance factor is negative (i.e less than -1)
        ///   meaning that the right side is heavy
        ///   
        /// - LeftChildRotations: when the balance factor is positive (i.e greater than 1)
        ///   meaning that the left side is heavy
        /// 
        /// 
        /// </summary>
        /// <param name="prettyRoot"></param>

        private void AdjustBalance(ref Node rPtr)
        {
            if (rPtr == null) return;

            int TreeBalance = SubtreeBalance(rPtr);

            // Right Heavy
            if (TreeBalance < -1)
            {
                if (TreeBalance <= 0)
                {
                    rPtr = rotateRightChild(rPtr);
                }
                else
                {
                    rPtr = doubleRightChild(rPtr);
                }
            }

            // Left Heavy
            else if (TreeBalance > 1)
            {
                if (TreeBalance >= 0)
                {
                    rPtr = RotateLeftChild(rPtr);
                }
                else
                {
                    rPtr = doubleLeftChild(rPtr);
                }
            }
        }
        public bool areEqual(AVL<T> other) => areEqual(other.root, root);
        public bool areEqual(Node oPtr, Node thisPtr)
        {
            // Lazy Check - works 
            if (oPtr == null || thisPtr == null)
            {
                return oPtr == thisPtr; // Check if both are null, if not they are not equal
            }
            else if (!oPtr.Data.Equals(thisPtr.Data))
            {
                return false;
            }
            return areEqual(oPtr.Left, thisPtr.Left) && areEqual(oPtr.Right, thisPtr.Right);
        }

        // Add a method to the OurAVLTree Class that takes in possible data of a node
        // in the AVL Tree. If the Data exists in the AVL Tree print the rest of the subtree
        // from the Node.

        public void PrintDown(T search)
        {
            Node ptr = findTarget(root, search);
            if (ptr == null)
            {
                Console.WriteLine($"Node with value {search} was not found in the AVL...");
                return;
            }
            printDown(ptr);
        }
        private Node findTarget(Node ptr, T search)
        {
            if (ptr == null)
            {
                return null;
            }
            else if (search.CompareTo(ptr.Data) < 0)
            {
                return findTarget(ptr.Left, search);
            }
            else if (search.CompareTo(ptr.Data) > 0)
            {
                return findTarget(ptr.Right, search);
            }
            else
            {
                return ptr; // Found it 
            }
        }

        private void printDown(Node ptr)
        {
            if (ptr == null) return;

            Console.Write($"{ptr.Data}");

            printDown(ptr.Left);
            printDown(ptr.Right);
        }


        // in class solution 

        // Add a method to the OurAVL Tree that returns a lis  t of 
        // Nodes that are 'almost' unbalanced meaning that a rotation
        // will occur soon. 


        // Hint: Almost unbalanced Nodes have a
        // Balance Factor of either 1 or -1. 
        // Use the 'GetHeight' Method to assist

        public List<Node> AlmostUnbalanced()
        {
            List<Node> items = new List<Node>();
            AlmostUnbalanced(items, root);
            return items;
        }
        private void AlmostUnbalanced(List<Node> items, Node cur)
        {
            if (cur == null) return; // base case

            int bf = _balanceFactor(cur);

            if (bf == -1 || bf == 1) items.Add(cur); // node is 'almost' unbalanced

            // recursive case
            AlmostUnbalanced(items, cur.Left);
            AlmostUnbalanced(items, cur.Right);
        }
        private int _balanceFactor(Node cur)
        {
            if (cur == null) return 0;

            return fetchHeight(cur.Left) - fetchHeight(cur.Right);
        }
        private int fetchHeight(Node cur)
        {
            if (cur == null) return 0;

            return cur.Height;
        }

        // Balance String

        public string WeightOf()
        {
            if (root == null)
            {
                return "";
            }
            int left = countSide(root.Left);
            int right = countSide(root.Right);
            string status = "";

            if (left > right)
                status = "Left Heavy";

            else if (right > left)
                status = "Right Heavy";

            else
                status = "Balanced";

            return status;

        }

        private int countSide(Node cur)
        {
            if (cur == null) return 0;

            return 1 + countSide(cur.Left) + countSide(cur.Right);
        }





        public bool IsPerfectlyBalanced()
        {
            return IsSymetric(root.Left, root.Right);
        }
        public bool IsSymetric(Node left, Node right)
        {
            if (left == null || right == null)
            {
                return left == null && right == null;
            }
            else if (left.Height != right.Height)
            {
                return false;
            }
            return IsSymetric(left.Left, right.Right) && IsSymetric(left.Right, right.Left);
        }






        // Add a method to the OurAVLTree 
        // class that checks returns true if
        // the AVL Tree is perfectly balanced.
        // A perfectly balanced AVL Tree only contains nodes
        // that have a balance factor of 0








        public bool isPerfectlyBalanced()
        {
            return perfectBalance(root);
        }
        private bool perfectBalance(Node cur)
        {
            if (cur == null)
            {
                return true;
            }

            if (_balanceFactor(cur) != 0)
            {
                return false;
            }

            return perfectBalance(cur.Left) && perfectBalance(cur.Right);
        }

        // Add a method to the OurAVLTree class that returns the number of
        // leaf nodes on the Tree.




        public void balance()
        {
            root = balance(root);
        }
        private Node balance(Node pTmp)
        {
            if (pTmp == null || pTmp.Height <= 1)
            {
                return pTmp;
            }
            else if (pTmp.Height > 2)
            {
                pTmp.Left = balance(pTmp.Left);
                pTmp.Right = balance(pTmp.Right);
            }
            else if (pTmp.Right.Height == 0 && pTmp.Left.Right != null && pTmp.Left.Left != null)
            {
                pTmp = doubleLeftChild(pTmp);
            }
            else if (pTmp.Left.Height == 0 && pTmp.Right.Left != null && pTmp.Right.Right != null)
            {
                pTmp = doubleRightChild(pTmp);
            }
            return pTmp;
        }

        public void PostOrder()
        {
            Console.WriteLine("[ Performing a post order traversal of the AVL Tree... ]\n");
            postOrder(root);
        }
        // Left Call, Right Call, Print
        private void postOrder(Node ptr)
        {
            if (ptr == null) return;

            postOrder(ptr.Left);
            postOrder(ptr.Right);
            Console.Write($"{ptr.Data}, ");
        }
        public void PreOrder()
        {
            Console.WriteLine("[ Performing a pre order traversal of the AVL Tree.. ]");
            preOrder(root);
        }
        // Print, Left Call, Right Call
        private void preOrder(Node ptr)
        {
            if (ptr == null)
            {
                return;
            }
            Console.Write($"{ptr.Data},");
            preOrder(ptr.Left);
            preOrder(ptr.Right);
        }
        public void InOrder()
        {
            Console.WriteLine("[ Performing in-order traversal of the AVL Tree.. ]");
            inOrder(root);
        }
        private void inOrder(Node ptr)
        {
            if (ptr == null)
            {
                return;
            }
            inOrder(ptr.Left);
            Console.Write($"{ptr.Data}, ");
            inOrder(ptr.Right);
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

