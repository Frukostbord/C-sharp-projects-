using System;
using System.Collections.Generic;

namespace HouseholdChores
{
    /// <summary>
    /// This class purpose is to Add, Delete and Retreive objects of FamilyMember.
    /// All objects of the class FamilyMember are saved in a list as a instance variable.
    /// </summary>


    class FamilyMemberManager
    {
        // Instance variable.
        private List<FamilyMember> familyMembers = new List<FamilyMember>();


        #region Deleting and Editing chores in all family members
        /// <summary>
        /// This method:
        /// 1. Gets the chore to be deleted and the id of it.
        /// 2. Iterates through each familymember.
        /// 3. Iterates through all the familymember´s chores
        /// 4. Deletes the Chore in each familymember if it exists.
        /// </summary>
        /// <param name="id">Id of chore to be deleted</param>

        public void DeleteFamilyMembersChore(Guid id)
        {

            int familyCount = familyMembers.Count;

            for (int i = 0; familyCount > i; i++) // Iterate through every familymember
            {
                FamilyMember familyMember = familyMembers[i];
                List<Chore> chores = familyMember.Chores; // Get the current familymember´s chores

                for (int y = 0; chores.Count > y; y++) // Iterate through all the chores
                {
                    // Checks if the current Chore == Chore to be deleted
                    if (id == chores[y].Id)
                    {
                        familyMember.DeleteChore(y); // Delete Chore
                    }
                }
            }
        }


        /// <summary>
        /// This method:
        /// 1. Gets the chore to be edited.
        /// 2. Iterates through each familymember.
        /// 3. Iterates through all the familymember´s chores.
        /// 4. Edits the Chore in each familymember if it exists.
        /// </summary>
        /// <param name="chore">Chores new name and frequency</param>
        /// <param name="id">Id of chore to be edited</param>

        public void EditFamilyMemberChores(Chore chore, Guid id)
        {

            int familyCount = familyMembers.Count;

            for (int i = 0; familyCount > i; i++) // Iterating through family members
            {
                FamilyMember familyMember = familyMembers[i];
                List<Chore> chores = familyMember.Chores; // Get the current familymember´s chores

                for (int y = 0; chores.Count > y; y++) // Iterating through each Chore
                {
                    if (id == chores[y].Id) // Checking if Chore exists
                    {
                        chores[i].Name = chore.Name;
                        chores[i].FrequencyToDo = chore.FrequencyToDo;
                    }
                }

            }
        }
        #endregion

        #region Adding, Deleting and Retreiving family member

        /// <summary>
        /// Get object of FamilyMember from given index in the list familyMembers.
        /// </summary>
        /// <param name="index">Index in list of familyMembers to be retreived.</param>
        /// <returns>An object of FamilyMember</returns>
        public FamilyMember GetFamilyMember(int index)
        {
            return familyMembers[index];
        }

        /// <summary>
        /// This method deletes an object of FamilyMember 
        /// from given index in the list familyMembers.
        /// </summary>
        /// <param name="index">Index in list of familyMembers to be deleted.</param>
        public void DeleteFamilyMember(int index)
        {
            familyMembers.RemoveAt(index);
        }
        /// <summary>
        /// This method adds an object of FamilyMember to the list familyMembers.
        /// </summary>
        /// <param name="familyMember">Object to be added in the list familyMembers</param>
        public void AddFamilyMember(FamilyMember familyMember)
        {
            familyMembers.Add(familyMember);
        }
        #endregion

        /// <summary>
        /// This method returns a count of the amount of family members 
        /// currently reciding in the list familyMembers.
        /// </summary>
        /// <returns>An Integer of how many family members</returns>
        public int GetFamilyMembersCount()
        {
            return familyMembers.Count;
        }

        /// <summary>
        /// This method Controls to see if an object recides within the index given as an integer.
        /// </summary>
        /// <param name="index">An integer represnting index to be controlled.</param>
        /// <returns>A boolean value. True if an object exists at given index, else false.</returns>
        public bool ControlIndex(int index)
        {
            if (familyMembers[index] != null && familyMembers.Count > index)
                return true;
            return false;
        }

        // Setter & Getter
        public List<FamilyMember> GetFamilyMembers { get { return familyMembers; } }

    }
}
