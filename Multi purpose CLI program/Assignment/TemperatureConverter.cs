using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class TemperatureConverter
    {
        private const int max = 100;
        public void Start()
        {
            // Starts menu
            StartMenu();
        }

        private void StartMenu()
        {
            bool done = false;
            // Showing menu for user
            do
            {
                Console.WriteLine("_________________________________________\n\n        TEMPERATURE CONVERTER");
                Console.WriteLine("_________________________________________");
                Console.WriteLine("\nCelcius to Fahrenheit {0,6}", ": 1");
                Console.WriteLine("Fahrenheit to Ceclius {0,6}", ": 2");
                Console.WriteLine("Exit {0,23}", ": 0");
                Console.WriteLine("_________________________________________");
                Console.Write("\nYour choice: ");
                string strChoice = Console.ReadLine();
                Console.WriteLine();

                // Switch case depending on what the users selects
                switch (strChoice)
                {
                    case "0":
                        done = true;
                        break;
                    case "1":
                        ShowTableCelciusToFahrenheit();
                        break;
                    case "2":
                        ShowTableFahrenheitToCelcius();
                        break;
                }

            } while (!done);

            Console.WriteLine("\nHave a great day, sir or madame.");
            Console.ReadLine();
        }
        private double CelciusToFahrenheit(double celcius)
        {
            // Converting Celcius to Fahrenheit
            double fahrenheit = (celcius+32.00) * (9.00 / 5.00) ;
            return fahrenheit;
        }

        private double FahrenheitToCelcius(double fahrenheit)
        {
            // Converting Fahrenheit to Celcius
            double celcius = (fahrenheit - 32.00) * (5.00/9.00);
            return celcius;
        }

        private void ShowTableCelciusToFahrenheit()
        {
            // Looping through and presenting every fourth value
            // Calling another method for temperature conversion
            for (double celcius = 0; celcius < max + 1; celcius += 4)
            {
                double fahrenheit = CelciusToFahrenheit(celcius);
                Console.WriteLine("{0,4} C = {1:0.00} F", celcius, fahrenheit);

            }
            Console.WriteLine();
        }

        private void ShowTableFahrenheitToCelcius()
        {
            // Looping through and presenting every fourth value
            // Calling another method for temperature conversion
            for (double fahrenheit = 0; fahrenheit < max+1; fahrenheit+=4)
            {
                double celcius = FahrenheitToCelcius(fahrenheit);
                Console.WriteLine("{0,4} F = {1:0.00} C", fahrenheit, celcius);

            }
            Console.WriteLine();
        }

    }
}
