using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _3400_DSA_Prep.UserUI
{
    public class MainUI
    {
        private const string HEADER = @"
        ==================================================================================
            ,--.      |              ,---.|                  |                                              
            |   |,---.|--- ,---.     `---.|--- ,---.   .,---.|--- .   .,---.,---.,---.                      
            |   |,---||    ,---|         ||    |   |   ||    |    |   ||    |---'`---.                      
            `--' `---^`---'`---^     `---'`---'`   `---'`---'`---'`---'`    `---'`---'   
                                               |                                                                                   
                                 ,---.,---.,---|                                                                                   
                                 ,---||   ||   |                                  
                                 `---^`   '`---'       
                    ,---.|                  o|    |                  
                    |---||    ,---.,---.,---.|--- |---.,-.-.,---.    
                    |   ||    |   ||   ||   ||    |   || | |`---.                                                     
                    `   '`---'`---|`---'`   ``---'`   '` ' '`---'                                                     
                              `---'                                  
                     ______  ____    ______                     
                    /\  _  \/\  _`\ /\__  _\              __    
                    \ \ \L\ \ \ \/\ \/_/\ \/       __  __/\_\   
                     \ \  __ \ \ \ \ \ \ \ \      /\ \/\ \/\ \  
                      \ \ \/\ \ \ \_\ \ \ \ \     \ \ \_\ \ \ \ 
                       \ \_\ \_\ \____/  \ \_\     \ \____/\ \_\
                        \/_/\/_/\/___/    \/_/      \/___/  \/_/

        ==================================================================================

                            [>] Press ENTER to Continue [<]   
        ";

        private const string MENU = @"
        ==============================================
                       [ Main Menu ]
        ==============================================                                                               
                  << Select an Option >>

                [ a ] Algorithm Visualizer
                [ b ] Exam 1 ADTs
                [ c ] Exam 2 ADTs
                [ f ] Final Exam (All)
               
                [ h ] Help
                [ s ] Credits 
                [ q ] Quit
        ==============================================                                                               
        ";
        private const string CREDITS = @"
        ===================================================
           __  _____                  _  _  _         __   
          / / /  __ \                | |(_)| |        \ \  
         / /  | /  \/ _ __   ___   __| | _ | |_  ___   \ \ 
        < <   | |    | '__| / _ \ / _` || || __|/ __|   > >
         \ \  | \__/\| |   |  __/| (_| || || |_ \__ \  / / 
          \_\  \____/|_|    \___| \__,_||_| \__||___/ /_/  
        ====================================================";

        private const string HELP = @"
        ================================================================
           __  ___   __      _            _             __  ___   __   
          / / |__ \  \ \    | |          | |           / / |__ \  \ \  
         / /     ) |  \ \   | |__    ___ | | _ __     / /     ) |  \ \ 
        < <     / /    > >  | '_ \  / _ \| || '_ \   < <     / /    > >
         \ \   |_|    / /   | | | ||  __/| || |_) |   \ \   |_|    / / 
          \_\  (_)   /_/    |_| |_| \___||_|| .__/     \_\  (_)   /_/  
                                            | |                        
                                            |_|                        
        ==================================================================";

        private ExamViewer activeWindow;
        public MainUI() => activeWindow = null;

        public void runHeader()
        {
            Console.WriteLine(HEADER);
            Console.ReadKey();
        }

        private void credits()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.WriteLine(CREDITS);
            Prompts.delayMessage("\n\t[ > ]This Program was made possible in large part due to Professor Dowell", 3000);
            Prompts.delayMessage("\n\t[ > ]All of the Data Structures and Sorting Algorithm code was produced and created by him.", 3000);
            Prompts.delayMessage("\n\t[ > ]I only did some adjustments and refactoring of the original code provided by him...", 3000);
            Prompts.delayMessage("\n\t[ > ]The printing methods for the data structures (aside from the AVL / BST) and \n\t practice methods done", 3000);
            Prompts.delayMessage("\n\t[ > ]Were created by me however the common operations were not.", 3000);
            Prompts.delayMessage("\n\t[ > ]The coloring and styling done after running each of the algorithims were also \n\tmade by Professor Dowell", 3000);
            Prompts.delayMessage("\n\t[ > ]I created the all of the UI components, the practice methods, and almost all of\n\t the Data Structure printing methods");
            Prompts.delayMessage("\n\t[ > ]This was only made as a fun way to study and I am sharing this ONLY to help \n\tfellow data structure students");
            Prompts.delayMessage("\n\t[ > ]I do NOT take any ownership or any credit for ANY of the data structure or \n\talgorithim code.");
            Prompts.delayMessage("\n\t[ > ]I hope you find this program can be as useful for as it was for me \n\tand best of luck :>", 4000);
            Console.WriteLine("\t\t\t [ << CREDITS OVER >> ]");
            Console.ResetColor();
            Prompts.enterToContinue();
        }

        private void help()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(HELP);
            Prompts.delayMessage("\n\t[i] This program is used to visualize each of the data structures & algorithms covered in 3400", 3000);
            Prompts.delayMessage("\n\t[i] You can select an option from the main menu to visualize a data structure or algorithm", 3000);
            Prompts.delayMessage("\n\t[i] To navigate the menu, simply type the letter of the option you want to select\n\tand a list of options will appear", 3000);
            Prompts.delayMessage("\n\t[i] If you would like to try to make some of your own methods there is a practice \n\tfolder with all of the ADTs from scratch", 3000);
            Prompts.delayMessage("\n\t[i] NOTE: you can also pass already created ADTs into any of the ADT view UIs", 3000);
            Prompts.delayMessage("\n\t[i] If you want to go back to the main menu, simply type 'q' and you will be taken \n\tback to the main menu", 3000);
            Prompts.delayMessage("\n\t[i] If you find any problems with the program or have any questions or issues, \n\tplease let me know and I'll address them as soon as possible", 3000);
            Console.WriteLine("\t\t\t[ << TUTORIAL OVER >> ]");
            Console.ResetColor();
            Prompts.enterToContinue();
        }

        public void Run(int tick = 0)
        {
            if (tick == 0) runHeader();

            char keyPressed;
            Console.Clear();
            Console.WriteLine(MENU);
            keyPressed = char.ToLower(Console.ReadKey().KeyChar);

            if (keyPressed == 'q')
            {
                Console.WriteLine("\t\t[ Thank you for using my Program ]");
                return;
            }

            handleKeyInput(keyPressed);

        }

        //[a] Algorithm Visualizer
        //[v] Exam 1 ADTs
        //[h] Exam 2 ADTs
        //[f] Final Exam(All)
        //[h] Help
        //[c] Credits
        //[q] Quit

        private void handleKeyInput(char keyPressed)
        {
            switch (keyPressed)
            {
                // algos
                case 'a':
                    this.switchWindow(new AlgoUI());
                    break;

                // exam 1
                case 'b':
                    this.switchWindow(new Exam1UI());
                    break;

                // exam 2 
                case 'c':
                    this.switchWindow(new Exam2UI());
                    break;

                // final exam
                case 'f':
                    this.switchWindow(new MasterUI());
                    break;

                // help
                case 'h':
                    this.help();
                    break;

                // credits
                case 's':
                    this.credits();
                    break;

                default:
                    Prompts.errorMessage("Select a Valid Menu Option");
                    break;
            }
            Prompts.enterToContinue();
            activeWindow = null;
            Run(1);
        }

        private void switchWindow(ExamViewer window)
        {
            activeWindow = window;
            activeWindow.RenderUI();
        }

    }
}
