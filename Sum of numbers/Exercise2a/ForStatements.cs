using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2a
{
    public class ForStatements
    {
        public void Start()
        {
            SumNumbers();
            SumNumbersFromOneTo();
        }

        private void SumNumbers()
        {
            int sum = 0;
            for (int i = 0; i <= 20; i++)
            {
                sum += i;
            }
            Console.WriteLine("The sum of 1 to 20 is : " + sum);
        }
        private void SumNumbersFromOneTo()
        {
            int endNumber = 0;
            int sum = 0;

            Console.WriteLine("Sum up numbers from 1 to x.");
            Console.Write("Give x: ");
            string strNum = Console.ReadLine();
            endNumber = int.Parse(strNum);


            for (int i = 0; i <= endNumber; i++)
            {
                sum += i;
            }
            Console.WriteLine("The sum of 1 to " + endNumber + " is : " + sum);
        }
    }
}
