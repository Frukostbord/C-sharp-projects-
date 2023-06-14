using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Menu
    {
        public void Start()
        {
            int choice = -1;
            double result = 0.0;
            double number1 = 3.5;
            double number2 = 3.0;

            while (choice != 0)
            {
                DisplayMenu();
                choice = ReadUserChoice();

                switch (choice)
                {
                    case 1:
                        result = Add(number1, number2);
                        break;
                    case 2:
                        // subtract
                        break;
                    case 3:
                        // Multiply
                        break;
                    case 4:
                        // Division
                        break;
                    case 5:
                        // Modulus
                        break;
                    default:
                        Console.WriteLine(" Invalid choice! ");
                        break;
                }
                string textOut = string.Format("{0} + {1} = {2}",number1,number2,result);
                Console.WriteLine(textOut);
            }
        }
        /*
        private void PadChars (string charToWrite, int count)
        {
            for (int i = 0; i < length; i++)
            {
               
            }
        }
        */
        private int ReadUserChoice()
        {
            bool goodNum = false;
            int choice = 0;

            do
            {
                string strInput = Console.ReadLine();
                goodNum = int.TryParse(strInput, out choice);
                if (goodNum)
                {
                    if ((choice < 0) || (choice > 5))
                        goodNum = false;
                }

                if (!goodNum)
                    Console.WriteLine("Invalid choice, try again!\n");

            } while (!goodNum);

            return choice;
        }
        private void DisplayMenu()
        {
            Console.WriteLine("+++++++++++++++ Menu +++++++++++++++++\n");
            Console.WriteLine(" ***** 1. Add");
            Console.WriteLine(" ***** 2. Subtract");
            Console.WriteLine(" ***** 3. Multiply");
            Console.WriteLine(" ***** 4. Divide");
            Console.WriteLine(" ***** 5. Modulus");
            Console.WriteLine(" ***** 0. Exit\n");
            Console.WriteLine(" ++++++++++++++++++++++++++++++++++++++++\n");


        }
        private double Add (double number1, double number2)
        {
            double result = number1 + number2;
            return result;
        }
    }
}
