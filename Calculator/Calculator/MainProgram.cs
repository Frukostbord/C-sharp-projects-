using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class MainProgram
    {
        static void Main ()
        {
            Menu menu = new Menu();
            menu.Start();

            Console.ReadLine();
        }
    }
}
