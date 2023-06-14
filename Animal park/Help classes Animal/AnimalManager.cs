using System;
using System.Collections.Generic;

namespace Apu_Animal_Park_4
{
    /// <summary>
    /// This class has methods to manipulate a list of animal objects:
    /// 1. It can add, change and delete animal objects in the list of animal objects
    /// 2. It can retreive information of each animal object.
    /// 3. It can sort the objects by different variables
    /// </summary>

    public class AnimalManager : GenericListManager<Animal>
    {

        /// <summary>
        /// Controls if animal object is null. If not, creates new Guid and adds animal to the list of animal object list.
        /// </summary>
        /// <param name="animal">Animal object to control and add</param>
        /// <returns>True if animal object was added, else false</returns>
        public bool AddAnimal(Animal animal)
        {
            Guid id;

            if (animal != null)
            {
                id = Guid.NewGuid();
                animal.ID = id;
                Add(animal);

                return true;
            }

            return false;
        }

        public void AddAnimalWithID(Animal animal)
        {  if (animal != null) { Add(animal); } }

        /// <summary>
        /// Iterate through each animal object and retreives their informaion. Then adds it to the list of string[] arrays.
        /// </summary>
        /// <returns>Returns an list of string[] arrays of animal object´s information</returns>
        public override List<string[]> ToListStringArray()
        {
            List<string[]> animalInfo = new List<string[]>();
            Animal animal;

            for (int i = 0; i < Count; i++)
            {
                animal = GetAt(i);
                animalInfo.Add(animal.AnimalInfo());
            }

            return animalInfo;
        }

    }
}
