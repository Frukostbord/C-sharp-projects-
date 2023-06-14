using Newtonsoft.Json;
using System;

namespace Apu_Animal_Park_4
{
    /// <summary>
    /// This class is responsible for creating an object of "Mammal". It´s a child class of Animal:
    /// Animal -> Mammal
    /// </summary>
    [Serializable]
    public abstract class Mammal : Animal
    {
        // Field
        private int nrTeeth;


        // Constructors
        internal Mammal() { }
        public Mammal(int nrTeeth, int age, string name, float weight, Gender gender, string imagePath) : base(age, name, weight, gender, imagePath)
        {
            this.nrTeeth = nrTeeth;
        }

        // Getter
        public int NrTeeth { get { return nrTeeth; } }



    }
}
