using _3400_Exam1_Prep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _3400_DSA_Prep
{
    public class BSTView : View
    {
        private BinrySearchTree<int> tree;

        public BSTView(BinrySearchTree<int> aTree = null) : base("Binary Search Tree")
        {
            if (aTree == null)
            {
                tree = new BinrySearchTree<int>();
            }
            else
            {
                tree = aTree;
            }
        }
        protected override void asciiArt()
        {
            ForegroundColor = ConsoleColor.Blue;
            WriteLine(@"
            =========================================
                    |                 |    
                    |---.    ,---.    |--- 
                    |   |    `---.    |    
                    `---'    `---'    `--- ");
        }
        protected override void ViewADT()
        {
            Clear();
            char choice;
            WriteLine(@"
            ========================================
                 [ Select an Option To View ]

                [ T ] - View as Tree
                [ P ] - Post Order Traversal   
                [ B ] - Pre Order Traversal
                [ I ] - In Order Traversal
                [ Q ] - Go Back

            ========================================
            ");
            choice = char.ToLower(ReadKey().KeyChar);
            if (choice != 'q')
            {
                handleViews(choice);
            }
        }

        private void handleViews(char keyPressed)
        {
            switch (keyPressed)
            {
                case 't':
                    Clear();
                    tree.Prints();
                    break;

                case 'p':
                    tree.PostOrder();
                    break;

                case 'b':
                    tree.PreOrder();
                    break;

                case 'i':
                    tree.InOrder();
                    break;

                default:
                    Prompts.errorMessage("Invalid Menu Option");
                    break;
            }
            Prompts.enterToContinue();
            ViewADT();
        }
        protected override void add(int val)
        {
            if (tree.TryFind(ref val))
            {
                Prompts.errorMessage("Cannot Add Duplicate Values to the AVL Tree");
                return;
            }

            WriteLine("[+] Pre Insertion [+]");
            safePrint();

            // this method will throw any chance it can due to console buffer size so
            // have to treat it like a nuke

            tree.Insert(val);
            Clear();

            WriteLine($"[+] Post Insertion of -> {val} ]");
            safePrint();
        }

        private void safePrint()
        {
            Prompts.enterToContinue();
            Clear();
            tree.Prints();
            Prompts.enterToContinue();
        }
        public override void Remove()
        {
            Clear();

            if (tree.IsEmpty)
            {
                Prompts.errorMessage("Tree is Empty");
                return;
            }


            removeMsg();
            char choice;

            WriteLine(@"
            =====================================
                [ Select an Option To Remove ]

                [ S ] - Remove Specific Value
                [ R ] - Remove Root
                [ Q ] - Go Back 
            
            =====================================
            ");

            ResetColor();
            choice = char.ToLower(ReadKey().KeyChar);

            if (choice == 'q')
            {
                return;
            }
            else if (choice == 'r')
            {
                remove(tree.peekRoot());
            }
            else
            {
                selectRemove();
            }
            Remove();
        }
        private void handleRemove(char choice)
        {
            switch (choice)
            {
                case 'r':
                    remove(tree.peekRoot());
                    break;

                case 's':
                    selectRemove();
                    break;

                default:
                    Prompts.errorMessage("Invalid Menu Option");
                    break;
            }
        }
        private void selectRemove()
        {
            tree.InOrder();
            int val = getIntput("[-] Select a value to remove from the BST:");
            if (val == -1)
            {
                Remove();
            }
            else if (tree.TryFind(ref val) == false)
            {
                Prompts.errorMessage("Value not found in the BST");
                selectRemove();
            }
            else
            {
                remove(val);
            }
        }
        protected override void remove(int val)
        {
            WriteLine($"[ Pre Removal of -> {val}");
            safePrint();
            tree.Remove(val);
            WriteLine($"[-] Post Removal of -> {val} ]");
            safePrint();
        }
        protected override void doClear()
        {
            tree.Clear();
        }
    }
}
