using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Assignment_1
{
    class Album
    {
        // Variables
        private string albumName;
        private string artistName;
        private int numOfTracks;

        public void Start()
        {
            GetInput();
            ReturnValues();
        }

        private void GetInput()
        {
            // Getting input

            Console.WriteLine("What is the name of your favorite music album?");
            albumName = Console.ReadLine();

            Console.WriteLine($"What is the name of the Artist or Band for {albumName}?");
            artistName = Console.ReadLine();

            Console.WriteLine($"How many tracks does {albumName} have?");
            string strTrack = Console.ReadLine();
            numOfTracks = int.Parse(strTrack);
        }

        private void ReturnValues()
        {
            // Returning values

            Console.WriteLine("");
            Console.WriteLine($"Album name: {albumName}");
            Console.WriteLine($"Arist/Band: {artistName}");
            Console.WriteLine($"Numer of tracks: {numOfTracks}");
            Console.WriteLine("Enjoy listening!");
        }
            
    }
}
