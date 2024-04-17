using _3400_DSA_Prep;
using System;
using System.Collections.Generic;
using static System.Console;

namespace _3400_DSA_Prep
{
    public class DictView : View
    {
        public Dict<int, int> hashTable;

        public DictView(Dict<int, int> dict = null) : base("Dictionary")
        {
            if (dict == null)
            {
                this.hashTable = DictCustomizer.CreateCustomDict();
            }
            else
            {
                this.hashTable = dict;
            }
        }

        private void error() => WriteLine("[ Returning to Main Menu... ]");

        protected override void add(int key)
        {
            try
            {
                WriteLine($"[ Adding {key} to the {type}... ]");
                hashTable.Add(key, key);
                enterToContinue();
                WriteLine(hashTable);
            }
            catch (ArgumentException)
            {
                WriteLine($"[ {key} already exists in the {type}. Dictionaries are comprised of unique keys ]");
                error();
            }
            catch (ApplicationException)
            {
                WriteLine("[ Something went horribly Wrong ]");
                error();
            }
            catch (Exception e)
            {
                WriteLine($"Unhandled -> {e.Message} <- Occured in the Hash Map");
            }
            finally
            {
                enterToContinue();
            }
        }

        protected override void doClear()
        {
            WriteLine("[ NOTE: The collision strategy will remain the same ]");
            hashTable.Clear();
        }

        protected override void asciiArt()
        {
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine(@"
            =========================================                    
                    |              |    
                    |---.,---.,---.|---.
                    |   |,---|`---.|   |
                    `   '`---^`---'`   '
            ");
        }
        public override void Remove()
        {
            removeMsg();
            Write(@"
            *===============================*
            |     [ Keys in Hash Table ]    |
            *===============================*
            ");
            foreach (int k in hashTable.GetKeys())
            {
                WriteLine($"\t\t[>] {k} [<]");
            }
            int keyToRmve = getIntput($"\n[-] Enter a key displayed above to Remove from the hash table or q to quit: ");
            ResetColor();
            if (keyToRmve != -1)
            {
                remove(keyToRmve);
            }
            else
            {
                Run();
            }
        }



        protected override void remove(int key)
        {
            try
            {
                WriteLine($"[-] Removing {key} from the {type}... [-]");
                hashTable.Remove(key);
            }
            catch (KeyNotFoundException)
            {
                Prompts.errorMessage($"[ {key} does not exist in the {type}. ]");
                error();
            }
            catch (ApplicationException)
            {
                Prompts.errorMessage($"[ Something went horribly Wrong ]");
                error();
            }
        }

        protected override void ViewADT()
        {
            WriteLine(hashTable);
            enterToContinue();
        }
    }
    // static coupled class to help visualize the different collision resolution strategies
    public static class DictCustomizer
    {
        public static Dict<int, int> CreateCustomDict()
        {
            int size = 31;
            if (confirmAction("size"))
            {
                size = getSize();
            }
            WriteLine($"[i] Size will be {size} (default is 31)\n[ Press ENTER ]");
            ReadKey();
            string type = "Not Set";
            Dict<int, int>.CollisionRes strategy = Dict<int, int>.CollisionRes.Double;
            if (confirmAction("Collision Strategy"))
            {
                strategy = selectCollisonStrategy(ref type);
            }
            else
            {
                type = "Double";
            }
            WriteLine($"[i] Collision strategy has been set to {type}, (default is double).\n[ Press ENTER ]");
            ReadLine();

            return new Dict<int, int>(size, strategy);
        }





        private static bool confirmAction(string attr)
        {
            Write($@"
          ==================={attr.ToUpper()}=====================
                [ ? ] Select a {attr} for the Dictionary [ ? ]
                           [ y (yes) \ n (no) ]
                        
                        >> Type Here: ");
            string choice = ReadLine().ToLower();
            return choice[0] == 'y';
        }
        private static int getSize()
        {
            WriteLine("[ ? ] Type a positive integer for the size that is greater than 20: ");
            string size = ReadLine();
            if (int.TryParse(size, out int s) && s >= 20)
            {
                return s;
            }
            else
            {
                WriteLine("[ ! ] Dude come on... invalid size, try again...");
                return getSize();
            }
        }
        private static Dict<int, int>.CollisionRes selectCollisonStrategy(ref string type)
        {
            WriteLine(@"
            =================================================================
                        
                [ Before Continuing, Select a Collision Strategy ]
                    [ The Table Size is always a Prime Number ]
                       ( hash(key) + f(i) ) % <table_size> )                

                [ l ] Linear Probing =>   where f(i) = i++
                [ q ] Quadratic Probing =>  where f(i) = (i * i)
                [ d ] Double Hashing => where f(i) = (hash(key) + i) % (<table_size> - 1) + 1

            ==================================================================
                
            ");
            char key = ReadKey().KeyChar;
            var strat = choiceMap(key, ref type);
            return strat;
        }

        private static Dict<int, int>.CollisionRes choiceMap(char key, ref string type)
        {
            switch (key)
            {
                case 'l':
                    type = "Linear";
                    return Dict<int, int>.CollisionRes.Linear;


                case 'q':
                    type = "Quadratic";
                    return Dict<int, int>.CollisionRes.Quad;


                case 'd':
                    type = "Double";
                    return Dict<int, int>.CollisionRes.Double;

                default:
                    WriteLine("[!] Select a Valid Collision strategy or type q to quit");
                    return selectCollisonStrategy(ref type);
            }
        }
    }
}