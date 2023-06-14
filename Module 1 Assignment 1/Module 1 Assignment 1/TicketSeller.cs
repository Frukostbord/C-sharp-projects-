using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Assignment_1
{
    class TicketSeller
    {
            // Variables
            private string name; 
            private double price = 100; 
            private int numOfAdults; 
            private int numOfChildren; 
            private double amountToPay;

        
        public void Start()
        {
            // Starts the methods in this class
            
            Console.WriteLine("Welcome to the KIDS FAIR!");
            Console.WriteLine("Children always get a 75% discount!");
            Console.WriteLine(" ");
            GetInput();
            ReturnValues();


        }
        private void GetInput()
        {
            // Methods for obtaining input

            Console.WriteLine("Your name please:");
            name = Console.ReadLine();

            Console.WriteLine("Number of adults:");
            string strAdults = Console.ReadLine();
            numOfAdults = int.Parse(strAdults);

            Console.WriteLine("Number of children:");
            string strChildren = Console.ReadLine();
            numOfChildren = int.Parse(strChildren);

            amountToPay = (numOfChildren * price * 0.25) + (numOfAdults * price);

        }
        private void ReturnValues()
        {
            // Returns results
            Console.WriteLine(" +++ Your receipt +++");
            Console.WriteLine($" +++ Amount to pay = {amountToPay} +++");
            Console.WriteLine($"Thank you {name} and please come back again!");
            Console.WriteLine(" ");
            Console.WriteLine("Press Enter to start the next part!");
            Console.ReadLine();
        }
        
    }
}
