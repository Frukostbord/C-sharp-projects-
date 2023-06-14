using Newtonsoft.Json;
using System;

namespace Apu_Animal_Park_4

{
    /// <summary>
    /// This class is responsible for creating an object of "Snake". It´s a child class of Reptile:
    /// Animal -> Reptile -> Snake
    /// </summary>
    [Serializable]
    public class Snake : Reptile
    {
        // Field
        private string venomEffect;

        // Constructor
        internal Snake() { }
        
        public Snake(string venomEffect, int eggsize, int age, string name, float weight, Gender gender, string imagePath) :
            base(eggsize, age, name, weight, gender, imagePath)

        {
            this.venomEffect = venomEffect;
            AnimalDiet = AnimalDiet.Carnivore;
        }



        // Setter & Getter
        public string VenomEffect { get { return venomEffect; } set { venomEffect = value; } }

        /// <summary>
        /// Returns an array of strings of extra information regarding the specific animal and animal category.
        /// </summary>
        /// <returns>Array of strings of extra animal information</returns>
        public override string[] GetSpecieInfo()
        {
            string[] extraInfo =
            {
                String.Format("{0,-15}{1}\n", "Animal:", ReptileTypes.Snake.ToString()),
                String.Format("{0,-15}{1}\n", "Category:", AnimalType.Reptile.ToString()),
                String.Format("{0,-15}{1}\n", "Egg size", Eggsize.ToString()),
                String.Format("{0,-15}{1}", "Venom Effect:", venomEffect.ToString())

            };

            return extraInfo;
        }

    }
}
