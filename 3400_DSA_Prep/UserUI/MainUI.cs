using System;
using System.Collections.Generic;
using System.Linq;
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
                [ v ] Exam 1 ADTs
                [ h ] Exam 2 ADTs
                [ f ] Final Exam (All)
               
                [ h ] Help
                [ c ] Credits 
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

        public void runHeader()
        {
            Console.WriteLine(HEADER);
            Console.ReadKey();
        }

        private void credits()
        {
            Console.Clear();
            Console.WriteLine(CREDITS);
            Prompts.delayMessage("This Program was made possible in large part due to Professor Dowell", 3000);
            Prompts.delayMessage("All of the Data Structures and Sorting Algorithm code was produced and created by him.", 3000);
            Prompts.delayMessage("I only did some adjustments and refactoring of the original code provided by him...", 3000);
            Prompts.delayMessage("The printing methods for the data structures (aside from the AVL / BST) and \n practice methods done", 3000);
            Prompts.delayMessage("Were created by me however the common operations were not.", 3000);
            Prompts.delayMessage("The coloring and styling done after running each of the algorithims were also made by Professor Dowell", 3000);
            Prompts.delayMessage("I created the all of the UI components, the practice methods, and almost all of the Data Structure printing methods");
            Prompts.delayMessage("This was only made as a fun way to study and I am sharing this ONLY to help fellow data structure students");
            Prompts.delayMessage("I do NOT take any ownership or any credit for ANY of the data structure or algorithim code.");
            Prompts.delayMessage("I hope you find this program can be as useful for as it was for me and best of luck :>", 4000);
            Console.WriteLine("\t\t\t [ << CREDITS OVER >> ]");
            Prompts.enterToContinue();
        }

        private void help()
        {
            Prompts.delayMessage("This program is used to visualize each of the data structures & algorithms covered in 3400", 3000);
            Prompts.delayMessage("You can select an option from the main menu to visualize a data structure or algorithm", 3000);
            Prompts.delayMessage("To navigate the menu, simply type the letter of the option you want to select and a list of options will appear", 3000);
            Prompts.delayMessage("If you would like to try to make some of your own methods there is a practice folder with all of the ADTs from scratch", 3000);
            Prompts.delayMessage("NOTE: you can also pass already created ADTs into any of the ADT view UIs", 3000);
            Prompts.delayMessage("If you want to go back to the main menu, simply type 'q' and you will be taken back to the main menu", 3000);
            Prompts.delayMessage("If you find any problems with the program or have any questions or issues, please let me know and I'll address them as soon as possible", 3000);
            Console.WriteLine("\t\t\t[ << TUTORIAL OVER >> ]");
            Prompts.enterToContinue();
        }




    }
}
