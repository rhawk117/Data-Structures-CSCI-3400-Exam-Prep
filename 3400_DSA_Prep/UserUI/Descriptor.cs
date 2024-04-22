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
            this.title = nameOf;
        }

        protected virtual void setComponents()
        {

        }

        private void renderDescription()
        {
            WriteLine($@"
            ==========================================================================
                                        {title}
            ==========================================================================
               
                {description}
           
            ==========================================================================
                                    [ Common Operations ]
            
            ");
            displayOperations();
        }

        private void displayOperations()
        {
            foreach (var KeyVal in this.commonOperations)
            {
                WriteLine($"\t\t>> {KeyVal.Key} - ({KeyVal.Value})");
            }
        }

        public static void detrDescription()
        {

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

        }

    }








}
