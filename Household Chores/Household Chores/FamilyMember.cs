using System;
using System.Collections.Generic;

namespace HouseholdChores
{
    /// <summary>
    /// This class purpose is:
    /// 1. To store the name of a family member
    /// 2. To store all the chores to be done by the family member and when it´s to be done.
    /// 
    /// Each Chore is saved as an object in a list.
    /// In each chore in the list "chores", an list of weekdays exist representing each day 
    /// the chore is to be done.
    /// </summary>
    class FamilyMember
    {

        // Instance variables 
        private string name;
        private List<Chore> chores = new List<Chore>(); // Each chore to be done by the family member

        // Constructors
        #region Constructor
        public FamilyMember()
        {

        }
        public FamilyMember(string name)
        {
            this.name = name;
        }
        #endregion

        #region Manipulating Chores in chores list
        /// <summary>
        /// This method adds a chore to the list of chores.
        /// </summary>
        /// <param name="chore">Chore to be added to the list of chores</param>
        public void AddChore(Chore chore)
        {
            chores.Add(chore);
        }

        /// <summary>
        /// Deletes a chore in the list of chores at the given index.
        /// </summary>
        /// <param name="index">Index of Chore to be deleted</param>
        public void DeleteChore(int index)
        {
            chores.RemoveAt(index);
        }

        /// <summary>
        /// Retreives a chore from the list of chores by ID given in the parameter.
        /// </summary>
        /// <param name="id">ID of chore to be retreived.</param>
        /// <returns>An object from the class Chore</returns>
        public Chore GetChoreById(Guid id)
        {
            foreach (Chore chore in Chores)
                if (id == chore.Id) return chore;
            return null;
        }

        /// <summary>
        /// This method uses the Chore in the parameter.
        /// Then iterates through all the chores in the familymember´s list of chores and deletes
        /// the chore if the IDs are identical.
        /// </summary>
        /// <param name="choreToBeDeleted">Chore to be deleted by ID</param>
        public void DeleteChore(Chore choreToBeDeleted)
        {
            for (int i = 0; i < chores.Count; i++)
            {
                if (chores[i].Id == choreToBeDeleted.Id)
                    chores.RemoveAt(i);
            }
        }
        #endregion

        /// <summary>
        /// This method´s purpose is to deep copy a family member.
        /// 1. Copy name of the family member and create a new list of chores to be added.
        /// 2. Iterate through each chore in the family member to copy from.
        /// 3. Copy to variables: 
        ///     Name, FrequencyToDo, Id and weekdays.
        /// 4. Create a new object of Chore with its´ constructor with the copied values.
        /// 5. Add the new object to the list of chores.
        /// 6. Return the deep copy.
        /// </summary>
        /// <param name="copyFamilyMember">Object of class FamilyMember to copy to.</param>
        /// <param name="originalFamilyMember">Object of class FamilyMember to copy from. </param>
        /// <returns>A deep copy of an object from the class FamilyMember</returns>
        public FamilyMember DeepCopyFamilyMember(FamilyMember copyFamilyMember,
            FamilyMember originalFamilyMember)
        {
            copyFamilyMember.Name = originalFamilyMember.Name; // Copying name
            copyFamilyMember.Chores = new List<Chore>();

            List<Chore> choresOriginal = originalFamilyMember.Chores; // Copying chores

            for (int i = 0; choresOriginal.Count > i; i++)
            {
                string name = choresOriginal[i].Name;
                int frequency = choresOriginal[i].FrequencyToDo;
                Guid id = choresOriginal[i].Id;
                List<Weekdays> weekdays = choresOriginal[i].Weekdays;

                Chore chore = new Chore(name, frequency, id, weekdays);
                copyFamilyMember.AddChore(chore);
            }

            return copyFamilyMember;
        }




        #region Setter & Getter
        // Setter & Getter
        public List<Chore> Chores
        { get { return chores; } set { chores = value; } }
        public string Name
        { get { return name; } set { name = value; } }
        #endregion



    }
}
