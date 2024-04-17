using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3400_DSA_Prep.UserUI
{
    public class Exam2UI : ExamViewer
    {
        public Exam2UI() : base()
        {
            setComponents();
        }
        protected override void setComponents()
        {
            menuText = @"
                    
          *=====================================================================*                                                                                
                           [ Exam 2 Data Structure Viewer ]                         
                           << Select an ADT to Visualize >>                   
                                                                               
                     [ a ] Min Priority Queue / Binary Heap                    
                     [ b ] AVL Tree                                            
                     [ c ] Dictionary / Hash Table                             
                     [ q ] Go Back                                             
                                                                               
          *=====================================================================*
            ";
        }

        protected override void handleKeys(char keyPressed)
        {
            switch (keyPressed)
            {
                case 'a':
                    switchWindow(new QueueView());
                    break;

                case 'b':
                    switchWindow(new AVLView());
                    break;

                case 'c':
                    switchWindow(new DictView());
                    break;

                default:
                    Prompts.errorMessage("Select a Valid Option");
                    break;
            }
            loopUI();
        }
    }
}
