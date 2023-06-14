using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Assignment_1_Grade_A_B
{
    class Car
    {
        static void Main()
        {
            Car car = new Car();
            car.GetInput();
            car.ReturnValues();

        }


        // Variables
        private DateTime dateandtime = DateTime.Now;
        private int horsepower;
        private double tirepressure;
        private int yearmodel;
        private string carbrand;


        private void GetInput()
        {
            Console.Write("What is the brand of your car?: ");
            carbrand = Console.ReadLine();

            Console.Write("What year model is your car?: ");
            string strModel = Console.ReadLine();
            yearmodel = int.Parse(strModel);

            Console.Write("What horse power does your car have?: ");
            string strPower = Console.ReadLine();
            horsepower = int.Parse(strPower);


            Console.Write("Recommended air pressure in the car´s tire (BAR)?: ");
            string strPressure = Console.ReadLine();
            tirepressure = double.Parse(strPressure);

        }

        private void ReturnValues()
        {
            Console.WriteLine("+++++++++++++++++");
            Console.WriteLine($"Car brand: {carbrand}");
            Console.WriteLine($"Year model: {yearmodel}");
            Console.WriteLine($"Horsepower: {horsepower}");
            Console.WriteLine($"Recommended tire pressure: {tirepressure} BAR");
            Console.WriteLine($"Date and time now: {dateandtime}");
            Console.WriteLine("+++++++++++++++++");
            Console.ReadLine();
        }
        
    }
}