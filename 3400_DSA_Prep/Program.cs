using _3400_DSA_Prep.UserUI;
using System;
using _3400_DSA_Prep.Practice;

namespace _3400_DSA_Prep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Disclaimer.StartUp();
            MainUI main = new MainUI();
            main.Run();
        }


        static void TestMethods()
        {
            Testing.RunTests();
        }
    }
}
