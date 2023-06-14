using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace APU_RECIPE_BOOK
{

    /// <summary>
    /// A form for adding ingredients to the current recipe in FormMain.
    /// User can add and edit ingredients, that are shown in the listbox.
    /// If the user clicks "OK", the ingredients are added to the current recipe, else
    /// they are discarded.
    /// </summary>
    public partial class FormIngredients : Form
    {
        private Recipe ingredientsRecipe;

        #region Constructor

        /// <summary>
        /// Constructor for setting up the form for ingredients.
        /// 1. Get the current object we´re working with.
        /// 2. Check if there are any ingredients in the recipe, if so add them to the listbox.
        /// </summary>
        /// <param name="recipe">Current recipe the user is working with</param>
        public FormIngredients(Recipe recipe)
        {
            InitializeComponent();
            ingredientsRecipe = recipe;
            InitializeGUI();

        }
        #endregion

        /// <summary>
        /// 1. Add previous ingredients (if any) by calling another method.
        /// 2. Display on label to the top right amount of ingredients.
        /// </summary>
        private void InitializeGUI()
        {
            AddPreviousIngredients();
            lblNumber.Text = lstIngredients.Items.Count.ToString();
        }

        /// <summary>
        /// Adds previous ingredients in the listbox from the current recipe,
        /// if there are any.
        /// </summary>
        private void AddPreviousIngredients()
        {
            if (ingredientsRecipe.GetNumberOfIngredients() > 0)
                foreach (string ingredient in ingredientsRecipe.RecipeIngredients)
                    lstIngredients.Items.Add(ingredient);
        }

        #region Buttons methods
        /// <summary>
        /// Adds item to the listbox that´s been written in the textbox, if any text has been written.
        /// Updates the label top the top right of the amount of ingredients.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIngredient.Text))
            {
                lstIngredients.Items.Add(txtIngredient.Text);
                lblNumber.Text = lstIngredients.Items.Count.ToString();
                txtIngredient.Clear(); // Clears text in textbox after adding to listbox
            }
            else
                MessageBox.Show("You write something to add!");
        }

        /// <summary>
        /// Deletes selected item in the listbox.
        /// Updates amount of items the label shows
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstIngredients.SelectedIndex != -1)
            {
                lstIngredients.Items.Remove(lstIngredients.SelectedItem); // Deletes selected item
                lblNumber.Text = lstIngredients.Items.Count.ToString();
            }
            else
                MessageBox.Show("You have to select an item before trying to delete it!");
        }

        /// <summary>
        /// 1. Checks to see that something is selected
        /// 2. Removes current value at index and replaces it with text in the textbox
        /// 3. Unselects item in listbox
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstIngredients.SelectedIndex != -1)
            {
                int index = lstIngredients.SelectedIndex; // Current index selected
                lstIngredients.Items.RemoveAt(index); // Delete it
                lstIngredients.Items.Insert(index, txtIngredient.Text); // Insert new text from textbox at the index
            }
            else
                MessageBox.Show("You have to select an item before trying to edit it!");
            
            lstIngredients.ClearSelected();
        }
        /// <summary>
        /// Goes back to MainForm without adding the ingredients nor accepting the changes
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide(); // Hides current form
        }

        /// <summary>
        /// If ingredients have been added to the listbox, it
        /// adds ingredients to the current recipe in a string array
        /// If none are added, it shows a error message.
        /// </summary>

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Converts all the items in the listbox to an array
            string[] ingredientsArray = lstIngredients.Items.OfType<string>().ToArray();

            if (lstIngredients.Items.Count > 0)
            {
                ingredientsRecipe.RecipeIngredients = ingredientsArray;
                Hide(); // Hides current form
            }
            else
                MessageBox.Show("You have to add some ingredients!");
            
        }
        #endregion

        /// <summary>
        /// Shows in the textbox what the user has selected in the listbox, 
        /// if something has been selected.
        /// </summary>
        private void lstIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstIngredients.SelectedItem != null)
                txtIngredient.Text = lstIngredients.SelectedItem.ToString();
        }
    }
}
