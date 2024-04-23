using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3400_DSA_Prep
{
    public class ExamViewer
    {
        protected string menuText;

        protected View currentUI;

        protected ConsoleColor color;

        // used in ctor by children
        protected virtual void setComponents() { }

        public ExamViewer() => currentUI = null;


        public void RenderUI()
        {
            char input;

            Console.Clear();
            Console.ForegroundColor = color;
            Console.WriteLine(menuText);

            input = char.ToLower(Console.ReadKey().KeyChar);

            if (input == 'q')
            {
                Console.WriteLine("\t\t[-] Exiting UI.. [-]");
            }
            else
            {
                handleKeys(input);
            }
        }

        protected virtual void handleKeys(char keyPressed) { }

        protected void loopUI()
        {
            currentUI = null;
            RenderUI();
        }

        protected virtual void switchWindow(View newUI)
        {
            currentUI = newUI;
            currentUI.Run();
        }
    }
}
