using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2b
{
    class SquareRoot

    {
        private double number;
        public void Start()
        {

            bool calcAgain = true;

            //Calculate the root of anumber given by the user
            //Continue until the user decides to exit

            do
            {
                ReadNumber();
                CalculateRoot();

                calcAgain = CalculateAgain();

            }while(calcAgain);

        }
        private void ReadNumber()
        {
            Console.WriteLine("Please write a valid number: ");


            string strNumber = Console.ReadLine();

            number = double.Parse(strNumber);

            

        }
        private void CalculateRoot()
        {
            if (number >= 0)
            {
                double root = Math.Sqrt(number);
                Console.WriteLine("The square root of " + number + " is: " + root);

            }
            else
                Console.WriteLine("Negative numbers don´t have real numbers as answers!");

        }

        private bool CalculateAgain()
        {
            bool answer = false;
            bool goodAnswer = false;   


            Console.WriteLine();
            Console.Write("Do you want to continue? ");

            do
            {
                string str = Console.ReadLine();


                str = str.ToUpper();

                if (str == "Y")
                {
                    answer = true;
                    goodAnswer = true;
                }
                else if (str == "N")
                {
                    answer = false;
                    goodAnswer = true;
                }
                else
                {
                    Console.WriteLine("Please use a valid input!");
                    goodAnswer = false;
                }
            }while(!goodAnswer);

            return answer;
        }
        
    }
}
