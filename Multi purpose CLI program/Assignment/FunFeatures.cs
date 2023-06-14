using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class FunFeatures
    {
        private string name = "";
        private string email = "";


        public void Start()
        {
            Introduce();

            bool done = false;
            do
            {
                //Call method to read a number 1 to 7 and display the
                //name of teh day (1-Monday, 7-Sunday) with a comment.
                PredictTheDay();

                //Calculate the length of a given text
                CalculateStringLength();

                //Run again or exit
                done = RunAgain();

            } while (!done);

            // Goodbye message is program is exited
            string strName = ReadName();
            Console.WriteLine($"Goodbye {strName}");

        }

        private void Introduce()

        {   // Short introduction to the program
            Console.WriteLine("Hello there! My name is Andreas and i´m a student at Malmö University.");
            Console.WriteLine("Please enjoy this small program. Take care!");
            Console.WriteLine("\nLet me know about yourself");
            
            // Getting users name and e-mail
            Console.Write("\nYour first name please: ");
            name = Console.ReadLine();
            Console.Write("Your last name please: ");
            name = $"{name} " + Console.ReadLine().ToUpper();

            Console.Write("Give me your email please: ");
            email = Console.ReadLine();

            // Printing out information the user has given us.
            Console.WriteLine("\nHere is your full name and email: ");

            string strName = ReadName();
            Console.WriteLine($"\n{strName} {email}");

        }

        private string ReadName()
        {
            // Splitting string, then reversing order
            // This only works for people with ONE first AND last name
            string[] subName = name.Split(" ");
            string strName = $"{subName[1]}, {subName[0]}";

            // Returning string
            return strName;
        }

        private void PredictTheDay()
        {   
            // Promting user for input
            Console.WriteLine("\nPlease choose a number from 1 to 7, 1 being Monday and 7 Sunday.");
            string dayChoosen = Console.ReadLine();
            int day = int.Parse(dayChoosen);

            // Controlling input, if correct input is given
            // Switch statement is used to give a fortune
            if(day < 1 || day > 7)
            {
                Console.WriteLine("\nNot in a good mode? This is not a valid option!");            
            }
            else
            {
                switch (day)
                {
                    case 1:
                        Console.WriteLine("\nMonday: Keep calm my friend! You can fall apart!");
                        break;
                    case 2:
                        Console.WriteLine("\nTuesday will break your heart!");
                        break;
                    case 3:
                        Console.WriteLine("\nWednesday, or as we say in Sweden: 'Lill-Lördag'. Prepare for party!");
                        break;
                    case 4:
                        Console.WriteLine("\nThursday, OMG, still one day to Friday!");
                        break;
                    case 5:
                        Console.WriteLine("\nIt's Friday! You are in love!");
                        break;
                    case 6:
                        Console.WriteLine("\nSaturday, do nothing and do plenty of it!");
                        break;
                    case 7:
                        Console.WriteLine("\nAnd Sunday always comes too soon!");
                        break;
                }
            }

        }

        private void CalculateStringLength()
        {
            // Getting users input
            // Calculating string length
            Console.WriteLine("\nPlease write something and i´ll calculate the length of the input");
            string inputString = Console.ReadLine();
            int length = inputString.Length;

            // Returning string length as message
            Console.WriteLine($"The length of your input is: {length} characters");


        }

        private bool RunAgain()
        {

            //User inputs if the program is to continue running (Y/N)
            //Returns boolean value
            Console.WriteLine();
            Console.WriteLine("\nExit calculation? (Y/N)\n");
            string strLoopControl = Console.ReadLine();

            if(strLoopControl.ToUpper() == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
