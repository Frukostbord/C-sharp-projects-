using Newtonsoft.Json;
using System;

namespace Apu_Animal_Park_4
{
    /// <summary>
    /// This class is responsible for creating an object of "Lizard". It´s a child class of Reptile:
    /// Animal -> Reptile -> Lizard
    /// </summary>

    [Serializable]
    public class Lizard : Reptile

    {
        //Field
        private string prefTerrain;

        //Constructor
        internal Lizard() { }
        public Lizard(string prefTerrain, int eggsize, int age, string name, float weight, Gender gender, string imagePath) : base(eggsize, age, name, weight, gender, imagePath)
        {
            this.prefTerrain = prefTerrain;
            AnimalDiet = AnimalDiet.Carnivore;
        }

        // Setter & Getter
        public string PrefTerrain { get { return prefTerrain; } set { prefTerrain = value; } }



        /// <summary>
        /// Returns an array of strings of extra information regarding the specific animal and animal category.
        /// </summary>
        /// <returns>Array of strings of extra animal information</returns>
        public override string[] GetSpecieInfo()
        {
            string[] extraInfo =
            {
                String.Format("{0,-15}{1}\n", "Animal:", ReptileTypes.Lizard.ToString()),
                String.Format("{0,-15}{1}\n", "Category:", AnimalType.Reptile.ToString()),
                String.Format("{0,-15}{1}\n", "Egg size", Eggsize.ToString()),
                String.Format("{0,-15}{1}", "Pref. terrain:", prefTerrain.ToString())

            };

            return extraInfo;
        }

    }


}
