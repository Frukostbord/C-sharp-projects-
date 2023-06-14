using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HouseholdChores
{
    /// <summary>
    /// This form is responsible for:
    ///     Adding, deleting and editing chores to the current family member provided in
    ///     the constructor.
    ///     
    /// When initiated, an temporary object of FamilyMember is deep copied from the object 
    /// in the constructor. 
    /// 
    /// The user can, by selecting a chore in the combobox:
    ///     1. Add a chore if doesn´t exist.
    ///     2. Edit or delete a chore if it exists for the family member.
    /// 
    /// Buttons regulate what the user can and can´t do, depending on:
    ///     1. Chore selected in the combobox.
    ///     2. If the chore exist for the family member.
    /// 
    /// </summary>
    partial class FormChores : Form
    {
        // Instance variables
        private ChoresManager choresManager;
        private FamilyMember familyMember;

        // Deep copied object of familyMember
        private FamilyMember tempFamilyMember = new FamilyMember();

        /// <summary>
        /// Constructor for FormChores. 
        /// </summary>
        /// <param name="title">Title of the form.</param>
        /// <param name="choresManager">All of the chores to be choosen from.</param>
        /// <param name="familyMember">Current object of family member to be deep copied.</param>
        public FormChores(string title, ChoresManager choresManager, FamilyMember familyMember)
        {
            InitializeComponent();

            Text = title;
            this.choresManager = choresManager;
            this.familyMember = familyMember;

            InitializeGUI(); // Setting up GUI

            // Deep copy of familyMember
            tempFamilyMember = familyMember.DeepCopyFamilyMember(tempFamilyMember, familyMember);
        }

        /// <summary>
        /// This method sets up the GUI for the user by:
        ///     1. Setting up the combobox with chores to choose from.
        ///     2. Disabling all buttons.
        ///     3. Updating the listbox displaying all the current chores the family member has.
        /// </summary>
        private void InitializeGUI()
        {
            // Adding chores to combobox and weekdays to listbox
            cmbChores.Items.AddRange(choresManager.GetChoreNames());
            lstWeekdays.DataSource = typeof(Weekdays).GetEnumNames();
            lstWeekdays.SelectedIndex = -1;

            UpdateListboxOverview(familyMember); // Showing chores for current family member

            // Disabling buttons
            btnAddChore.Enabled = false;
            btnDeleteChore.Enabled = false;
            btnEditChore.Enabled = false;
        }


        #region Buttons

        /// <summary>
        /// This method controls if the user wants to quit the application without saving
        /// changes made. If the user confirms, the form is closed and a DialogResult.Cancel is sent.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Creating messagebox with Yes/No option.
            DialogResult dialogResult = MessageBox.Show("Do you want to discard all changes?",
               "Please confirm your action", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes) // If the user presses "Yes"
            {
                DialogResult = DialogResult.Cancel; // return DialogResult.Cancel
            }
        }

        /// <summary>
        /// This method:
        ///     1. Controls sufficient user input is given to add a chore.
        ///     2. Adds selected chore in combobox with weekdays in listbox.
        ///     3. Updates listbox.
        ///     4. Clears all selection as a visual cue.
        /// </summary>
        private void btnAddChore_Click(object sender, EventArgs e)
        {
            if (ControlUserInput()) // Control sufficied user input
            {
                // Getting chore by index
                Chore choreMold = choresManager.GetChore(cmbChores.SelectedIndex);

                // Setting up variables
                string name = choreMold.Name;
                Guid id = choreMold.Id;
                List<Weekdays> weekdays = SetWeekdays();

                // Creating new chore
                Chore newChore = new Chore(name, id, weekdays);

                // Add chore to tempFamilymember
                tempFamilyMember.AddChore(newChore);

                // Update listbox and refresh GUI
                UpdateListboxOverview(tempFamilyMember);
                ClearSelection();
            }

        }

        /// <summary>
        /// This method deletes the currently selected chore in the combobox, 
        /// from tempFamilymember.
        /// </summary>        
        private void btnDeleteChore_Click(object sender, EventArgs e)
        {
            // Get ID of chore
            Guid id = GetId(cmbChores.SelectedIndex);

            // Get chore by ID
            Chore chore = tempFamilyMember.GetChoreById(id);

            // Delete Chore
            tempFamilyMember.DeleteChore(chore);

            // Update listbox and refresh GUI
            UpdateListboxOverview(tempFamilyMember);
            ClearSelection();
        }

        /// <summary>
        /// This method edits the weekdays the chore is to be done by the family member.
        /// </summary>
        private void btnEditChore_Click(object sender, EventArgs e)
        {
            if (ControlUserInput()) // Control sufficient user input
            {
                Guid id = GetId(cmbChores.SelectedIndex); // Get chore by index from combobox

                // Get chore by ID in the family member
                Chore chore = tempFamilyMember.GetChoreById(id);

                List<Weekdays> weekdays = SetWeekdays(); // Create a new list of selected weekdays
                chore.SetWeekdays(weekdays); // Set the weekdays for the current chore

                // Update listbox and refresh GUI
                UpdateListboxOverview(tempFamilyMember);
                ClearSelection();
            }

        }
        #endregion

        /// <summary>
        /// This method.
        ///     1. Gets chore in ChoresManager by index, provided from the pararmeter
        ///     2. Gets ID from the chore
        ///     3. Returns ID as a Guid.
        /// </summary>
        /// <param name="index">Index of chore´s Id to be retreived</param>
        /// <returns>A Guid of the chore from index in Choresmanager</returns>
        private Guid GetId(int index)
        {
            Chore chore = choresManager.GetChore(index);
            Guid id = chore.Id;
            return id;
        }

        /// <summary>
        /// This method resets all selections in the combobox and listbox for weekdays.
        /// </summary>
        private void ClearSelection()
        {
            cmbChores.SelectedIndex = -1;
            lstWeekdays.ClearSelected();
        }

        #region Control input & buttons Methods

        /// <summary>
        /// This method controls the user input whilst trying to edit or add a chore
        /// to the current family member.
        /// Control:
        ///     Chore is selected from the combobox.
        ///     Weekday(s) are marked in the listbox.
        /// </summary>
        /// <returns>True if chore and weekday(s) selected. Else False.</returns>
        private bool ControlUserInput()
        {
            bool chore = cmbChores.SelectedIndex != -1;
            bool days = lstWeekdays.SelectedItems.Count > 0;

            if (!days)
                MessageBox.Show("You have to select atleast one day the chore is to be done",
                    "Error: No day selected.");
            if (!chore)
                MessageBox.Show("You have to select a chore!", "Error: No chore selected.");

            return chore && days;

        }
        /// <summary>
        /// This method is responsible to enable and disable the Add, Delete and Edit button
        /// in the form.
        /// </summary>
        /// <param name="chore">Chore to be controlled, for enabling/disabling "add" button.</param>

        private void ControlButtons(Chore chore)
        {
            bool index = cmbChores.SelectedIndex != -1;

            // Controlling if chore exist and combobox item is selected
            if (ChoreExistFamilyMember(chore.Id) && index)
            {
                btnDeleteChore.Enabled = true;
                btnEditChore.Enabled = true;
                btnAddChore.Enabled = false;
            }
            else
            {
                btnDeleteChore.Enabled = false;
                btnEditChore.Enabled = false;
            }
            if (!ChoreExistFamilyMember(chore.Id) && index)
                btnAddChore.Enabled = true;
        }

        /// <summary>
        /// This method disables all buttons.
        /// </summary>
        private void ControlButtons()
        {
            btnDeleteChore.Enabled = false;
            btnEditChore.Enabled = false;
            btnAddChore.Enabled = false;

        }

        /// <summary>
        /// This method is responsible for controlling if a chore exist in the current family member.
        ///     1. Gets ID by parameter.
        ///     2. Compares the chores ID by iteration of all chores.
        /// </summary>
        /// <param name="id">ID of chore to be compared</param>
        /// <returns>True if the chore exists, else false</returns>
        private bool ChoreExistFamilyMember(Guid id)
        {
            foreach (Chore chore in tempFamilyMember.Chores) // Iterating through chores
            {
                if (chore.Id == id) // Comparing ID 
                    return true;
            }
            return false;
        }
        #endregion


        #region Listbox Methods

        /// <summary>
        /// This method is responsible for:
        ///     1. Counting chores
        ///     2. Iterating through all the chores
        ///     3. Adding the chore and weekdays for it to be done as a string in the listbox
        /// </summary>
        /// <param name="familyMember">Chores of current family member to be added to the listbox</param>
        private void UpdateListboxOverview(FamilyMember familyMember)
        {
            int length = familyMember.Chores.Count; // Amount of chores
            List<Chore> chores = familyMember.Chores; // Chores
            lstChoresOverview.Items.Clear();

            for (int i = 0; length > i; i++) // Iterating through all the chores
            {
                Chore chore = chores[i]; // Getting current chore by index

                // Getting variables
                string weekdaysTrunc = chore.WeekdaysTruncated();
                string choreRow = String.Format("{0,-27}{1}", chore.Name, weekdaysTrunc);

                // Adding formated string to listbox
                lstChoresOverview.Items.Add(choreRow);
            }

            lstChoresOverview.Update();
        }

        /// <summary>
        /// This method is responsible for:
        ///     1. Controlling which buttons are enabled and disabled by calling methods
        ///     2. Setting weekdays in listbox if the user has selected a chore it currently has
        /// </summary>

        private void cmbChores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChores.SelectedIndex != -1) // If nothing is selected
            {
                Chore chore = choresManager.GetChore(cmbChores.SelectedIndex);

                if (ChoreExistFamilyMember(chore.Id)) // Controlling if chore exist
                    // Setting weekdays if chore exist
                    SetWeekdaysListbox(tempFamilyMember.GetChoreById(chore.Id));

                else
                    lstWeekdays.ClearSelected();

                lblTimesPerWeek.Text = $"{chore.FrequencyToDo} times per week";
                ControlButtons(chore); // Controlling buttons
            }

            else
                ControlButtons(); // Controlling buttons
        }

        /// <summary>
        /// This method:
        ///     1. Retreives an object of Chore with weekdays for the chore to be done.
        ///     2. Iterates through the Weekdays and converts each enum to an integer.
        ///     3. Selects the weekdays in the listbox that the chore is to be done.
        /// </summary>
        /// <param name="chore">Chore to select the weekdays the chore is to be performed</param>
        private void SetWeekdaysListbox(Chore chore)
        {
            foreach (Weekdays day in chore.Weekdays) // Iterating through each weekday
            {
                // Selecting index in listbox by converting enum to int
                lstWeekdays.SetSelected((int)day, true);
            }
        }

        /// <summary>
        /// This method:
        ///     1. Creates a new list of Weekdays
        ///     2. Iterates through all the selected Weekdays in the listbox and 
        ///         adds them to the list
        ///     3. Returns a list of Enums of currently selected Weekdays
        /// </summary>
        /// <returns>An Enum list of weekdays currently selected</returns>
        private List<Weekdays> SetWeekdays()
        {
            List<Weekdays> weekdays = new List<Weekdays>();

            foreach (string weekdayStr in lstWeekdays.SelectedItems)
            {
                Weekdays weekday = (Weekdays)Enum.Parse(typeof(Weekdays), weekdayStr);
                weekdays.Add(weekday);
            }
            return weekdays;
        }


        #endregion

        // Setter & Getter
        public FamilyMember GetTempFamilyMember
        { get { return tempFamilyMember; } }
    }
}
