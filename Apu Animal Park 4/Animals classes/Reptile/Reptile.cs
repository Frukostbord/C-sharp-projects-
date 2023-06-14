using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Apu_Animal_Park_4
{
    /// <summary>
    /// This class is responsible for creating an object of "Reptile". It´s a child class of Animal:
    /// Animal -> Reptile
    /// </summary>

    [Serializable]
    public abstract class Reptile : Animal

    {
        //Field
        private int eggSize;

        //Constructor
        internal Reptile() { }
        
        public Reptile(int eggSize, int age, string name, float weight, Gender gender, string imagePath) :
            base(age, name, weight, gender, imagePath)
        {

            this.eggSize = eggSize;
        }

        // Setter & Getter
        public int Eggsize { get { return eggSize; } set { if (value > 0) { eggSize = value; } } }

    }
}
