﻿using _3400_DSA_Prep.UserUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3400_DSA_Prep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Disclaimer.StartUp();
            MainUI main = new MainUI();
            main.runHeader();
            Exam2UI t = new Exam2UI();
            t.RenderUI();

        }
    }
}
