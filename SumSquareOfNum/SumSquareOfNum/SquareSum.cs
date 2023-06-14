using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumSquareOfNum
{
    public class SquareSum
    {
        int numberuser;
        int countiterations = 0;
        int sumofiterations;

        public void Start()
        {
            //1. Get number
            //2. Iterate
            //3. Present result
            NumberToReach();
            CalculateSquareSum();
            PresentResult();

            
        }

        private void NumberToReach()
        {
            // Getting number from the user


            Console.WriteLine("Write a whole number (e.g. 500) " +
                "to return the number of iterations that is takes " +
                "for the sum of squares, 1*1 + 2*2 + 3*3... ");

            // Converting string to int
            string strNumber = Console.ReadLine();
            numberuser = int.Parse(strNumber);
            
        }

        private void CalculateSquareSum()
        {

            // 1. Loops between 0 to number given by user
            // 2. Continues to loop until the sum is >= 5650

            while(numberuser > sumofiterations)
            {
                countiterations++;
                sumofiterations += countiterations * countiterations;
            }
            
        }
        private void PresentResult()
        {
            Console.WriteLine("It took " + countiterations + " iterations for the sum to " +
                "get to or exceed " + numberuser + $" (sum = {sumofiterations})");
        }
     
    }
}
