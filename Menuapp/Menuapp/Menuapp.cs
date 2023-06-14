using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menuapp
{
    public class Menu
    {
        //Variables to be used through the class

        private int userInput;
        private bool checkInput;

        public void Start()
        {
            // Starts the menu
            LoopingMenu();

        }
        private void LoopingMenu()
        {
            // Loops menu until user exits
            do
            {
                UserInterface();
                GetUserInput();

            } while (userInput != 0);

        }

        private void UserInterface()
        {
            // Menu for the user

            Console.WriteLine("+++++++++++++ MENU +++++++++++++");
            Console.WriteLine("++++++ 1. Current short date format");
            Console.WriteLine("++++++ 2. Current short time");
            Console.WriteLine("++++++ 3. Current long date format");
            Console.WriteLine("++++++ 4. Current long time format");
            Console.WriteLine("++++++ 0. Exit");
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++");
            Console.WriteLine();   
        }

        private void GetUserInput()
        {
            //User enters input

            Console.Write("++++++ Please choose an option: ");
            string strNumber = Console.ReadLine();
            Console.WriteLine();

            //Checks for valid input

            checkInput = int.TryParse(strNumber, out userInput);
            if (checkInput && userInput < 6 && userInput > 0)

            {
                Console.WriteLine("++++++++++++++++ YOUR VIRTUAL CLOCK +++++++++++++++");
                Console.WriteLine();
                ReturnDateTime();
            }
            else if (checkInput && userInput == 0)

            {
                ReturnDateTime();
            }

            else

            {
                Console.WriteLine("Wrongful input, please try again!");
            }
            
        }
        private void ReturnDateTime()
        {
            // Returns the date time according to users choice
            // Using Switch-statement

            
            switch (userInput)
            {
                
                case 1:
                    Console.WriteLine("Current short date is: "+DateTime.Now.ToString("d"));
                    break;
                case 2:
                    Console.WriteLine("Current short time is: "+DateTime.Now.ToString("t"));
                    break;
                case 3:
                    Console.WriteLine("Current long date is: "+DateTime.Now.ToString("F"));
                    break;
                case 4:
                    Console.WriteLine("Current long time is: "+DateTime.Now.ToString("T"));
                    break;
                case 0:
                    Console.WriteLine("Goodbye!");
                    Console.ReadLine();
                    break;
            
                             
            }
            Console.WriteLine();
        }
    }
}
