using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace _3400_DSA_Prep
{
    public class View
    {
        protected string type;

        protected string title;
        public View(string type)
        {
            title = $@"
            ==========================================
                      [ {type} Visualizer ]          
            ======================================== 
                   << Select A Menu Option >>                      
                                                    
                [ a ] - Add                          
                [ r ] - Remove                        
                [ c ] - Clear / Reset                 
                [ v ] - View {type}                   
                [ q ] - Quit                          
                                                    
            ========================================           
           ";
            this.type = type;
        }
        protected virtual void asciiArt() { }
        public void Run()
        {
            Clear();
            asciiArt();
            WriteLine(title);
            ResetColor();
            char key = ReadKey().KeyChar;
            key = char.ToLower(key);

            if (key == 'q') WriteLine("\t\t[ Exiting UI... ]");

            else handleKeys(key);
        }

        public void handleKeys(char c)
        {
            switch (c)
            {
                case 'a':
                    Add();
                    break;

                case 'r':
                    Remove();
                    break;

                case 'v':
                    ViewADT();
                    break;

                case 'c':
                    ClearADT();
                    break;

                default:
                    WriteLine("[ Select a valid menu option (a, r, v, q) ]");
                    break;
            }

            Run();
        }

        /// <summary>
        /// In theory you'd just call ToStr() on the data structure
        /// however I created various ways of viewing the data structure
        /// so maybe this makes more sense to be virtual 
        /// </summary>

        protected virtual void ViewADT() { }

        protected void ClearADT()
        {
            Clear(); char c;
            Write($@"
                 [ ? ] Clear the {type} [ ? ]
            [ ! ] Warning this cannot be undone [ ! ]
            
            >> Type 'Y' to proceed or anything else to back out: 
            ");
            c = char.ToLower(ReadKey(true).KeyChar);
            if (c != 'y')
            {
                WriteLine($"[ ... ] Cancelling clearing the {type}");
            }
            else
            {
                WriteLine($"[ X ] Clearing the {type} [ X ]");
                doClear();
            }
            enterToContinue();
        }

        protected virtual void doClear() { }

        protected void enterToContinue()
        {
            WriteLine("\n[ Press Enter to Continue... ]\n");
            ReadKey();
        }

        protected virtual void add(int val) { }

        protected virtual void remove(int val) { }

        // adding should be the same for all types of data structures
        public void SingleAdd()
        {
            int addVal = getIntput($"[ Enter a value to add to the {type} or q to go back: ");

            if (addVal != -1)
            {
                add(addVal);
            }
            else
            {
                Add();
            }
        }

        private void addMsg()
        {
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine(@"
            *------------------------------*                   
            |   ____       __       ____   | 
            |  |   _|    _|  |_    |_   |  |  
            |  |  |     |_    _|     |  |  |  
            |  |  |_      |__|      _|  |  |  
            |  |____|              |____|  | 
            |                              |
            ");
        }

        public void Add()
        {
            Clear();

            char choice;
            addMsg();
            WriteLine(@"
            *==============================*
            |      [ Add Options ]         |
            |                              |
            |  [ s ] Add Single Item       |
            |  [ m ] Add Multiple Items    |
            |  [ q ] Go Back               |
            |                              |
            *==============================*

            "); ResetColor();

            choice = char.ToLower(ReadKey().KeyChar);
            if (choice != 'q') handleAdd(choice);
        }

        private void handleAdd(char choice)
        {
            switch (choice)
            {
                case 's':
                    SingleAdd();
                    break;

                case 'm':
                    MultipleAdd();
                    break;

                default:
                    WriteLine("[ ! ] Select a Valid Menu Option [ ! ]");
                    break;
            }
            Clear();
            Add();
        }
        private void MultipleAdd()
        {
            List<int> additions = Adder.GetUserCollection();
            if (additions == null)
            {
                Add();
            }
            else
            {
                try
                {
                    multiAdd(additions);
                }
                catch (Exception ex)
                {
                    Prompts.errorMessage($@"
                    [ An exception occured while trying to add your collection ]
                             {ex.Message}
                    Likely due to the collection being full as such no further values
                    from the collection typed will be added succesfully. 

                    ");
                }
                WriteLine("[ Action Complete ]");
                ResetColor();
            }
        }
        private void multiAdd(List<int> additions)
        {
            for (int i = 0; i < additions.Count; i++)
            {
                add(additions[i]);
            }
            WriteLine($"[ All {additions.Count} have been added.. ]");
        }

        protected void removeMsg()
        {
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine(@"
            *------------------------------*
            |   ____                ____   |
            |  |   _|    ______    |_   |  |
            |  |  |     |______|     |  |  |
            |  |  |_                _|  |  |
            |  |____|              |____|  |
            |                              |
            ");
        }

        // can't really generalize this one, children classes implement own
        public virtual void Remove() { }

        // funny pun
        public int getIntput(string prompt)
        {
            WriteLine(prompt);
            int val;
            string input = ReadLine();

            if (input.ToLower() == "q")
            {
                return -1;
            }
            else if (!int.TryParse(input, out val))
            {
                WriteLine("[ Input an integer value type q if you want to exit ]");
                return getIntput(prompt);
            }
            return val;
        }

    }
    public static class Adder
    {
        public static List<int> GetUserCollection()
        {
            Write(@"
            [ ? ] Type a list of integers seperated by commas to add
                  to the data structure or type 'q' or quit to go back.

                  (at least 5 integers)

            [ ? ]  Input Here: 
            ");
            string input = ReadLine();
            List<int> userCollection = new List<int>();
            try
            {
                userCollection = parseListput(input);
            }
            catch (Exception ex)
            {
                WriteLine($"[!] {ex.Message} [!]");
                WriteLine(">> Invalid Input: Please enter only integers seperated by commas.");
                return GetUserCollection();
            }
            return userCollection;
        }
        // ouuu fancy lambda expression
        private static List<int> parseListput(string input)
        {
            if (input.ToLower() == "q" || input.ToLower() == "quit")
            {
                return null;
            }
            List<int> userList = input.Split(',')
                           .Select(part => part.Trim())
                           .Where(part => !string.IsNullOrEmpty(part))
                           .Select(part =>
                           {
                               bool attempt = int.TryParse(part, out int parsedNumber);
                               if (attempt == false) throw new ArgumentException(
                                   $"'{part}' is not a valid integer."
                                );
                               return parsedNumber;
                           })
                           .ToList();
            if (userList.ToHashSet().Count != userList.Count)
            {
                ForegroundColor = ConsoleColor.Red;
                throw new ArgumentException("[ Do not use duplicate values! ]");
            }
            if (userList.Count < 5)
            {
                ForegroundColor = ConsoleColor.Red;
                throw new ArgumentException("[!] Collection provided is less than 5 numbers... [!]");
            }
            return userList;
        }
    }






}