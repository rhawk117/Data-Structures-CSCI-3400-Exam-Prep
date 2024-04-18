using _3400_Exam1_Prep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace _3400_DSA_Prep
{
    public class LinkedListView : View
    {
        public SinglyLinkedList<int> list;

        public LinkedListView(SinglyLinkedList<int> aList = null) : base("Linked List")
        {
            if (aList == null)
            {
                list = new SinglyLinkedList<int>();
            }
            else
            {
                list = aList;
            }
        }
        protected override void asciiArt()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine(@"
          =================================================                                       
           |    o     |             |    |    o     |    
           |    .,---.|__/ ,---.,---|    |    .,---.|--- 
           |    ||   ||  \ |---'|   |    |    |`---.|    
           `---'``   '`   ``---'`---'    `---'``---'`---'");
        }

        protected override void add(int val)
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(@"
            *------------------------------*
                  [+] Add Options [+]

             [ F ] - Add Front
             [ L ] - Add Last

            *------------------------------*
            ");
            ResetColor();
            char choice = ReadKey().KeyChar;
            choice = char.ToLower(choice);
            switch (choice)
            {
                case 'f':
                    list.AddFirst(val);
                    break;

                case 'l':
                    list.Append(val);
                    break;

                default:
                    Prompts.errorMessage("Invalid choice");
                    add(val);
                    break;
            }
            result();
            Prompts.enterToContinue();
        }

        private void result()
        {
            Clear();
            ForegroundColor = ConsoleColor.White;
            WriteLine("\t\t\t[ RESULT ]");
            WriteLine($"[ {list} ]");
            ResetColor();
        }
        public override void Remove()
        {
            Clear();
            if (list.IsEmpty())
            {

            }
            char choice;
            removeMsg();
            WriteLine(@"
            *------------------------------*
                  [-] Remove Options [-]

             [ F ] - Add Front
             [ L ] - Add Last
                
            *------------------------------*");
            ResetColor();
            choice = char.ToLower(ReadKey().KeyChar);
            switch (choice)
            {
                case 'f':
                    list.RemoveFirst();
                    break;
                case 'l':
                    list.RemoveLast();
                    break;
                default:
                    Prompts.errorMessage("Invalid choice");
                    Remove();
                    break;
            }
            result();
            Prompts.enterToContinue();
        }
        protected override void ViewADT()
        {
            WriteLine($"[ LINKED LIST ({list.Count} items) ]");
            WriteLine(list);
            Prompts.enterToContinue();
        }

        protected override void doClear()
        {
            list.Reset();
        }


    }
}
