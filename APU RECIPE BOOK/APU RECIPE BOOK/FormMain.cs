using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace APU_RECIPE_BOOK
{
    public partial class FormMain : Form
    {
        /// This class is the main form of the program. It´s functions are:
        /// 1. To set data of the current recipe the user is working with in the class Recipe.
        /// 2. Open up a new form (FormIngredients), so the user can add ingredients.
        /// 3. Once the recipe is completed, it´s sent and stored in an array in RecipeManager.
        /// 4. It displays the recipe in the listbox to the right.
        /// 5. If the user wants to edit a recipe, the user clicks an item in the  <summary>
        /// listbox and the user can edit it in this form.


        private const int maxNrOfIngredients = 50; // Maximum number of ingredients
        private const int maxNrOfRecipes = 200; // Maximum number of recipes
        private RecipeManager recipeManager = new RecipeManager(maxNrOfRecipes);
        private Recipe currRecipe = new Recipe(maxNrOfIngredients);

        public FormMain()
        {
            InitializeComponent();
            InitializeGUI();
        }

        /// <summary>
        /// Sets up items in combobox during the start of the program
        /// </summary>
        private void InitializeGUI()
        {
            foreach (string foodType in Enum.GetNames(typeof(FoodCategoryEnum)))
                cmbFoodCategory.Items.Add(foodType);
            btnEditFinish.Enabled = false;
        }

        /// <summary>
        /// Clears all fields of text in the groupbox for adding recipes.
        /// </summary>
        private void RefreshGUI()
        {
            cmbFoodCategory.SelectedIndex = -1;
            txtInstructions.Clear();
            txtNameRecipe.Clear();
            grpAddRecipe.Text = "Add new recipe";
            btnEditFinish.Enabled = false;
            btnEditBegin.Enabled = true;
        }        

        /// <summary>
        /// Checks input of the current recipe.
        /// If input is correct, it stores the current recipe in the class RecipeManager.
        /// Then creates a new Recipe (object) to work with.
        /// </summary>

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            // Checking name and instructions
            SetRecipeName();
            SetRecipeInstructions();

            if (CheckInput())
            {
                recipeManager.AddRecipe(currRecipe);
                AddRecipeListBox();
                RefreshGUI(); // Resets the form for visual feedback for the user

                currRecipe = new Recipe(maxNrOfIngredients); // Creating a new object
            }
        }
        #region Manipulating recipes in the listbox

        /// <summary>
        /// This method clears the selection, combobox choice, text and creates a new recipe.
        /// The editing done by the user, if any, is discarded.
        /// </summary>

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            if (lstRecipes.SelectedIndex != -1)
            {
                lstRecipes.ClearSelected();

                // Restores GUI for the user
                RefreshGUI();
                btnDelete.Enabled = true;
                btnAddRecipe.Enabled = true;
                lstRecipes.Enabled = true;

                currRecipe = new Recipe(maxNrOfIngredients); // Creating a new object
            }
            else
                MessageBox.Show("You have to have something selected first!");
        }

        /// <summary>
        /// This method:
        /// 1. Disables non-relevant buttons for editing to avoid error conflict
        /// 2. Retreives and displays the selected recipe in the listbox, 
        /// for the user to edit in the groupbox to the left.
        /// </summary>
        private void btnEditBegin_Click(object sender, EventArgs e)
        {
            if (lstRecipes.SelectedIndex != -1)
            {
                grpAddRecipe.Text = "Edit recipe"; // Change name of group for visual feedback

                // Disable non-relevant buttons to avoid errors
                btnDelete.Enabled = false;
                btnAddRecipe.Enabled = false;
                lstRecipes.Enabled = false;
                btnEditBegin.Enabled = false;
                btnEditFinish.Enabled = true; // So we can finish editing

                // Loading selected recipe
                currRecipe = recipeManager.SelectedRecipe(lstRecipes.SelectedIndex);
                txtNameRecipe.Text = currRecipe.RecipeName;
                txtInstructions.Text = currRecipe.RecipeInstructions;
                cmbFoodCategory.SelectedIndex = (int)currRecipe.FoodCategory;
            }
            else
                MessageBox.Show("You have to select something from the listbox before trying to edit it!");
        }

        /// <summary>
        /// This method:
        /// 1. Checks that all input is correct
        /// 2. Sets the newly edited recipe to RecipeManager
        /// 3. Restores GUI in FormMain
        /// </summary>
        private void btnEditFinish_Click(object sender, EventArgs e)
        {
            int index = lstRecipes.SelectedIndex; // Selected index in the listbox

            SetRecipeName();
            SetRecipeInstructions();

            if (CheckInput())
            {
                // Overwrites current recipe with the newly edited
                recipeManager.AddEditedRecipe(index,currRecipe);

                AddEditedRecipeListBox(index); // Updates listbox

                // Restores GUI for the user
                RefreshGUI();
                btnDelete.Enabled = true;
                btnAddRecipe.Enabled = true;
                lstRecipes.Enabled = true;

                currRecipe = new Recipe(maxNrOfIngredients); // Create new object
            }

            else
                MessageBox.Show("You can't leave fields empty!");
        }



        /// <summary>
        /// This method formats and adds the current recipe in the listbox.
        /// </summary>
        private void AddRecipeListBox()
        {
            string name = currRecipe.RecipeName;
            string category = currRecipe.FoodCategory.ToString();
            string nrOfIngredients = currRecipe.GetNumberOfIngredients().ToString();

            // Formatting and adding the recipe
            lstRecipes.Items.Add(String.Format("{0,-20}{1,-30}{2,-50}", name, category, nrOfIngredients));

        }

        /// <summary>
        /// This method:
        /// 1. Removes the current selected text in the listbox in FormMain.
        /// 2. Adds the edited recipe to the listbox FormMain.
        /// </summary>
        private void AddEditedRecipeListBox(int index)
        {
            string name = currRecipe.RecipeName;
            string category = currRecipe.FoodCategory.ToString();
            string nrOfIngredients = currRecipe.GetNumberOfIngredients().ToString();

            lstRecipes.Items.RemoveAt(index); // Removes current item
            // Formatting and adding the recipe
            lstRecipes.Items.Insert(index,
                String.Format("{0,-20}{1,-30}{2,-50}", name, category, nrOfIngredients));
            lstRecipes.Update();
        }

        /// <summary>
        /// Checks if an item is selected, then removes it. Then calls method in 
        /// RecipeManager to remove and reorganize the array of recipes.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
 
            if (lstRecipes.SelectedIndex != -1)
            {
                recipeManager.DeleteRecipe(lstRecipes.SelectedIndex); // Removes the recipe (object) in RecipeManager
                lstRecipes.Items.Remove(lstRecipes.SelectedItem); // Removes item in the listbox
                               
                lstRecipes.ClearSelected();
            }
            else
                MessageBox.Show("You have to select a item before you try to delete it!");
        }

        /// <summary>
        /// This method shows a message box with ingredients and instructions to the user, 
        /// when an item in the listbox is double clicked.
        /// </summary>

        private void lstRecipes_DoubleClick(object sender, EventArgs e)
        {

            currRecipe = recipeManager.SelectedRecipe(lstRecipes.SelectedIndex); // Get the recipe from RecipeManager
            string ingredients = String.Join(", ",currRecipe.RecipeIngredients);
            string instructions = currRecipe.RecipeInstructions;

            // Display it with simple string formatting
            MessageBox.Show($"INGREDIENTS\n{ingredients}\n\n{instructions}", "Cooking Instructions");
 

        }
        #endregion

        #region Checking valid input, if trying to add recipe
        /// <summary>
        /// Calls different methods to check for input whilst trying to add a recipe.
        /// Shows a error message to the user if they´re trying to continue without filling out
        /// all required information.
        /// </summary>
        public bool CheckInput()
        {
            bool ok = CheckRecipeName() && CheckCategorySelected() &&
                CheckInstructions() && CheckIngredients();

            if (!CheckRecipeName())
                MessageBox.Show("Please fill out a name for your recipe!");
            if (!CheckCategorySelected())
                MessageBox.Show("Please select a food category!");
            if (!CheckInstructions())
                MessageBox.Show("Please write instructions on how to prepare the recipe!");
            if (!CheckIngredients())
                MessageBox.Show("Please add an ingredient to the recipe!");

            return ok;

        }

        /// <summary>
        /// Checks to see if the user has written a name for the recipe.
        /// </summary>
        /// <returns>A boolean value if a valid string is present</returns>

        private bool CheckRecipeName()
        {
            if (!String.IsNullOrEmpty(txtNameRecipe.Text))
                return true;
            return false;

        }
        /// <summary>
        /// Checks to see if the user has choosen a category for the recipe.
        /// </summary>
        /// <returns>A boolean value if a valid option is present</returns>
        private bool CheckCategorySelected()
        {
            if (!String.IsNullOrEmpty(cmbFoodCategory.Text))
                return true;
            return false;
        }

        /// <summary>
        /// Checks to see if the user has added a text for instructions.
        /// </summary>
        /// <returns>A boolean value if a valid string is present</returns>
        private bool CheckInstructions()
        {
            if (!String.IsNullOrEmpty(txtInstructions.Text))
                return true;
            return false;
        }

        /// <summary>
        /// Checks to see if the user has added ingredients, by calling a method from
        /// class Recipe.
        /// </summary>
        /// <returns>A boolean value if any recipes have been added</returns>
        private bool CheckIngredients()
        {
            if (currRecipe.GetNumberOfIngredients() == 0)
                return false;
            return true;
        }
        #endregion

        #region Setting information in class "Recipe" - the current recipe

        /// <summary>
        /// 1. Opens up FormIngredients and refers the current recipe we´re working with
        /// 2. Let´s the user add, delete & edit ingredients
        /// 3. Either the user cancels (everything is discarded) or the user accepts
        /// and the ingredients are sent to the current recipe
        /// </summary>

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            FormIngredients formIngredients = new FormIngredients(currRecipe);
            formIngredients.ShowDialog();
        }

        /// <summary>
        /// Converts string in combobox to enum
        /// Setting food category to the selected in current recipes
        /// </summary>

        private void cmbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string foodCategoryString = cmbFoodCategory.GetItemText(cmbFoodCategory.SelectedItem);

            if (cmbFoodCategory.SelectedIndex != -1)
            {
                FoodCategoryEnum foodCategory = // Converting string to enum
                    (FoodCategoryEnum)Enum.Parse(typeof(FoodCategoryEnum), foodCategoryString);
                currRecipe.FoodCategory = foodCategory;
            }
        }

        /// <summary>
        /// Setting name of recipe to what the user writes in the current object.
        /// </summary>
        private void SetRecipeName()
        {
            currRecipe.RecipeName = txtNameRecipe.Text;
        }

        /// <summary>
        /// Setting instructions how to cook to what the user writes in the current object.
        /// </summary>
        private void SetRecipeInstructions()
        {
            currRecipe.RecipeInstructions = txtInstructions.Text;
        }

        #endregion

  
    }
}
