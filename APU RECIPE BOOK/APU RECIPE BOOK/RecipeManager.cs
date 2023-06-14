using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_RECIPE_BOOK
{
    /// <summary>
    /// This class is responsible:
    /// 1. Storing all the recipes added by the user as objects in an array.
    /// 2. Having methods for retreiving, reorganizing and deleting objects in the array.
    /// </summary>
    internal class RecipeManager
    {
        private Recipe[] recipeList;

        #region Constructor

        /// <summary>
        /// Constructor setting up instance variable with 
        /// hardcoded maximum number of recipes
        /// </summary>
        /// <param name="maxNumOfElements">Number of maximum recipes (n == 200)</param>
        public RecipeManager(int maxNumOfElements)
        {
            recipeList = new Recipe[maxNumOfElements];
        }
        #endregion

        public void AddRecipe(Recipe recipe)
        {
            recipeList[FindVacantSpot()] = recipe;
        }

        /// <summary>
        /// Deletes recipe in recipeList at given index in this class.
        /// </summary>
        /// <param name="index">Index of recipe user is trying to delete.</param>
        public void DeleteRecipe(int index)
        {
            recipeList[index] = null;

            ReorganizeArray();
        }

        /// <summary>
        /// Reorganizes the array of recipes by moving each recipe one step
        /// higher in the array.
        /// </summary>
        private void ReorganizeArray()
        {
            for (int i = 0; i < recipeList.Length-1; i++)
                // If the current index == null and index+1 != null, move it to current index
                if (recipeList[i] == null && recipeList[i + 1] != null)
                {
                    recipeList[i] = recipeList[i + 1]; // Current index (null) get the recipe
                    recipeList[i + 1] = null; // index+1 = null
                }
        }

        /// <summary>
        /// Goes through the array of recipes (objects) until it finds an item that
        /// is null. Then returns the index as a integer.
        /// </summary>
        /// <returns>An integer representing an index in recipeList that is vacant</returns>
        private int FindVacantSpot()
        {
            for (int i = 0; i < recipeList.Length; i++)
                if (recipeList[i] == null)
                    return i;
            
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">Which index in the recipeList 
        /// array the user wants to retreive</param>
        /// <returns>An object reprsenting a recipe</returns>
        public Recipe SelectedRecipe(int index)
        {
            return recipeList[index];
        }


        public void AddEditedRecipe(int index, Recipe recipe)
        {
            recipeList[index] = recipe;
        }
    }
}
