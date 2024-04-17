using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _3400_DSA_Prep
{
    public static class Prompts
    {
        private static void color() => ResetColor();
        public static void DisplayHeader()
        {
            WriteLine(@"
            ==================================================================================
            |       __  _____ _  _    ___   ___   __                                         |
            |      / / |___ /| || |  / _ \ / _ \  \ \                                        |
            |     / /    |_ \| || |_| | | | | | |  \ \                                       |
            |     \ \   ___) |__   _| |_| | |_| |  / /                                       |
            |      \_\ |____/   |_|  \___/ \___/  /_/                                        |
            |                                                                                |
            |     ____        _          ____  _                   _                         |
            |    |  _ \  __ _| |_ __ _  / ___|| |_ _ __ _   _  ___| |_ _   _ _ __ ___  ___   |
            |    | | | |/ _` | __/ _` | \___ \| __| '__| | | |/ __| __| | | | '__/ _ \/ __|  |
            |    | |_| | (_| | || (_| |  ___) | |_| |  | |_| | (__| |_| |_| | | |  __/\__ \  |
            |    |____/ \__,_|\__\__,_| |____/ \__|_|   \__,_|\___|\__|\__,_|_|  \___||___/  |
            |                                                                                |
            ==================================================================================
            ");
        }

        public static void errorMessage(string warning)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"\t\t[ ! ] {warning} [ ! ]");
            color();
        }

        public static void enterToContinue()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("\n\t\t[>] Press ENTER to Continue [<]");
            ReadKey(); color();
        }






    }
}
