using Newtonsoft.Json;
using System;

namespace Apu_Animal_Park_4
{   /// <summary>
    /// This class is responsible for creating an object of "Cat". It´s a child class of Mammal:
    /// Animal -> Mammal -> Cat
    /// </summary>
    [Serializable]
    public class Cat : Mammal
    {
        //Field
        private string furColor;


        // Constructor
        internal Cat() { }

        internal Cat(string furColor, int nrTeeth, int age, string name, float weight, Gender gender, string imagePath) :
        base(nrTeeth, age, name, weight, gender, imagePath)
        {
            this.furColor = furColor;
            AnimalDiet = AnimalDiet.Carnivore;
        }


        // Setter & Getter
        public string FurColor { get { return furColor; } set { furColor = value; } }


        /// <summary>
        /// Returns an array of strings of extra information regarding the specific animal and animal category.
        /// </summary>
        /// <returns>Array of strings of extra animal information</returns>
        public override string[] GetSpecieInfo()
        {
            string[] extraInfo =
            {
                String.Format("{0,-15}{1}\n", "Animal:", MammalTypes.Cat.ToString()),
                String.Format("{0,-15}{1}\n", "Category:", AnimalType.Mammal.ToString()),
                String.Format("{0,-15}{1}\n", "Nr. Teeth", NrTeeth.ToString()),
                String.Format("{0,-15}{1}", "Fur color:", furColor.ToString())

            };

            return extraInfo;
        }

    }
}
