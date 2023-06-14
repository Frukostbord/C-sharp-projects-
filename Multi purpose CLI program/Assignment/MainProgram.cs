using Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class MainProgram
    {
        static void Main()
        {
            
            // Calls all other classes
            Console.Title = "Strings, selection and iteration in C#";
            FunFeatures funObjs = new FunFeatures();
            funObjs.Start();

            ContinueToNextPart();

            Console.Title = "Basic arithmetics";
            MathWork mathWork = new MathWork();
            mathWork.Start();

            ContinueToNextPart();

            Console.Title = "Temperature Converter";
            TemperatureConverter temperatureConverter = new TemperatureConverter();
            temperatureConverter.Start();

            ContinueToNextPart();
        
            Console.Title = "Working Schedule";
            WorkingSchedule workingSchedule = new WorkingSchedule();
            workingSchedule.Start();


        }

        private static void ContinueToNextPart()
        {
            Console.WriteLine("\nPLEASE ENTER TO CONTINUE TO THE NEXT PART");
            Console.ReadLine();
            Console.Clear();

        }
    }
}
