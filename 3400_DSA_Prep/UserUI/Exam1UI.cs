using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3400_DSA_Prep
{
    public class Exam1UI : ExamViewer
    {
        public Exam1UI() : base()
        {
            setComponents();
        }
        protected override void setComponents()
        {
            color = ConsoleColor.Yellow;
            menuText = @"
            *=====================================================================*                                                                                
                           [ Exam 1 Data Structure Viewer ]                         
                           << Select an ADT to Visualize >>                   
                                                                               
                     [ k ] Stack                    
                     [ u ] Queue                                            
                     [ l ] Linked List
                     [ t ] Binary Search Tree                             
                     [ q ] Go Back                                             
                                                                               
          *=====================================================================*";
        }
        protected override void handleKeys(char choice)
        {
            switch (choice)
            {
                case 'k':
                    switchWindow(new StackView());
                    break;

                case 'u':
                    switchWindow(new CircQueueView());
                    break;

                case 'l':
                    switchWindow(new LinkedListView());
                    break;

                case 't':
                    switchWindow(new BSTView());
                    break;

                default:
                    Prompts.errorMessage("Provide a Valid Menu Option");
                    break;
            }
            loopUI();
        }
    }
}
