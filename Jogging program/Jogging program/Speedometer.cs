using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogging_program
{
    internal class Speedometer
    {
        //1. Input needed for calculation
        //2. Calculate - process data
        //3. Display result

        private float distance;
        private float time;
        private string name;
        private int age;

        //Output variables (attributes, fields)
        private float speed;

        #region Main Steps
        //Method
        public void Start()
        {
            ReadInput();
            Calculate();
            DisplayResults();
        }
        #endregion
        #region Read Input

        private void ReadInput()
        {
            ReadName();
            ReadAge();
            ReadDistance();
            ReadTime();
        }
        #endregion

        #region Get Input
        private void ReadAge()
        {
            Console.WriteLine("Whats your age?");
            string strAge = Console.ReadLine();
            age = int.Parse(strAge);
        }
        private void ReadName()
        {
            Console.WriteLine("Whats your name?");
            name = Console.ReadLine();
        }

        private void ReadDistance()
        {
            Console.WriteLine("Whats the distance in meter?");
            string strDistance = Console.ReadLine();
            distance = float.Parse(strDistance);
        }
        private void ReadTime()
        {
            Console.WriteLine("Whats the time?");
            string strTime = Console.ReadLine();
            time = float.Parse(strTime);
        }
        #endregion
        #region Calculations

        public void Calculate()

        {
            //Time per unit
            if (time != 0)
                speed = distance / time;
            else
            {
                Console.WriteLine("Time can´t be zero!");
                speed = -1;
            }
        }
        public void CalculaeKPperH()
        {
            distance = distance / 1000;
            time = time / 60;

            speed = distance / time;
        }

        #endregion

        #region Display results
        public void DisplayResults()
        {
            Console.WriteLine();
            Console.WriteLine(" +++++++++++++++++++++ ");
            Console.WriteLine($"Good job on your time {name}");
            Console.WriteLine($"Your speed is {speed,10:f2}!");
            Console.WriteLine();
            CalculaeKPperH();
            Console.WriteLine($"Your speed is {speed,4:f2} km/hr based on distance {distance,4:f2} km and time at {time,4:f2} minutes");
            bool isChild = (age <= 18);
            if (isChild)
                Console.WriteLine("This is a good time for a child");
            #endregion
        }
    }
}
