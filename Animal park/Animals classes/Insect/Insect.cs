using Newtonsoft.Json;
using System;

namespace Apu_Animal_Park_4
{
    /// <summary>
    /// This class is responsible for creating an object of "Insect". It´s a child class of Animal:
    /// Animal -> Insect
    /// </summary>
    [Serializable]
    public abstract class Insect : Animal

    {
        // Field
        private int nrOfLimbs;

        // Contructor
        internal Insect() { }
        public Insect(int nrOfLimbs, int age, string name, float weight, Gender gender, string imagePath) : base(age, name, weight, gender, imagePath)
        {
            this.nrOfLimbs = nrOfLimbs;

        }

        // Setter & Getter
        public int NrOfLimbs { get { return nrOfLimbs; } set { if (value > 0) { nrOfLimbs = value; } } }


    }
}
