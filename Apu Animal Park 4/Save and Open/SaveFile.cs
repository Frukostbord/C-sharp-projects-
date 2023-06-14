using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Apu_Animal_Park_4
{
    /// <summary>
    /// This class functions as a help class to FormMain for saving files in different format
    /// It has different methods for each file format.
    /// </summary>
    internal class SaveFile
    {

        // Local variables used to marking the files whilst saving and controlling whilst opening
        private string filePath;
        private string fileExtension;


        public string FilePath { get { return filePath; } set { if (!String.IsNullOrEmpty(value)) { filePath = value; } } }
        public string FileExtension { get { return fileExtension; } set { if (!String.IsNullOrEmpty(value)) { fileExtension = value; } } }

        // Token & version nr
        private const string fileVersionToken = "Apu_Animal_Park";
        private const double fileVersionNr = 1.013;

        #region Save text file

        /// <summary>
        /// Saves animalmanager´s and foodmanager´s objects information as a text file by calling local methods.
        /// </summary>
        /// <param name="animalManager">AnimalManager with animal objects to save</param>
        /// <param name="foodManager">FoodManager with fooditem objects to save</param>
        /// <returns>True if saving was successful, else false</returns>
        public bool SaveAsTextFile(AnimalManager animalManager, FoodManager foodManager)
        {
            Stream stream;
            StreamWriter streamWriter;

            // If path and objects are valid
            bool ok = !String.IsNullOrEmpty(filePath) && animalManager != null && foodManager != null; 

            // Controlling path is valid and user selects OK
            if (ok)
            {
                using (stream = File.Open(filePath, FileMode.Create)) // Creates the file
                using (streamWriter = new StreamWriter(stream))

                {
                    // Writing control and amount of tasks
                    streamWriter.WriteLine(fileVersionToken); // Token control
                    streamWriter.WriteLine(fileVersionNr); // Version control
                    streamWriter.WriteLine(animalManager.Count); // Amount of animals
                    streamWriter.WriteLine(foodManager.Count); // Amount of food items

                    // Iterating through each animal
                    for (int i = 0; animalManager.Count > i; i++)
                    {
                        Animal animal = animalManager.GetAt(i); // Retreive each animal by index
                        SaveAnimal(streamWriter, animal); // Saves animal
                    }
                    
                    for (int i = 0; foodManager.Count>i;i++)
                    {
                        FoodItem food = foodManager.GetAt(i); // Retreive each fooditem by index
                        Guid[] ids = foodManager.GetFoodItemsID(food);
                        SaveFood(streamWriter, food, ids); // Saves food
                    }
                }
                // Save is successful
                return true;
            }
            // Save is NOT successful
            return false;
        }

        /// <summary>
        /// Saves information of the animal given in the parameter.
        /// </summary>
        /// <param name="streamWriter">streamWriter currently in use to save to a text file</param>
        /// <param name="animal">Animal object´s properties to save</param>
        private void SaveAnimal(StreamWriter streamWriter, Animal animal)
        {
            // Save information about each animal
            streamWriter.WriteLine(animal.GetType().Name);
            streamWriter.WriteLine(GetValue(animal.GetType(), animal));
            streamWriter.WriteLine(GetType(animal.GetType(), animal));
            streamWriter.WriteLine(GetValue(animal.GetType().BaseType, animal));
            streamWriter.WriteLine(GetType(animal.GetType().BaseType, animal));
            streamWriter.WriteLine(animal.Age);
            streamWriter.WriteLine(animal.Name);
            streamWriter.WriteLine(animal.Weight);
            streamWriter.WriteLine(animal.Gender);
            streamWriter.WriteLine(animal.ID);

        }

        /// <summary>
        /// Gets the value of a object´s first property. E.g, if i want the unique property of the class "Cat",
        /// this method first gets all properties of class and the parent class. Then returns the first property´s value as a string.
        /// </summary>
        /// <param name="t">Type of object</param>
        /// <param name="obj">Base class (Animal)</param>
        /// <returns>A string of the unique property´s value of the subclasses/child classes</returns>
        private string GetValue(Type t, Object obj)
        {
            List<PropertyInfo> props = new List<PropertyInfo>(t.GetProperties());
            string property = props[0].GetValue(obj).ToString();
            return property;
        }

        /// <summary>
        /// Gets the type of a object´s first property. E.g, if i want the unique property of the class "Cat",
        /// this method first gets all properties of class and the parent class. Then returns the first property´s type as a string.
        /// </summary>
        /// <param name="t">Type of object</param>
        /// <param name="obj">Base class (Animal)</param>
        /// <returns>A string of the unique property´s type of the subclasses/child classes</returns>
        private string GetType(Type t, Object obj)
        {
            List<PropertyInfo> props = new List<PropertyInfo>(t.GetProperties());
            string property = props[0].GetValue(obj).GetType().Name.ToString();
            return property;

        }

        /// <summary>
        /// Saves the food items and then the Guid associated with that food item.
        /// </summary>
        /// <param name="streamWriter">Current streamwriter in use to save as text file</param>
        /// <param name="food">Food item to save</param>
        /// <param name="ids">Guid´s to be saved associated with the food item</param>
        private void SaveFood(StreamWriter streamWriter, FoodItem food, Guid[] ids)
        {

            streamWriter.WriteLine(food.Name); // Name of food item
            streamWriter.WriteLine(food.Count.ToString()); // Nr of ingredients.
            for(int i = 0; i < food.Count;i++) 
            {
                streamWriter.WriteLine(food.GetAt(i));
            }

            streamWriter.WriteLine(ids.Length); // Nr of Id´s associated with food item
            for(int i = 0; i < ids.Length; i++)
            {
                streamWriter.WriteLine(ids[i].ToString());
            }

        }

        #endregion

        /// <summary>
        /// Calls animalManager method, that is inhereted by GenericListmanager to serialize all animals in animalmanager in to binary.
        /// </summary>
        /// <param name="animalManager">AnimalManager´s animals to binary serialize</param>
        /// <returns>True if successful, else false</returns>
        public bool SaveAsBinarySerialized(AnimalManager animalManager)
        {
            bool ok = !String.IsNullOrEmpty(filePath) && animalManager != null;

           
            if (ok)
            {
                animalManager.BinarySerialization(FilePath);
                return true;
            }
            return false;

        }

        /// <summary>
        /// Calls animalManager method, that is inhereted by GenericListmanager to serialize all animals in animalmanager in to JSON.
        /// </summary>
        /// <param name="animalManager">AnimalManager´s animals to serialize to JSON</param>
        /// <returns>True if successful, else false</returns>
        public bool SaveAsJsonSerialized(AnimalManager animalManager)
        {
            bool ok = !String.IsNullOrEmpty(filePath) && animalManager != null;

            if (ok)
            {
                animalManager.JsonSerialization(FilePath);
                return true;
            }
            return false;

        }


        /// <summary>
        /// Calls foodManager method, that is inhereted by GenericListmanager to serialize all fooditems in foodmanager in to XML.
        /// </summary>
        /// <param name="foodManager">FoodManager´s food items to serialize to XML</param>
        /// <returns>True if successful, else false</returns>

        public bool SaveAsXMLSerialized(FoodManager foodManager)
        {
            bool ok = !String.IsNullOrEmpty(filePath) && foodManager != null;

            if (ok)
            {
                foodManager.XMLSerialization(filePath);
                return true;
            }

            return false;

        }

  


        


    }
}
