using _3400_DSA_Prep.UserUI;
using System;
using System.Diagnostics;

namespace _3400_DSA_Prep
{
    public class AlgoUI : ExamViewer
    {

        protected AlgoInfo activeUI;

        public AlgoUI() : base()
        {
            activeUI = null;
            setComponents();
        }

        protected override void setComponents()
        {
            menuText = @"
            *==========================================================*
                            _                               _ 
                           | |                             | |
                      __ _ | |  __ _   ___    _ __    __ _ | |
                     / _` || | / _` | / _ \  | '_ \  / _` || |
                    | (_| || || (_| || (_) | | |_) || (_| || |
                     \__,_||_| \__, | \___/  | .__/  \__,_||_|
                                __/ |        | |              
                               |___/         |_|              
            *==========================================================*    
            |                [ UI Made by rhawk117 ]                   |
            *==========================================================*
            | [ Algorithims & Print Methods Made By Professor Dowell ] |
            |      [ Algo Pal - CSCI 3400: Data Structures ]           |
            |          [ Sorting Algorithm Visualizer ]                |
            |                                                          |
            |                                                          |
            |      [ Select a Sorting Algorithim to Visualize ]        |
            |                                                          |
            |            [ B ] - Bubble Sort                           |
            |            [ S ] - Selection Sort                        |
            |            [ I ] - Insertion Sort                        |
            |            [ F ] - Quick Sort                            | 
            |            [ L ] - Shell Sort                            |
            |            [ M ] - Merge Sort                            |
            |            [ H ] - Heap Sort                             |
            |            [ Q ] - Exit                                  |
            *==========================================================*
            ";
            color = ConsoleColor.White;
        }


        protected override void handleKeys(char c)
        {
            switch (c)
            {
                case 'b':
                    setActiveWindow(new BubbleSort());
                    break;

                case 's':
                    setActiveWindow(new SelectionSort());
                    break;

                case 'i':
                    setActiveWindow(new InsertionSort());
                    break;

                case 'f':
                    setActiveWindow(new QuickSort());
                    break;

                case 'l':
                    setActiveWindow(new ShellSort());
                    break;

                case 'm':
                    setActiveWindow(new MergeSort());
                    break;

                case 'h':
                    setActiveWindow(new HeapSort());
                    break;

                default:
                    Prompts.errorMessage("Select a Valid Option");
                    break;
            }
            loopUI();
        }

        private void setActiveWindow(AlgoInfo window, bool flag = true)
        {
            activeUI = window;
            activeUI.Run();
        }


    }
}