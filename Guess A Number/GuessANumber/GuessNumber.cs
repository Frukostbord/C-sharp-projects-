using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessANumber
{
    public class GuessNumber
    {
        // Variables
        private int randomNumber;
        private int numberUser;
        private int numberOfGuesses = 0;
        private bool correctGuess = false;
        private string playAgain = "Y";

        public void Start()
        {
            // Starting method
            // Loops until the user guesses correct

            Console.WriteLine("***************** GUESS THE NUMBER ******************");
            Console.WriteLine("The Computer selects a random value between 0 and 99.");
            Console.WriteLine("You have to guess the number");
            Console.WriteLine("The game will help you by letting you know if the guess number is" +
                "too high or too low!");
            Console.WriteLine("It also displays the number of attempts.");
            Console.WriteLine("***************** GUESS THE NUMBER ******************");
            Console.WriteLine();

            // Outer loop if you want to play again
            while (playAgain == "Y")
            {
                // Gets a random number
                RandomNumber();
                numberOfGuesses = 0;

                // Inner loop for one game
                do
                {
                    UserGuess();
                    ComparingGuess();
                } while (!correctGuess);

                Console.Write("Play again? (Y/N)");
                playAgain = Console.ReadLine();
                playAgain = playAgain.ToUpper();

            }
            Console.WriteLine("Now exiting the application. Bye!");
            Console.ReadLine();

        }

        private void RandomNumber()
        {
            // Random number 0-99
            Random random = new Random();
            randomNumber = random.Next(0,100);
           
        }

        private void UserGuess()
        {
            Console.Write("Attempt no. " + numberOfGuesses + ". Your guess (0-99): ");
            string strNumber = Console.ReadLine();
            numberUser = int.Parse(strNumber);
        }

        private void ComparingGuess()
        {
            numberOfGuesses++;
            if (numberUser > randomNumber)
            {
                Console.WriteLine("Too High!");
                Console.WriteLine();
            }

            else if (numberUser < randomNumber)
            {
                Console.WriteLine("Too Low!");
                Console.WriteLine();
            }

            else if (numberUser == randomNumber)
            {
                Console.WriteLine("++++++++++ Congratulations! ++++++++++");
                Console.WriteLine("It took you " + numberOfGuesses + " of attempts");
                Console.WriteLine();
                correctGuess = true;
            }
            
        }

    }
}
