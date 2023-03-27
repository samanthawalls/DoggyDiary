using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggy_Diary
{
    class Menu
    {
        public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("[1] Capture Potty Event");
            Console.WriteLine("[2] Capture Feeding Event");
            Console.WriteLine("[3] Create New Dog Profile");
            Console.WriteLine("[4] Create Report");
            Console.WriteLine("[5] ---- EXIT -----");


            switch (Console.ReadLine())
            {
                case "1":
                    //potty event method
                    return true;
                case "2":
                    //feed event method
                    return true;
                case "3":
                    //new dog method
                    return true;
                case "4":
                    //report getter
                    return true;
                //create report method
                case "5":
                    return false;
                default:
                    return true;
            }

        }

    }
}
