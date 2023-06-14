using Newtonsoft.Json;
using System;

namespace Apu_Animal_Park_4
{

    /// <summary>
    /// This class is responsible for creating an object of "Clownfish". It´s a child class of fish:
    /// Animal -> Fish -> Clownfish
    /// </summary>
    [Serializable]
    public class Clownfish : Fish
    {
        // Field
        private int nrStripes;

        // Constructor
        internal Clownfish() { }
        public Clownfish(int nrStripes, int nrOfLimbs, int age, string name, float weight, Gender gender, string imagePath) : base(nrOfLimbs, age, name, weight, gender, imagePath)
        {
            this.nrStripes = nrStripes;
            AnimalDiet = AnimalDiet.Carnivore;
        }

        // Setter & Getter
        public int NrStripes { get { return nrStripes; } set { if (value > 0) { nrStripes = value; } } }


        /// <summary>
        /// Returns an array of strings of extra information regarding the specific animal and animal category.
        /// </summary>
        /// <returns>Array of strings of extra animal information</returns>
        public override string[] GetSpecieInfo()
        {
            string[] extraInfo =
            {
                String.Format("{0,-15}{1}\n", "Animal:", MammalTypes.Cat.ToString()),
                String.Format("{0,-15}{1}\n", "Category:", AnimalType.Reptile.ToString()),
                String.Format("{0,-15}{1}\n", "Pref. Depth", PrefDepth.ToString()),
                String.Format("{0,-15}{1}", "Nr. Stripes:", nrStripes.ToString())

            };

            return extraInfo;
        }

    }
}
