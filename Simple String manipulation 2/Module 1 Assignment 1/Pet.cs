using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Assignment_1
{
    class Pet
    {
        // Variables
        private string name;
        private int age;
        private bool isFemale;

        public void Start()
        {
            // Start of operation
            GetPetInfo();
            ReturnResult();
        }
        private void GetPetInfo()
        {
            // Getting input from user
            Console.Write("What´s your pet name? ");
            name = Console.ReadLine();

            Console.Write("What´s the age of your pet? ");
            string strAge = Console.ReadLine();
            age = int.Parse(strAge);

            Console.Write("Is your dog female (y/n)? ");
            string sex = Console.ReadLine();
            if (sex == "y")
            {
                isFemale = true;
            }
            else
            {
                isFemale = false;
            }


        }
        private void ReturnResult()
        // Returning input
        {
            Console.WriteLine("++++++++++++++++++++++++");
            Console.WriteLine($"Name: {name} Age: {age}");
            if (isFemale == true)
            {
                Console.WriteLine($"{name} is a good girl");
            }
            else
            {
                Console.WriteLine($"{name} is a good boy");
            }

            Console.WriteLine("++++++++++++++++++++++++");
            Console.WriteLine(" ");
            Console.WriteLine("Press Enter to start the next part!");
            Console.ReadLine();
        }
    }
}
