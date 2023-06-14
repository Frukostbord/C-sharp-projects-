using Newtonsoft.Json;
using System;

namespace Apu_Animal_Park_4
{
    /// <summary>
    /// This class is responsible for creating an object of "Dog". It´s a child class of Mammal:
    /// Animal -> Mammal -> Dog
    /// </summary>
    [Serializable]
    public class Dog : Mammal

    {
        // Field
        private string breed;




        // Constructors
        public Dog() { }
        public Dog(string breed, int nrTeeth, int age, string name, float weight, Gender gender, string imagePath) : base(nrTeeth, age, name, weight, gender, imagePath)
        {
            this.breed = breed;
            AnimalDiet = AnimalDiet.Omnivore;
        }


        // Setter & Getter
        public string Breed { get { return breed; } set { breed = value; } }


        /// <summary>
        /// Returns an array of strings of extra information regarding the specific animal and animal category.
        /// </summary>
        /// <returns>Array of strings of extra animal information</returns>
        public override string[] GetSpecieInfo()
        {
            string[] extraInfo =
            {
                String.Format("{0,-15}{1}\n", "Animal:", MammalTypes.Dog.ToString()),
                String.Format("{0,-15}{1}\n", "Category:", AnimalType.Mammal.ToString()),
                String.Format("{0,-15}{1}\n", "Nr. teeth", NrTeeth.ToString()),
                String.Format("{0,-15}{1}", "Breed:", breed.ToString())

            };

            return extraInfo;
        }

    }
}
