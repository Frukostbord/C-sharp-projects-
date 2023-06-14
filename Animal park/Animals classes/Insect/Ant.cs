using Newtonsoft.Json;
using System;

namespace Apu_Animal_Park_4
{
    /// <summary>
    /// This class is responsible for creating an object of "Ant". It´s a child class of Insect:
    /// Animal -> Insect -> Ant
    /// </summary>
    [Serializable]
    public class Ant : Insect

    {
        // Field
        private int nrQueens;


        // Constructor
        internal Ant() { }
        public Ant(int nrQueens, int nrOfLimbs, int age, string name, float weight, Gender gender, string imagePath) : base(nrOfLimbs, age, name, weight, gender, imagePath)
        {
            this.nrQueens = nrQueens;
            AnimalDiet = AnimalDiet.Omnivore;
        }


        // Setter & Getter
        public int NrQueens { get { return nrQueens; } set { if (value > 0) { nrQueens = value; } } }



        /// <summary>
        /// Returns an array of strings of extra information regarding the specific animal and animal category.
        /// </summary>
        /// <returns>Array of strings of extra animal information</returns>
        public override string[] GetSpecieInfo()
        {
            string[] extraInfo =
            {
                String.Format("{0,-15}{1}\n", "Animal:", InsectTypes.Ant.ToString()),
                String.Format("{0,-15}{1}\n", "Category:", AnimalType.Insect.ToString()),
                String.Format("{0,-15}{1}\n", "Nr. Limbs", NrOfLimbs.ToString()),
                String.Format("{0,-15}{1}", "Nr. Queens:", nrQueens.ToString())

            };

            return extraInfo;
        }
    }
}
