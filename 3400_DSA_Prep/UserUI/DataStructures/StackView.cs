using _3400_Exam1_Prep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _3400_DSA_Prep
{
    public class StackView : View
    {
        private OurStack<int> stack;
        public StackView(OurStack<int> aStack = null) : base("Stack")
        {
            if (aStack == null)
            {
                stack = new OurStack<int>();
            }
            else
            {
                stack = aStack;
            }
        }

        protected override void asciiArt()
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine(@"
            =========================================
            ,---.    |                          |    
            `---.    |---     ,---.    ,---.    |__/ 
                |    |        ,---|    |        |  \ 
            `---'    `---'    `---^    `---'    `   `");
        }
        protected override void add(int val)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"[+] Pushing -> {val} to the top of the stack [+]");
            stack.Push(val);
            ResetColor();
            WriteLine(stack);
            Prompts.enterToContinue();
        }
        public override void Remove()
        {
            if (stack.IsEmpty())
            {
                Prompts.errorMessage("Stack is empty. Nothing to remove.");
                return;
            }
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"[-] Popped -> {stack.Pop()} from the top of the stack [-]");
            ResetColor();
            WriteLine(stack);
            Prompts.enterToContinue();
        }
        protected override void ViewADT()
        {
            WriteLine("\t\t[ Stack Contents ]");
            WriteLine(stack);
            Prompts.enterToContinue();
        }
        protected override void doClear()
        {
            stack.Clear();
        }





    }
}
