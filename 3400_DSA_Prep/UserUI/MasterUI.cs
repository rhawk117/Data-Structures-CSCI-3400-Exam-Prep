using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3400_DSA_Prep
{
    public class MasterUI : ExamViewer
    {
        private AlgoUI algoUI;
        public MasterUI() : base()
        {
            setComponents();
        }
        protected override void setComponents()
        {
            color = ConsoleColor.DarkGray;
            menuText = @"
            *=====================================================================* 
            |         ___                                              ___        |
            |        |  _|   _____ _         _    _____ _             |_  |       |
            |       _| |    |   __|_|___ ___| |  |  |  |_|___ _ _ _     | |_      |
            |      |_  |    |   __| |   | .'| |  |  |  | | -_| | | |    |  _|     |
            |        | |_   |__|  |_|_|_|__,|_|   \___/|_|___|_____|   _| |       |
            |        |___|                                            |___|       |
            |                                                                     |
            *=====================================================================*                                                                                
            |                        [ View Master ]                              |
            |                   << Select a Menu Option >>                        | 
            *=====================================================================*                                                                                
            |                                                                     |
            |            [ k ] Stack                                              |
            |            [ u ] Queue                                              |
            |            [ l ] Linked List                                        |
            |            [ t ] Binary Search Tree                                 |
            |                                                                     |
            |            [ m ] Min Priority Queue / Binary Heap                   | 
            |            [ b ] AVL Tree                                           | 
            |            [ c ] Dictionary / Hash Table                            | 
            |                                                                     |
            |            [ a ] Algo Viewer                                        |
            |            [ q ] Go Back                                            |
            *=====================================================================*";

            algoUI = null;
            currentUI = null;
        }
        protected override void handleKeys(char keyPressed)
        {
            switch (keyPressed)
            {
                // stack
                case 'k':
                    switchWindow(new StackView());
                    break;

                // queue
                case 'u':
                    switchWindow(new CircQueueView());
                    break;

                // singly linked list
                case 'l':
                    switchWindow(new LinkedListView());
                    break;

                // binary search tree
                case 't':
                    switchWindow(new BSTView());
                    break;

                case 'm':
                    switchWindow(new QueueView());
                    break;

                // AVL Tree
                case 'b':
                    switchWindow(new AVLView());
                    break;

                // Hash Table / Dictionary 
                case 'c':
                    switchWindow(new DictView());
                    break;

                // Algorithm Viewer
                case 'a':
                    switchAlgo(new AlgoUI());
                    break;
            }
            loopUI();
        }
        private void switchAlgo(AlgoUI algo)
        {
            algoUI = algo;
            algo.RenderUI();
        }






    }
}
