using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class WorkingSchedule
    {
        // instance variable
        private int userChoice = 0;

        public void Start()
        {
            // Shows startmenu
            StartMenu();
        }
        
        private void StartMenu()
        {
            Console.WriteLine("{0:15}", "YOUR WORK SCHEDULE");

            bool done = false;
            do
            {
                // Showing menu
                Console.WriteLine("_____________________________________________");
                Console.WriteLine("\n1. Show a list of weekends to work.");
                Console.WriteLine("2. Show a list of nights to work.");
                Console.WriteLine("0. Exit\n");
                Console.Write("Your choice: ");

                // Controlling input
                string strChoice = Console.ReadLine();
                bool controlInput = ControlInput(strChoice);
                Console.WriteLine();

                // If value given by user is an integer and is a 0, 1 or 2
                if (controlInput)
                {
                    if (userChoice == 0)
                    {
                        done = true;
                    }
                    else if (userChoice == 1 || userChoice == 2)
                    {
                        UsersWorkingSchedule();
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease look over your input!\n");
                }
                  
            } while (!done);
            Console.WriteLine("\nThat´s it folk!");
        }

        private bool ControlInput(string strControl)
        {
            // Checking if option is valid
            bool validOption;
            validOption = int.TryParse(strControl, out userChoice);

            // True if the option is an valid integer within range, else false
            if (validOption && userChoice >=0 && userChoice <= 2)
            {
                return true;
            }

            else
            {
                return false;
            }

        }

        private void UsersWorkingSchedule()
        {
            // Local variables
            int count = 0;
            int interval = 2;

            // Interval = every x week person has to work (every 3rd week according to command prompt,
            // but every 4th in text description, in the assignemnt. I used every 3rd week).
            if (userChoice == 1)
            {
                interval = 3;
            }

            // Loops through entire calender year
            // Prints one row when 4 values have met the criteria
            for (int week = 1; week < 53; week += interval)
            {
                if (count == 4)
                {
                    Console.WriteLine();
                    count = 0;
                }
                Console.Write("Week {0,2}  ", week);
                count++;    
            }

            Console.WriteLine();
        }
            
        
    }
}
