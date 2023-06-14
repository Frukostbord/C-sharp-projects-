using Newtonsoft.Json;
using System;

namespace Apu_Animal_Park_4
{

    /// <summary>
    /// This class is responsible for creating an object of "Fish". It´s a child class of Animal:
    /// Animal -> Fish
    /// </summary>
    [Serializable]
    public abstract class Fish : Animal
    {
        // Field
        private int prefDepth;

        // Contructor
        internal Fish() { }
        public Fish(int prefDepth, int age, string name, float weight, Gender gender, string imagePath) : base(age, name, weight, gender, imagePath)
        {
            this.prefDepth = prefDepth;

        }

        // Setter & Getter
        public int PrefDepth
        {
            get { return prefDepth; }
            set { if (value > -1) { prefDepth = value; } }
        }


    }
}
