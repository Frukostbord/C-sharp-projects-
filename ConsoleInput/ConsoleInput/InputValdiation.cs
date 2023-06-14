using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInput
{
    class InputValdation
    {
        private bool goodNumber;
        private string strNumber;
        private int numberParsed;


        public void Start()
        {
            // Calls other methods until exit

            do
            {
                GetWholeNumber();
                CheckInput();

                if (strNumber == "0")
                {
                    Console.WriteLine("Now exiting program");
                }
                else if (goodNumber)
                {
                    Console.WriteLine("Good number!");
                    Console.WriteLine();
                }
                else if (!goodNumber)
                {
                    Console.WriteLine("Input must be a integer. Try again!");
                    Console.WriteLine();
                }
            } while (strNumber != "0");

        }


        private void GetWholeNumber()
        {
            // Information for user
            // Get number from user

            Console.WriteLine("This program valdiates whole numbers.");
            Console.WriteLine("Write a valid non-zero, or a non-values number to get feedback!");
            Console.WriteLine("Entering a '0' exits the application.");
            Console.WriteLine();

            Console.Write("Your input please: ");
            strNumber = Console.ReadLine();
        }
        private void CheckInput()
        {
            // Sees if input can be converted to an integer

            goodNumber = int.TryParse(strNumber, out numberParsed);

        }

    }
}
