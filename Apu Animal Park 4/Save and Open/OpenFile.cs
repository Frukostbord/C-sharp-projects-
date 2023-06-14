using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using Newtonsoft.Json;

namespace Apu_Animal_Park_4
{
    /// <summary>
    /// This class functions as a help class to FormMain for opening files in different format
    /// It has different methods for each file format.
    /// </summary>
    public class OpenFile
    {

        // Token & Verison control
        private const string fileVersionToken = "Apu_Animal_Park";
        private const double fileVersionNr = 1.013;

        #region Open Text file

        /// <summary>
        /// Opens a file and reads information, to add animals to animalmanager and food items to foodmanager by calling local methods.
        /// </summary>
        /// <param name="animalManager">AnimalManager with animal objects to be added</param>
        /// <param name="foodManager">FoodManager with fooditem objects to be added</param>
        /// <returns>True if saving was successful, else false</returns>
        public bool OpenTextFile(string filePath, AnimalManager animalManager, FoodManager foodManager)
        {
            StreamReader streamReader;
            FoodItem food;
            Animal animal;

           // Controlling path and objects are OK
           bool ok = !String.IsNullOrEmpty(filePath) && animalManager != null && foodManager != null;

           if (ok)
            {
                // Start to read file
                using (streamReader = new StreamReader(filePath))
                {
                    // Token and version control
                    string token = streamReader.ReadLine();
                    string verion = streamReader.ReadLine();

                    if (TokenVersionControl(token, verion))
                    {
                        // Getting amount of animals and food items
                        int animalsNr = int.Parse(streamReader.ReadLine());
                        int fooditemNr = int.Parse(streamReader.ReadLine());

                        // Iterating through each animal
                        for (int i = 0; i < animalsNr; i++)
                        {
                            animal = ReadAnimal(streamReader); // Calls local method to add animal
                            animalManager.AddAnimalWithID(animal); // Adds animal that already has Guid
                        }

                        // Iterating through each food item
                        for (int i = 0; i < fooditemNr; i++)
                        {
                            food = ReadFoodItem(streamReader); // Calls local method to add food item
                            Guid id;

                            foodManager.Add(food);
                            foodManager.AddFoodItemDictionary(food);

                            // Iterates through Guid´s belonging to the food item and adding them to the food item
                            int idCount = int.Parse(streamReader.ReadLine());

                            for (int y = 0; y < idCount; y++)
                            {
                                id = Guid.Parse(streamReader.ReadLine());
                                foodManager.AddIDtoFoodItem(food, id);
                            }

                        }

                    }

                }
                // If successful
                return true;


            }
           // If NOT successful
            return false;
        }

        /// <summary>
        /// Reads several lines that contain information of the child class and child child class, e.g:
        /// Animal -> Mammal (child class) -> Cat (child child class).
        /// Reads information that all Animals (parent class) has. Calls method CreateAnimal to create the animal and return it.
        /// </summary>
        /// <param name="streamReader">Current streamreader used to read the text file</param>
        /// <returns>An Animal object of the current animal read in the text file</returns>
        private Animal ReadAnimal(StreamReader streamReader)
        {
            Animal animal;

            // Getting Specie and Animal category information
            string[] animalInfo = new string[]
            {
                streamReader.ReadLine(), // Specie
                streamReader.ReadLine(), // Specie value
                streamReader.ReadLine(), // Specie value type
                streamReader.ReadLine(), // Category value
                streamReader.ReadLine(), // Category value type
            };

            int age = int.Parse(streamReader.ReadLine());
            string name = streamReader.ReadLine();
            float weight = float.Parse(streamReader.ReadLine());
            Gender gender = (Gender)Enum.Parse(typeof(Gender), streamReader.ReadLine());
            Guid id = Guid.Parse(streamReader.ReadLine());

            animal = CreateAnimal(animalInfo, age, name, weight, gender);

            animal.ID = id;

            return animal;

        }


