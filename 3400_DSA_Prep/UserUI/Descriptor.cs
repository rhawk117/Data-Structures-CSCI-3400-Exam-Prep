using System.Collections.Generic;
using static System.Console;



namespace _3400_DSA_Prep.UserUI
{
    public class Descriptor
    {
        protected string description;

        // operand name - time complexity
        protected Dictionary<string, string> commonOperations = new Dictionary<string, string>();

        protected string title;
        public Descriptor(string nameOf)
        {
            title = nameOf;
        }

        protected virtual void setComponents() { }

        public void RenderDescription()
        {
            WriteLine($@"
      ===========================================================================================
                                          {title}
      ===========================================================================================
               
   {description}
           
      ===========================================================================================
                                    [ Common Operations ]
            
            ");
            displayOperations();
            Prompts.enterToContinue();
        }

        private void displayOperations()
        {
            foreach (var KeyVal in this.commonOperations)
            {
                WriteLine($"\t\t>> {KeyVal.Key} - ({KeyVal.Value})");
            }
        }


        // titles
        //- "AVL Tree"
        //- "Binary Search Tree"
        //-"Queue"
        //-"Dictionary"
        //-"Linked List"
        //-"Priority Queue"
        //-"Stack"
        public static Descriptor FindDescriptor(string title)
        {
            title = title.ToLower();
            Descriptor desc = null;
            switch (title)
            {
                case "avl tree":
                    desc = new DescAVL();
                    break;

                case "binary search tree":
                    desc = new DescBST();
                    break;

                case "queue":
                    desc = new DescCircQueue();
                    break;

                case "dictionary":
                    desc = new DescDict();
                    break;

                case "priority queue":
                    desc = new DescPrioQueue();
                    break;

                case "stack":
                    desc = new DescStack();
                    break;

                case "linked list":
                    desc = new DescLink();
                    break;

                default:
                    throw new System.Exception("Invalid Descriptor");
            }
            return desc;
        }
    }
    public class DescAVL : Descriptor
    {
        public DescAVL() : base("AVL Tree")
        {
            setComponents();
        }
        protected override void setComponents()
        {
            this.description = @"

            An Adelson-Velsky and Landis tree is a self-balancing binary search tree that
            aims to fix the degenerate tree problem in binary search trees. A degenerate tree
            occurs when sorted input is inserted into a binary search tree, causing the tree to
            become a linked list. 

            This problem is remediated by maintaining a balance factor for each node in the tree. 
            The balance factor is the height of the right subtree minus the height of the left 
            subtree. If the balance factor is greater than 1 or less than -1 (i.e equal to 2 or -2)
            , the tree is unbalanced and must be rotated to restore balance.
            

            A single rotation occurs when the balance factor of a node is 2 or -2 and the middle node
            of the tree is the subtree moves up. Double Rotations occur when the tree is in a zig-zag
            pattern and the middle node of the tree and two single rotations are needed to restore 
            balance. During rotations, a node will never move more than 2 levels up and after a rotation 
            occurs no side effects should occur as a result meaning no additional rotations will occur.
            ";
            commonOperations = new Dictionary<string, string>
            {
                { "Insertion", "O(logN)" },
                { "Deletion", "O(logN)" },
                { "Search", "O(logN)" },
                { "Single Rotation", "O(1)"},
                { "Double Rotation", "O(1)"}
            };
        }
    }
    public class DescBST : Descriptor
    {
        public DescBST() : base("Binary Search Tree")
        {
            setComponents();
        }
        protected override void setComponents()
        {
            this.description = @"

            A binary search tree is a data structure that allows for logarithimic, insertions, and removals
            operations.The tree is composed of nodes where each node has a left and right child. The
            left child of a node contains a value less than the parent node and the right child contains
            a value greater than the parent node. Similar to a linked list, the end of a Binary Search Tree
            subtree will be denoted by a null value. All trees are considered recursive data structures meaning 
            recursion is the most efficient way of going down the tree.

            The tree can be traversed in various ways such as in-order, pre-order, and post-order. 
            In-order traversal visits the left child, then the parent node, and finally the right child. Pre-order 
            traversal visits the parent node, then the left child, and finally the right child. Post-order traversal 
            visits the left child, then the right child, and finally the parent node. 
            ";

            commonOperations = new Dictionary<string, string>
            {
                { "Insertion", "O(logN)" },
                { "Deletion", "O(logN)" },
                { "Search", "O(logN)" }
            };
        }
    }
    public class DescCircQueue : Descriptor
    {
        public DescCircQueue() : base("Queue")
        {
            setComponents();
        }
        protected override void setComponents()
        {
            this.description = @"
            
            A queue is a linear data structure that follows the First In First Out (FIFO) principle.
            The queue is composed of a front and rear pointer that points to the first and last element
            in the linear collection. The element present at the 'front' pointer is removed upon dequeuing
            and the element present at the 'rear' pointer is the last / most recently added item to the queue.
            The implementation features a circular array meaning that the rear pointer will wrap around to the 
            front of the queue when the end of the array is reached which is acheived via the 'Increment' method.

            
            It is important when working with the 'Circular Queue' to avoid falling into the Gap of Death which occurs
            when you fail to account for the circular nature (i.e don't use Increment(ref num) ).The current size of the 
            queue (i.e number of elements present) is stored in the 'size' attribute and is maintained whenever an action
            is performed on the queue. Since the queue uses an array, the queue does have a fixed size and will throw an
            exception if the queue is full and an element is attempted to be added.
            ";
            commonOperations = new Dictionary<string, string>
            {
                { "Enqueue", "O(1)" },
                { "Dequeue", "O(1)" },
                { "Peek", "O(1)" },
                { "Resize", "O(N)" }
            };
        }
    }
    public class DescDict : Descriptor
    {
        public DescDict() : base("Dictionary")
        {
            setComponents();
        }
        protected override void setComponents()
        {
            this.description = @"
            A dictionary, hash table or associative array is a data structure that utilizes hashing
            to access elements in constant time or O(1). The dictionary contains a hash table composed
            of cells that hold both a key, value and StatusType where the key is hashed to a unique index 
            in the hash table and the value is the data stored at said cell. The StatusType is an enum that is 
            used to denote the status of the cell (i.e Empty, Active, Deleted). When a cell has never been used 
            it will be null and when a cell has been deleted it will be marked as deleted.

            The hashing is achieved via a hash function where -> hash = ([ hash(key) + f(i) ] % table_size)
            however sometimes a key can hash to the same index as another key present in the hash table causing
            a hash collision. To address this issue we use the f(i) function which given a Collision Resolution
            Strategy which will use a Collision Factor to progressively try a new index until no collision occurs to
            place the key in. 


            There are 3 collision resolution strategies we covered in class which are linear probing, quadratic probing
            and double hashing. Linear probing will increment the index by 1 (i++), quadratic probing will exponentiate 
            the collision factor by (i^2) and double hashing will use a secondary hash function to find a new index.
            ";

            commonOperations = new Dictionary<string, string>
            {
                { "Insertion", "O(1)" },
                { "Deletion", "O(1)" },
                { "Search", "O(1)" }
            };
        }
    }
    public class DescLink : Descriptor
    {
        public DescLink() : base("Linked List")
        {
            setComponents();
        }
        protected override void setComponents()
        {
            this.description = @"
            A Singly Linked List are a linear data structure that is composed of nodes where each node
            stores data and a 'next' pointer pointing to the next node in the linked list. The last 
            node in the linked list will have a null .Next pointer which denotes the end of the list. 

            Linked lists are dynamically sized meaning they can grow and shrink as needed making them
            a flexible data structure. However, this comes with the major downside of the collection 
            not using indexes to access elements meaning you must hop down the list to find the desired
            element. This makes the linked list inefficient for searching and accessing elements in the
            middle of the list. Despite this though Linked Lists are foundational data structure which are
            used to implement more complex data structures such as Stacks and Queues.";

            commonOperations = new Dictionary<string, string>
            {
                { "Add First", "O(1)" },
                { "Add Last", "O(N)" },
                { "Remove First", "O(1)" },
                { "Remove Last", "O(n)" },
                { "Search", "O(n)" },
                { "Insertion", "O(n)" },
                { "Deletion", "O(n)" },
                { "Search", "O(n)" }
            };
        }
    }
    public class DescPrioQueue : Descriptor
    {
        public DescPrioQueue() : base("Priority Queue")
        {
            setComponents();
        }
        protected override void setComponents()
        {
            this.description = @"
            
            A Priority Queue is a data structure that allows for the insertion of elements with a
            priority and those with higher priority are dequeued first. The priority queue is implemented
            using a Min Binary Heap which utilizes a 1D array to store elements in the heap. In a Min Heap
            the root node is always the smallest value in the collection and upon a removl or dequeue operation
            the root node is removed and the next minimum element in the heap is moved to the root. 
            
            The left child is stored at position (2 * i) and the right child is stored at position (2 * i + 1)
            where i is the index of the parent node. The parent of a node is stored at position (i / 2) where i is
            the index of the child node. The heap is maintained by 'bubbling up' or 'bubbling down' elements to
            restore the heaps structure property. Bubbling up occurs when a node is inserted and is less than its 
            parent and bubbling down (percolate down) occurs when a node is removed and the heap is restructured
            to maintain the heap structure property. The first index (index 0) better known as the 'Cell of Death'
            in the heap is not used as it breaks the formula for calculating the index of the right and left child
            of a node.

            Priority Queue's have a variety of real world applications such as in Operating Systems for designating
            CPU time to processes, in Dijkstra's Algorithm for finding the shortest path in a graph and sorting algorithms
            such as Heap Sort.
            ";
            this.commonOperations = new Dictionary<string, string>
            {
                { "Insertion", "O(logN)" },
                { "Deletion", "O(logN)" },
                { "Search", "O(N)" },
                { "Percolate Down", "O(logN)" },
                { "Percolate Up", "O(logN)" },
                { "Peek", "O(1)" }
            };
        }

    }
    public class DescStack : Descriptor
    {
        public DescStack() : base("Stack")
        {
            setComponents();
        }
        protected override void setComponents()
        {
            this.description = @"
                
                A stack is a linear data structure that follows the Last In First Out (LIFO) principle and items
                are added and removed from the top of the stack. The stack is composed of a collection of elements
                where the top of the stack is the last element added and the bottom of the stack is the first element
                that was added. The stack is implemented using a singly linked list where each node contains a data 
                value utilizing the AddFirst and RemoveFirst methods to add and remove elements from the stack.
                
                All stack operations operate in constant time or O(1) and the stack itself is a foundational data 
                structure used to implement and tackle several programatic problems. Inserting an element is known
                as 'Push' where the item is pushed to the metaphorical 'top' of the stack or front of the linked list
                and removing an element is known as 'Pop' where the item is removed from the top of the stack. Other 
                implementations involves using a 1D array however the linked list implementation is preferred since 
                linked lists are more dynamic and can grow and shrink as needed.
                ";

            this.commonOperations = new Dictionary<string, string>
            {
                    { "Push" , "O(1)" },
                    { "Pop" , "O(1)" },
                    { "Peek" , "O(1)" }
            };
        }
    }
}
