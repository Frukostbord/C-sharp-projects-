using System;
using System.Collections.Generic;

namespace Apu_Animal_Park_4
{
    public class FoodManager : GenericListManager<FoodItem>
    {
        /// <summary>
        /// This class has:
        /// 1. Food items that can be changed, edited and deleted
        /// 2. A dictionary of fooditems, with Guid´s from animal objects coupled as key (food item) and value (animal object´s ID) pair.
        /// </summary>

        private Dictionary<FoodItem, List<Guid>> animalsFoodItems = new Dictionary<FoodItem, List<Guid>>(); // Dictionary of food item and animal object ID´s

        /// <summary>
        /// Control food item and animal object isn´t null
        /// </summary>
        /// <param name="foodItem">Food item to control</param>
        /// <param name="animal">Animal object to control</param>
        /// <returns>True if both aren´t null, else false</returns>
        private bool ControlAnimalAndFoodItem(FoodItem foodItem, Animal animal)
        {
            bool foodOK = foodItem != null;
            bool animalOK = animal != null;

            return foodOK && animalOK;
        }

        /// <summary>
        /// Iterates through each food item in dictionary animalsFoodItems to see if an Guid is given to each food item
        /// </summary>
        /// <returns>True if each food item has atleast one (1) Guid, else false</returns>
        public bool ControlFoodItemHasID()
        {
            bool ok = true;

            foreach(FoodItem foodItem in animalsFoodItems.Keys)
            {
                if (animalsFoodItems[foodItem].Count == 0) { ok = false; break; }
            }
            return ok;

        }

        /// <summary>
        /// Adds Guid to a food item
        /// </summary>
        /// <param name="food">Food item to get a new Guid</param>
        /// <param name="id">Guid to be added</param>
        public void AddIDtoFoodItem(FoodItem food, Guid id)
        {
            bool ok = (food != null && id != null);

            if(ok) // Check parameters are OK
            {
                animalsFoodItems[food].Add(id);
            }

        }


        /// <summary>
        /// Adds food item to dictionary with no value pair, just a empty list.
        /// </summary>
        /// <param name="foodItem">Food item to add</param>
        public void AddFoodItemDictionary(FoodItem foodItem)
        {
            animalsFoodItems.Add(foodItem, new List<Guid>());
        }

        /// <summary>
        /// Control if an animal´s ID is already linked to the food item
        /// </summary>
        /// <param name="foodItem">Food item to control</param>
        /// <param name="animal">Animal object´s id check</param>
        /// <returns>True if food item is already linked to animal´s ID, else false</returns>
        public bool ControlAnimalHasFoodItem(FoodItem foodItem, Animal animal)
        {
            bool ok = animalsFoodItems[foodItem].Contains(animal.ID);
            return ok;

        }

        /// <summary>
        /// This method:
        /// 1. Calls other methods to see that the objects != null and if the animal already has the food item assigned
        /// 2. Adds the animals id (value) to the food item (key)
        /// </summary>
        /// <param name="animal">Animal object to be added and controlled</param>
        /// <param name="foodItem">Food item object to be controlled</param>
        public void AddFoodItemAnimal(Animal animal, FoodItem foodItem)
        {
            bool ok =
                ControlAnimalAndFoodItem(foodItem, animal) && !ControlAnimalHasFoodItem(foodItem, animal);

            if (ok)
            {
                animalsFoodItems[foodItem].Add(animal.ID);
            }
        }

        /// <summary>
        /// Removes animal object from food item.
        /// </summary>
        /// <param name="animal">Animal object to remove</param>
        /// <param name="foodItem">Food item the animal object should be removed from</param>
        public void DeleteFoodItemAnimal(Animal animal, FoodItem foodItem)
        {
            bool ok = ControlAnimalAndFoodItem(foodItem, animal);

            if (ok)
            {
                animalsFoodItems[foodItem].Remove(animal.ID);
            }

        }

        public Guid[] GetFoodItemsID(FoodItem foodItem)
        {
            Guid[] id = animalsFoodItems[foodItem].ToArray();
            return id;
        }


        /// <summary>
        /// 1. Iterates through each food item 
        /// 2. Adds the name as [0] and ingredients as [1..] and saves it as a string[] array
        /// 3. Then adds string[] array to a list
        /// </summary>
        /// <returns>Returns a list<> of string[] arrays of food item objects</returns>
        public override List<string[]> ToListStringArray()
        {
            List<string[]> foodInfo = new List<string[]>();
            FoodItem foodItem;

            for (int i = 0; i < Count; i++)
            {
                foodItem = GetAt(i);
                string[] arr =
                {
                    foodItem.Name,
                    string.Join(", ",foodItem.ToStringArray()),
                };

                foodInfo.Add(arr);
            }
            return foodInfo;
        }
    }

}