        /// <summary>
        /// Creates an animal object from information in the parameters
        /// </summary>
        /// <param name="animalInfo">An array of information containing information about the child class and child child class different
        /// properties values and types.</param>
        /// <param name="age"></param>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        private Animal CreateAnimal(string[] animalInfo, int age, string name, float weight, Gender gender)
        {
            Animal animal = null;
            // Specie to create
            string specie = animalInfo[0];

            var specieInfo = GetValue(animalInfo[1], animalInfo[2]); // Getting specie value
            var categoryInfo = GetValue(animalInfo[3], animalInfo[4]); // Getting animal category info

            switch (specie) // Switch statemet on what animal to create
            {
                case "Snake":
                    animal = new Snake(specieInfo, categoryInfo, age, name, weight, gender, "");
                    break;
                case "Lizard":
                    animal = new Lizard(specieInfo, categoryInfo, age, name, weight, gender, "");
                    break;
                case "Dog":
                    animal = new Dog(specieInfo, categoryInfo, age, name, weight, gender, "");
                    break;
                case "Cat":
                    animal = new Cat(specieInfo, categoryInfo, age, name, weight, gender, "");
                    break;
                case "Bee":
                    animal = new Bee(specieInfo, categoryInfo, age, name, weight, gender, "");
                    break;
                case "Ant":
                    animal = new Ant(specieInfo, categoryInfo, age, name, weight, gender, "");
                    break;
                case "Goldfish":
                    animal = new Goldfish(specieInfo, categoryInfo, age, name, weight, gender, "");
                    break;
                case "Clownfish":
                    animal = new Clownfish(specieInfo, categoryInfo, age, name, weight, gender, "");
                    break;

            }

            return animal;

        }

        /// <summary>
        /// Reads lines in the currently open text file to create a food item and return it
        /// </summary>
        /// <param name="streamReader">Current streamreader used to read the text file</param>
        /// <returns>A fooditem object from the text file read</returns>
        private FoodItem ReadFoodItem(StreamReader streamReader)
        {
            FoodItem food = new FoodItem();

            string name = streamReader.ReadLine();
            int nrIngredients = int.Parse(streamReader.ReadLine());


            food.Name = name;

            // Adding ingredients
            for (int i = 0; i < nrIngredients; i++)
            {
                food.Add(streamReader.ReadLine());
            }

            return food;

        }


        /// <summary>
        /// Returns either a string or integer (dynamic) from a string given by the user.
        /// </summary>
        /// <param name="value">Value to be returned as a string or integer</param>
        /// <param name="type">Type of the value given</param>
        /// <returns>Integer or String value</returns>
        private dynamic GetValue(string value, string type)
        {
            switch (type)
            {
                case "Int32": // Parses to int if the value is an integer
                    int intValue = int.Parse(value);
                    return intValue;
            }
            return value;

        }

        /// <summary>
        /// Checks to see that file token and version is congruent to the program.
        /// </summary>
        /// <param name="token">Token to be checked</param>
        /// <param name="version">Version to be checked</param>
        /// <returns>True if values are congruent to the programs, else false</returns>
        private bool TokenVersionControl(string token, string version) => (token == fileVersionToken && version == fileVersionNr.ToString()) ? true : false;

        #endregion

        /// <summary>
        /// Calls animalManager method, that is inhereted by GenericListmanager to deserialize all animals in the json file in to animalManager.
        /// </summary>
        /// <param name="animalManager">AnimalManager´s animals to deserialize to animalManager</param>
        /// <returns>True if successful, else false</returns>
        public bool OpenJsonFile(string filePath, AnimalManager animalManager)
        {
            bool ok = !String.IsNullOrEmpty(filePath) && animalManager != null;

            if (ok)
            {
                animalManager.JsonDeserialization(filePath);

                return true;
            }
            return false;
        }


        /// <summary>
        /// Calls animalManager method, that is inhereted by GenericListmanager to deserialize all animals in the binary serialized 
        /// file in to animalManager.
        /// </summary>
        /// <param name="animalManager">AnimalManager´s animals to deserialize to animalManager</param>
        /// <returns>True if successful, else false</returns>
        public bool OpenBinaryFile(string filePath, AnimalManager animalManager)
        {
            bool ok = !String.IsNullOrEmpty(filePath)&&animalManager!=null;

            if (ok)
            {
                animalManager.BinaryDeserialization(filePath);

                return true;
            }
            return false;

        }

        /// <summary>
        /// Opens a XML file containing food items and adding it to the current object of FoodManager.
        /// </summary>
        /// <param name="filePath">Path to deserialize</param>
        /// <param name="foodManager">Null check of object</param>
        /// <returns>Boolean value is deserialization if successful</returns>
        public bool OpenXMLFile(string filePath, FoodManager foodManager)
        {
            bool ok = !String.IsNullOrEmpty(filePath) && foodManager != null;

            if(ok)
            {
                foodManager.XMLDeserialization(filePath);
                return true;
            }
            return false;
        }


        
    }
}
