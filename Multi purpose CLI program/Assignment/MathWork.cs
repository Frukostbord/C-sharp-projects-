using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class MathWork
    {
        public void Start()
        {
            bool done;
            // Loops methods
            do
            {
                SumNumbers();
                CalculateSquareRoots();
                PrintMultiplicationTable();

                // Ends if correct input is given by user
                done = ExitCalculations();
            } while (!done);
        }

        private bool ExitCalculations()
        {
            // Getting user input
            Console.Write("Exit Calculations? (Y/N)");
            string strExit = Console.ReadLine(); 

            // Returing true if input == "Y/y", else continue
            if(strExit.ToUpper() == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
 

        private void SumNumbers()
        {
                // Getting input from user
                Console.WriteLine("Sum numbers between any two numbers");
                Console.Write("\nGive start number: ");
                string strStart = Console.ReadLine();
                Console.Write("\nGive end number: ");
                string strEnd = Console.ReadLine();

                // Converting type
                int startNumber = int.Parse(strStart);
                int endNumber = int.Parse(strEnd);

                // Correcting for lowest and highest value
                int lowNumber = Math.Min(startNumber, endNumber);
                int highNumber = Math.Max(startNumber, endNumber);


                // Calling other methods for results and displaying them
                int sum = SumNumbers(lowNumber,highNumber);   
                Console.WriteLine($"\nThe sum of numbers between {lowNumber} and (including) {highNumber} is: {sum}");
                PrintEvenNumbers(lowNumber, highNumber);            
        }

        private int SumNumbers(int startNum, int endNum)
        {

            // Adds all numbers between startNum and endNum
            int sum = 0;
            for (int i = startNum; i < endNum+1; i++)
            {
                sum += i;
            }

            // Returns answer
            return sum;

        }

        private void PrintEvenNumbers(int start, int end)

        {
            // Local variable
            string sumEven = "";

            // Performing calculations
            for(int i = start;i<end;i++)
            {
                if (i % 2 == 0)
                {                                 
                    sumEven += $"  {i}";
                }
            }

            // Returning results
            Console.WriteLine($"\nEven numbers between {start} and {end}: ");
            Console.WriteLine(sumEven);
            Console.WriteLine();

        }
        private void PrintMultiplicationTable()
        {
            Console.WriteLine("          ********* MULTIPLICATION TABLE *********");

            // Iterating through rows
            for (int row = 1; row < 13; row++)
            {
                // New line for each row
                Console.WriteLine();
                for (int column = 1; column < 13; column++)
                {
                    Console.Write(string.Format("{0,4:d} ", row*column)); 
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private void CalculateSquareRoots()
        {
            // Local variables
            int rows, columns = 0;

            // Reading rows and columns as strings, then converting them to integers
            Console.WriteLine("Number of rows?");
            rows = int.Parse(Console.ReadLine());

            Console.WriteLine("Number of columns?");
            columns = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                for (int k = 0; k < columns; k++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(Math.Sqrt(i * j).ToString("f3") + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
