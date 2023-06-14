using Newtonsoft.Json;
using System;

namespace Apu_Animal_Park_4
{

    /// <summary>
    /// This class is responsible for creating an object of "Bee". It´s a child class of Insect:
    /// Animal -> Insect -> Bee
    /// </summary>
    [Serializable]
    public class Bee : Insect
    {

        //Field
        private string prefFlower;


        // Constructor
        internal Bee() { }
        public Bee(string prefFlowers, int nrOfLimbs, int age, string name, float weight, Gender gender, string imagePath) : base(nrOfLimbs, age, name, weight, gender, imagePath)
        {
            this.prefFlower = prefFlowers;
            AnimalDiet = AnimalDiet.Herbivore;
        }

        // Setter & Getter
        public string PrefFlowers { get { return prefFlower; } set { prefFlower = value; } }


        /// <summary>
        /// Returns an array of strings of extra information regarding the specific animal and animal category.
        /// </summary>
        /// <returns>Array of strings of extra animal information</returns>
        public override string[] GetSpecieInfo()
        {
            string[] extraInfo =
            {
                String.Format("{0,-15}{1}\n", "Animal:", InsectTypes.Bee.ToString()),
                String.Format("{0,-15}{1}\n", "Category:", AnimalType.Insect.ToString()),
                String.Format("{0,-15}{1}\n", "Nr. Limbs", NrOfLimbs.ToString()),
                String.Format("{0,-15}{1}", "Pref. Flower:", prefFlower.ToString())

            };

            return extraInfo;
        }
    }
}
