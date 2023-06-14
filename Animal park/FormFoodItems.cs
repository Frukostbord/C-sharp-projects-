using System;
using System.Windows.Forms;


namespace Apu_Animal_Park_4
{
    /// <summary>
    /// This class lets the user create a food item object by:
    /// 1. Naming it.
    /// 2. Adding, changing or deleting ingredients of food item.
    /// </summary>
    public partial class FormFoodItems : Form
    {
        public FoodItem Fooditem { get; } = new FoodItem();

        public FormFoodItems()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            ControlButtons(); // Controlling which buttons should be enabled
        }

        /// <summary>
        /// Controlling if user has written any ingredient
        /// </summary>
        /// <returns>True if something is written in the ingredient text box, else false</returns>
        private bool CheckInputIngredient()
        {
            if (!String.IsNullOrEmpty(txtIngredient.Text)) { return true; }

            return false;
        }

        /// <summary>
        /// Controls if:
        /// 1. The user has named the food item
        /// 2. If there´s any ingredients added
        /// </summary>
        /// <returns></returns>
        private bool ControlFoodItem()
        {
            bool name = !String.IsNullOrEmpty(txtName.Text);
            bool ingredients = Fooditem.Count > 0;

            return name && ingredients;
        }

        /// <summary>
        /// Adds ingredient to the food item object
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckInputIngredient())
            {
                Fooditem.Add(txtIngredient.Text);
                UpdateListbox();
                RemoveIngredientText();
            }

            else { MessageBox.Show("You have to write an ingredient!", "Error!"); }

        }

        /// <summary>
        /// Let´s the user change the selected ingredient´s name
        /// </summary>

        private void Change_Click(object sender, EventArgs e)
        {
            int index = lstIngredients.SelectedIndex;
            if (index != -1 && CheckInputIngredient()) // Control input and selection
            {
                Fooditem.ChangeAt(txtIngredient.Text, index); // Change ingredient
            }

            // GUI update
            lstIngredients.SelectedIndex = -1;
            RemoveIngredientText();
            UpdateListbox();
        }

        /// <summary>
        /// Deletes ingredient in food object item at given index
        /// </summary>

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lstIngredients.SelectedIndex;
            if (index != -1)
            {
                Fooditem.DeleteAt(index); // Deletes at given index
            }

            // GUI update
            lstIngredients.SelectedIndex = -1;
            RemoveIngredientText();
            UpdateListbox();
        }

        /// <summary>
        /// If input is ok (food item name and atleast one ingredient), close the form.
        /// </summary>

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ControlFoodItem())
            {
                Fooditem.Name = txtName.Text;
                DialogResult = DialogResult.OK; // Closes form
            }
            else { MessageBox.Show("Please look over your input"); }
        }

        /// <summary>
        /// Double checking with user before closing the form and discarding all changes.
        /// </summary>

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dlgresult = MessageBox.Show("Are you sure you want to discard your changes?",
                "Warning!", MessageBoxButtons.YesNo);
            if (dlgresult == DialogResult.Yes) { DialogResult = DialogResult.Cancel; }

        }

        /// <summary>
        /// Adds food item objects to the listbox
        /// </summary>
        private void UpdateListbox()
        {
            lstIngredients.Items.Clear();

            for (int i = 0; i < Fooditem.Count; i++)
            {
                lstIngredients.Items.Add(Fooditem.GetAt(i));
            }

        }

        /// <summary>
        /// Controls buttons (Change & Delete) and displays ingredient in text box
        /// </summary>

        private void lstIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlButtons();
            DisplayIngredients();
        }

        /// <summary>
        /// Displays ingredient in textbox
        /// </summary>
        private void DisplayIngredients()
        {
            int index = lstIngredients.SelectedIndex;
            string ingredient;

            if (index != -1)
            {
                ingredient = Fooditem.GetAt(index);
                txtIngredient.Text = ingredient;
            }

        }

        /// <summary>
        /// Removes ingredient text
        /// </summary>
        private void RemoveIngredientText()
        {
            txtIngredient.Text = string.Empty;
        }

        /// <summary>
        /// Controls if Delete and Change button should be enabled
        /// </summary>
        private void ControlButtons()
        {
            if (lstIngredients.SelectedIndex == -1)
            {
                btnDelete.Enabled = false;
                btnChange.Enabled = false;
            }

            else
            {
                btnDelete.Enabled = true;
                btnChange.Enabled = true;
            }

        }
    }
}
