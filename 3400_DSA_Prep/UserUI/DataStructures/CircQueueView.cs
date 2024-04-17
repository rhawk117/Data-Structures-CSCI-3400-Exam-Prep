using _3400_Exam1_Prep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _3400_DSA_Prep.UserUI.DataStructures
{
    public class CircQueueView : View
    {
        public CircularQueue<int> circQueue;


        public CircQueueView(CircularQueue<int> aQ = null) : base("Queue")
        {
            if (aQ == null)
            {
                circQueue = new CircularQueue<int>(20);
            }
            else
            {
                circQueue = aQ;
            }
        }
        protected override void asciiArt()
        {
            ForegroundColor = ConsoleColor.Blue;
            WriteLine(@"
            =======================================                                            
                   ,---..   .,---..   .,---.
                   |   ||   ||---'|   ||---'
                   `---|`---'`---'`---'`---'
                       |                    
            ");
        }
        protected override void add(int val)
        {
            try
            {
                WriteLine("            *------------------------------*\n\n");
                WriteLine($"[+] Enqueued -> {val} [+]");
                circQueue.Enqueue(val);
                circQueue.DisplayAsArr();
                enterToContinue();
            }
            catch (Exception ex)
            {
                Prompts.errorMessage($" A {ex.GetType()} occured likely due to the Queue being full.");
            }
        }
        public override void Remove()
        {
            if (circQueue.IsEmpty())
            {
                Prompts.errorMessage("Queue is empty. Nothing to remove.");
                return;
            }
            try
            {
                removeMsg();
                WriteLine("            *------------------------------*\n\n");
                WriteLine("\t\t[ PRE REMOVAL ]");
                circQueue.DisplayByOrder();
                Prompts.enterToContinue();
                WriteLine($"\n[-] Dequeued Next Integer In Line -> {circQueue.Dequeue()} [-]");
                Prompts.enterToContinue();
                circQueue.DisplayByOrder();
            }
            catch (Exception ex)
            {
                Prompts.errorMessage($" A {ex.GetType()} occured likely due to the Queue being empty.");
            }
        }
        protected override void doClear()
        {
            circQueue.Clear();
        }
        protected override void ViewADT()
        {
            Clear();
            char choice;
            WriteLine($@"
            =============================
                 [ {type} Viewer ]   
        
                [ a ] Array View
                [ o ] In Order View
                [ q ] Go Back
            
            =============================
            ");
            choice = char.ToLower(ReadKey().KeyChar);
            switch (choice)
            {
                case 'a':
                    Clear();
                    circQueue.DisplayAsArr();
                    break;
                case 'o':
                    Clear();
                    circQueue.DisplayByOrder();
                    break;
                case 'q':
                    return;
                default:
                    Prompts.errorMessage("Invalid Menu Option");
                    break;
            }
            Prompts.enterToContinue();
            ViewADT();
        }
    }
}
