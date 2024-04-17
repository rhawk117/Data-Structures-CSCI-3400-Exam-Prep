using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;

namespace _3400_DSA_Prep
{
    public class AlgoInfo
    {
        protected string title; // name of 

        protected string bigO; // time complexity

        protected string description; // description of the algorithm

        protected string[] steps; // steps of the algorithm

        protected List<int> WorstCaseInput = new List<int>(); // worst case input for the algorithm

        protected Action<List<int>> Sorter; // sorting method

        protected string explainWorst; // explaination of the type of worst case input

        public AlgoInfo() { }

        // children pass in the time complexity to re use template
        protected void desc(string bst, string wst, string avg)
        {
            string summary = $@"
            ==========================================================================
                                       OVERVIEW                                       
            ==========================================================================
               {description}
            
            ==========================================================================  
                                    TIME COMPLEXITY
               
               [ Best Case ] => O({bst})
               [ Worst Case ] => O({wst})
               [ Average Case ] => O({avg})

            ==========================================================================
            ";
            WriteLine(summary);
        }

        // meant 4 children to implement (overrides)
        protected virtual void ASCIIart() { }

        // sets the different time complexity when Desc is called
        protected virtual void ViewDescription() { }
        protected virtual void setInfo() { }

        public void ViewSteps()
        {
            WriteLine($"\t\t[ Steps for {title} ]");
            for (int i = 0; i < steps.Length; i++)
            {
                aStep(i);
            }
            WriteLine("\t\t[i] Steps Completed - Guided Walkthrough Complete [i]");
        }
        private void aStep(int i)
        {
            WriteLine($"\n\t#{i + 1}. {steps[i]}\n");
            Thread.Sleep(2500);
        }

        public void ViewWorstCase()
        {
            Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            WriteLine($@"
            =======================================================================
                                WORST CASE INPUT {title}         
            =======================================================================
              The Worst Case Input for {title} is a collection that is...
              
                >> {explainWorst}
            
            =======================================================================
                    [ Example Worst Case Collection (if applicable) ]
                    >> {arrString(WorstCaseInput)}
            =======================================================================
            ");
            ResetColor();
        }

        public void Run()
        {
            Clear();

            ASCIIart();
            menuText();

            char input = ReadKey().KeyChar;
            input = char.ToUpper(input);

            if (input != 'E') handleKeys(input);
        }

        public void menuText()
        {
            WriteLine($@"
                    [ {title.ToUpper()} ]
                
                [ D ] - View Description
                [ S ] - View Steps
                [ W ] - View Worst Case Input
                [ R ] - Run {title}
                [ E ] - Exit / Go Back

            ========================================
            ");
        }
        private void handleKeys(char c)
        {
            switch (c)
            {
                case 'D':
                    Clear();
                    ViewDescription();
                    break;

                case 'S':
                    Clear();
                    ViewSteps();
                    break;

                case 'W':
                    ViewWorstCase();
                    break;

                case 'R':
                    Clear();
                    pickCollection();
                    break;

                default:
                    youAreNaughty();
                    break;
            }
            AlgoUtils.enterToContinue();
            Run();
        }

        // lol
        private void youAreNaughty()
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\a\a\n\n[ Select a valid option ]");
            ResetColor();
        }


        private void pickCollection()
        {
            Clear();
            ASCIIart();
            WriteLine(@"
              ================================================================
              |    [ ? ] Select an option for the collection to sort [ ? ]   |
              |                                                              |
              |        [ 1 ] - Random Collection                             |
              |        [ 2 ] - Custom Collection                             |
              |        [ 3 ] - Exit                                          |
              ================================================================
            ");
            ResetColor();
            char input = ReadKey().KeyChar;

            if (input == '3') return;

            else getCollection(input);
        }

        private void getCollection(char input)
        {
            List<int> choice = new List<int>();
            switch (input)
            {
                case '1':
                    choice = AlgoUtils.HandleRandom();
                    break;

                case '2':
                    choice = AlgoUtils.GetUserCollection();
                    break;

                default:
                    choice = null;
                    break;
            }
            handleSort(choice);
        }
        private void handleSort(List<int> choice)
        {
            if (choice == null)
            {
                youAreNaughty();
            }
            else
            {
                runSort(choice);
                AlgoUtils.enterToContinue();
            }
            pickCollection(); // go back 
        }

        private void runSort(List<int> collection)
        {
            WriteLine($"\n\n[ {title} ]\n\n");
            WriteLine("[ Pre-Sort ]");
            arrView(collection);
            AlgoUtils.enterToContinue();

            this.Sorter(collection);

            WriteLine($"[ {title} Complete! ]");
            WriteLine("[ Post-Sort ]");
            arrView(collection);
        }

        private void arrView(List<int> collection)
        {
            string view = arrString(collection);
            WriteLine($"\n{view}\n");
        }

        private string arrString(List<int> collection)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");
            for (int i = 0; i < collection.Count; i++)
            {
                sb.Append($"{collection[i]}, ");
            }
            sb.Append(" }");
            return sb.ToString();
        }

        public override string ToString() => title;

        //public AlgoInfo(string title, string bigO, string description, string[] steps,
        //Action<List<int>> sort, List<int> worstCaseInput, string explainWorst)
        //{
        //    this.title = title;
        //    this.bigO = bigO;
        //    this.description = description;
        //    this.steps = steps;

        //    Sorter = sort;

        //    WorstCaseInput = worstCaseInput;
        //    this.explainWorst = explainWorst;
        //}

    }
}