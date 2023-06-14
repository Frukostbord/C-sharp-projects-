using Newtonsoft.Json;
using System;

namespace Apu_Animal_Park_4
{

    /// <summary>
    /// This class is responsible for creating an object of "Goldfish". It´s a child class of fish:
    /// Animal -> Fish -> Goldfish
    /// </summary>
    [Serializable]
    public class Goldfish : Fish
    {
        // Field
        private int memoryLength;


        // Constructor
        internal Goldfish() { }
        public Goldfish(int memoryLength, int nrOfLimbs, int age, string name, float weight, Gender gender, string imagePath) :
        base(nrOfLimbs, age, name, weight, gender, imagePath)
        {
            this.memoryLength = memoryLength;
            AnimalDiet = AnimalDiet.Omnivore;
        }

        // Setter & Getter
        public int MemoryLength { get { return memoryLength; } set { if (value > 0) { memoryLength = value; } } }



        /// <summary>
        /// Returns an array of strings of extra information regarding the specific animal and animal category.
        /// </summary>
        /// <returns>Array of strings of extra animal information</returns>
        public override string[] GetSpecieInfo()
        {
            string[] extraInfo =
            {
                String.Format("{0,-15}{1}\n", "Animal:", FishTypes.Goldfish.ToString()),
                String.Format("{0,-15}{1}\n", "Category:", AnimalType.Fish.ToString()),
                String.Format("{0,-15}{1}\n", "Pref. Depth", PrefDepth.ToString()),
                String.Format("{0,-15}{1}", "Memory Length:", memoryLength.ToString())

            };

            return extraInfo;
        }

    }
}
