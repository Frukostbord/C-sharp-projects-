using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menuapp
{
    class MainProgram           
    {
        static void Main()
        {
            //Aesthetics
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "The Menu Program";
            Console.ForegroundColor = ConsoleColor.Black;


            Menu menu = new Menu();
            menu.Start();
        }
    }
}
