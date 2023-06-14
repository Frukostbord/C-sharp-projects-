using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Apu_Animal_Park_4
{
    [Serializable]
    [XmlInclude(typeof(Snake)), XmlInclude(typeof(Lizard)), XmlInclude(typeof(Dog)), 
        XmlInclude(typeof(Cat)), XmlInclude(typeof(Bee)), XmlInclude(typeof(Ant)), 
        XmlInclude(typeof(Goldfish)), XmlInclude(typeof(Clownfish))]
    public abstract class Animal : IAnimal
    {

        // Field
        private int age; // in years
        private string name;
        private float weight; // in kilograms
        [NonSerialized]
        private string imagePath;
        private Guid id;
        private Gender gender;
        private AnimalDiet animalDiet;

        // Constructor
        internal Animal() { }

        internal Animal(int age, string name, float weight, Gender gender, string imagePath)
        {
            this.age = age;
            this.name = name;
            this.weight = weight;
            this.gender = gender;

        }


        // Setters & Getters 
        public int Age { get { return age; } set { if (value > -1) { age = value; } } }
        public string Name { get { return name; } set { name = value; } }
        public float Weight { get { return weight; } set { if (value > 0) { weight = value; } } }
        public Guid ID
        {
            get { return id; }
            set
            {
                bool isValid = Guid.TryParse(value.ToString(), out Guid guidOutput);

                if (isValid)
                    id = value;
            }
        }
        public Gender Gender { get { return gender; } set { gender = value; } }

        [JsonIgnore]
        [XmlIgnore]
        public string ImagePath { get { return imagePath; } set { if (value != null) { imagePath = value; } } }


        public AnimalDiet AnimalDiet
        {
            get { return animalDiet; }

            set

            {
                bool isValid = Enum.TryParse(value.ToString(), out AnimalDiet animalDiet);

                if (isValid) { this.animalDiet = value; }
            }
        }

        /// <summary>
        /// Truncates the id of the animal
        /// </summary>
        /// <returns>A truncated string of the animal´s ID</returns>
        public string IdTrunc()
        {
            string idTrunc;
            idTrunc = id.ToString().Substring(0, 4);

            return idTrunc;
        }

        /// <summary>
        /// Virtual array of strings to be edited in subclasses for each respective animal.
        /// </summary>
        /// <returns>Dummy class, to be expanded upon in subclasses to Animal</returns>
        public virtual string[] GetSpecieInfo()
        {
            string[] extraInfo = { "category" };
            return extraInfo;
        }

        /// <summary>
        /// This method returns a string of the object created.
        /// </summary>
        /// <returns>String of all information related to the object.</returns>
        public string[] AnimalInfo()
        {
            string[] animalInfo =
            {
                IdTrunc(),
                name,
                weight.ToString(),
                age.ToString(),
                gender.ToString()
            };
            return animalInfo;
        }
    }


}
