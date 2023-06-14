using System.Collections.Generic;

namespace HouseholdChores
{
    /// <summary>
    /// This class purpose is to add, delete and retreive objects of the class Chore.
    /// All objects (Chore) are stored in a list and manipulated by methods.
    /// </summary>

    class ChoresManager
    {
        // Instance variable
        private List<Chore> chores = new List<Chore>(); // A list of all the chores saved as objects

        #region Retreiving, Deleting and Adding Chore to list
        /// <summary>
        /// This method returns an integer of the amount of objects (Chore) stored in the list chores.
        /// </summary>
        /// <returns>Integer of the amount of chores</returns>
        public int GetChoresCount()
        {
            return chores.Count;
        }

        /// <summary>
        /// This method adds an object of chore given as a parameter in the chores list.
        /// </summary>
        /// <param name="chore">An object of the class Chore</param>
        public void AddChore(Chore chore)
        {
            chores.Add(chore);
        }

        /// <summary>
        /// This method deletes an object at the given index in the list chores.
        /// </summary>
        /// <param name="index">Index of object to delete</param>
        public void DeleteChore(int index)
        {
            chores.Remove(chores[index]);
        }

        /// <summary>
        /// This method retreives an object from the index given in the list chores.
        /// </summary>
        /// <param name="index">Index of object to retreive in the list chores</param>
        /// <returns>An object of the class Chore</returns>
        public Chore GetChore(int index)
        {
            return chores[index];
        }
        #endregion

        /// <summary>
        /// This method:
        /// 1. Iterates through all the chores in chores list.
        /// 2. Adds each name of every chore to an string array.
        /// 3. Returns an array of names of all the chores.
        /// </summary>
        /// <returns></returns>
        public string[] GetChoreNames()
        {
            int length = chores.Count;

            string[] choresNames = new string[length];

            for (int i = 0; i < length; i++)
            {
                Chore chore = chores[i];
                choresNames[i] = chore.Name;
            }

            return choresNames;
        }

        // Setter & Getter
        public List<Chore> GetChores { get { return chores; } }

    }
}
