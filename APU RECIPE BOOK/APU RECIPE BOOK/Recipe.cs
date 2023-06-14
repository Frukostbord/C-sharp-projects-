using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_RECIPE_BOOK
{
    /// <summary>
    /// This class contains:
    /// 1. Instance variables for different aspects of a recipe 
    /// 2. Setters and getters for each instance variable
    /// 3. Method for counting amount of ingredients in the recipe
    /// </summary>
    public class Recipe
    {
        private FoodCategoryEnum foodCategory;
        private string recipeName, recipeInstructions;
        private string[] recipeIngredients = new string[50];

        #region Constructor
        /// <summary>
        /// Constructor setting up the maximum amount of ingredients (n == 50).
        /// </summary>
        /// <param name="maxNrOfIngredients">Hardcoded maximum amount of ingredients</param>
        public Recipe(int maxNrOfIngredients)
        {
            recipeIngredients = new string[maxNrOfIngredients];
        }
        #endregion

        #region Setters & Getters
        /// <summary>
        /// Setters and getters for instance variables
        /// Check values for string and array, not for enum
        /// </summary>
        
        // Setter & getter for foodCategory (no check whilst setting as it´s an enum)
        public FoodCategoryEnum FoodCategory 
        {   
            get { return foodCategory; }       
            set { foodCategory = value; } 
        }
        // Setter & getter for recipeName
        public string RecipeName 
            { 
            get { return recipeName; } 

            set 
            {
                if(!String.IsNullOrEmpty(value))
                    recipeName = value; 
            } 
        }
        // Setter & getter for recipeInstructions
        public string RecipeInstructions
        { 
            get { return recipeInstructions; } 

            set 
            {
                if (!String.IsNullOrEmpty(value))
                    recipeInstructions = value; 
            } 
        }
        // Setter & getter for recipeIngredients (array)
        public string[] RecipeIngredients
        { 
            get { return recipeIngredients; }
            set 
            {
                if (value.Length > 0)
                    recipeIngredients = value; 
            }

        }
        #endregion

        #region Methods

        /// <summary>
        /// Goes through all the items in the array of ingredients and counts each item 
        /// not being "null".
        /// </summary>
        /// <returns>Number of ingredients in "string[] recipeIngredients" as a Integer</returns>
        public int GetNumberOfIngredients()
        {
            int count = 0;

            for (int i = 0; i < recipeIngredients.Length; i++)
                if (recipeIngredients[i] != null)
                    count++;

            return count;
        }
        #endregion

    }
}
