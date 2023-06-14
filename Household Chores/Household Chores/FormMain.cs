using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HouseholdChores
{
    /// <summary>
    /// This is the main method of the program. The program´s purpose is to get an overview of
    /// family members responsibility in the household, when it comes to chores.
    /// 
    /// ***Design***
    /// 
    /// The program contains two forms: FormMain and FormChores
    /// 
    /// ***FormMain***
    /// FormMain have five parts:
    /// 1. Family members:
    ///     The user can add, delete and edit family members.
    ///     Each family member are added as objects through FamilyMemberManager
    /// 2. Chores:
    ///     The user can add, delete and edit chores.
    ///     Each family member are added as objects through ChoresManager.
    /// 3. Menu:
    ///     The user can create a new form, open and save a file as well as exit the application.
    ///     FileManager is responsible for saving and opening files.
    /// 4. Edit chores:
    ///     If a family member and chore has been added, the user can edit the chores the selected
    ///     family member in the form is responsible for. It´s done in FormChores.
    /// 5. Chores overview (bottom listbox):
    ///     The combobox becomes available if atleast one family member is added. The user can select
    ///     a weekday and display all the family members as well as their chores to be done for the 
    ///     selected day. 
    /// 
    /// </summary>

    partial class FormMain : Form
    {
        // Instance variables
        private ChoresManager choresManager = new ChoresManager();
        private FamilyMemberManager familyMemberManager = new FamilyMemberManager();

        public FormMain()
        {
            InitializeComponent();
            InitializeGUI(); // Called to set up GUI
        }

        /// <summary>
        /// This method sets the initial GUI for FormMain.
        /// It also adds numbers in the combobox (cmbTimesPerWeek).
        /// </summary>
        private void InitializeGUI()
        {
            for (int i = 1; i < 8; i++) // Adding numbers in Combobox, 1 to 7
                cmbTimesPerWeek.Items.Add(i);

            cmbWeekDay.DataSource = Enum.GetValues(typeof(Weekdays));
            cmbWeekDay.SelectedIndex = -1;

            // Methods for enabling and disabling buttons in FormMain
            ControlChoresButtons();
            ControlFamilyButtons();
            ControlEditChores();
            ControlWeekdayCombobox();
        }

        #region Groupbox Chore (Adding, editing and deleting)

        /// <summary>
        /// This method is responsible for counting the amount of times a chore is done.
        ///     1. Gets all chores from choresManager.
        ///     2. Iterates through each chore.
        ///     3. Calls other method to calculate how many times chore is done.
        ///     4. Sets the amount of times a chore is done.
        /// </summary>
        private void SetChoreFrequencyDone()
        {
            int choreCount = choresManager.GetChoresCount();

            for (int i = 0; choreCount > i; i++) // Iterating through each chore
            {
                Chore chore = choresManager.GetChore(i); // Getting chore by index

                // Calculating and setting frequency a chore is done
                chore.FrequencyDone = CountChores(chore);
            }
        }

        /// <summary>
        /// This method is responsible for adding all the chores in the listbox.
        /// It adds the name, frequency of chore to be done and the frequency it is done.
        /// </summary>
        private void UpdateListboxChore()
        {
            lstChores.Items.Clear(); // Clear listbox

            int choreCount = choresManager.GetChoresCount();

            for (int i = 0; choreCount > i; i++) // Iterate through every chore in choresmanager
            {
                Chore chore = choresManager.GetChore(i); // Get chore by index
                lstChores.Items.Add(chore.ToString()); // Add chore as formatted string
            }
            lstChores.Update();
        }

        /// <summary>
        /// This method is responsible to count the amount of times a chore is done in total
        /// by all family members.
        ///     1. We iterate through every family member.
        ///     2. We get a family member based on index.
        ///     3. Get all the chores of the family member.
        ///     4. Compare the family member´s current chore to the id in the argument.
        ///     5. If it´s a match, call a method in chore to count the weekdays.
        ///     6. Return an integer the amount of times a chore is done by all family members.
        /// 
        /// </summary>
        /// <param name="choreToCount">Chore who´s ID is to be compared to</param>
        /// <returns>An integer of the times a chore is done by all family members</returns>
        private int CountChores(Chore choreToCount)
        {
            int count = 0;
            int familyMembers = familyMemberManager.GetFamilyMembersCount();

            for (int i = 0; i < familyMembers; i++) // Iterating through every family member
            {
                // Get family member.
                FamilyMember familyMember = familyMemberManager.GetFamilyMember(i);

                List<Chore> chores = familyMember.Chores; // Get all the family member´s chores

                foreach (Chore chore in chores) // Iterate through all the chores
                    if (chore.Id == choreToCount.Id) // Compare ID
                        // Add times it´s completed for current family member if IDs match
                        count += chore.CountWeekdays(); 
            }
            return count;
        }


        /// <summary>
        /// This method adds a new chore to the Class ChoreManager if conditions are met.
        /// 
        /// 1. Controls user input is adequate, else shows error message.
        /// 2. If input is correct, a new chore is created by Class Chore´s constructor:
        ///     Chore(name, frequency, id    
        /// 3. The chore is added to Chore manager through its´ method:
        ///     choresManager.AddChore(chore)
        /// 4. Update listbox with info for user.
        /// 5. Refresh GUI for visual cue to user and control form buttons.
        /// </summary>
        private void btnAddChore_Click(object sender, EventArgs e)
        {
            if (ControlChoreInput()) // Checking user input is correct
            {
                // Creating a new chore
                Guid id = Guid.NewGuid();
                Chore chore = new Chore(txtChoreName.Text, (int)cmbTimesPerWeek.SelectedItem, id);

                choresManager.AddChore(chore); // Adding chore to choresmanager

                // Adding chore to listbox
                lstChores.Items.Add(chore.ToString());

                RefreshChoresGroupBox(); // Refreshing GUI

                // Controlling buttons (enable/disable)
                ControlChoresButtons();
                ControlEditChores();
                ControlWeekdayCombobox();

            }

        }

        /// <summary>
        /// This method returns a boolean value if the user has entered sufficient
        /// information to create a new chore. 
        /// Else it returns false as well as error messages for each input
        /// the user hasn´t entered adequate information for.
        /// </summary>
        /// <returns>Boolean value if user has selected frequency and 
        /// entered a chore name</returns>
        private bool ControlChoreInput()
        {
            // Boolean values for input
            bool text = !String.IsNullOrEmpty(txtChoreName.Text);
            bool timesPerWeek = cmbTimesPerWeek.SelectedIndex != -1;

            // Error messages
            if (!text)
                MessageBox.Show("You have to write a name of the chore before trying to add it!", "Error: No name given");
            if (!timesPerWeek)
                MessageBox.Show("You have to select number of times the chore is to be done!", "Error: No frequency selected");

            return text && timesPerWeek; // Boolean value
        }

        /// <summary>
        /// This method deletes the selected chore in the listbox.
        /// 1. Controls if an item in the listbox is selected and that the chore exists
        ///     in Choremanager.
        /// 2. Deletes the chore in ChoreManager, for each family member and 
        ///     in the listbox.
        /// 3. Refresh GUI for visual cue.
        /// 4. Control buttons in FormMain.
        /// </summary>

        private void btnDeleteChore_Click(object sender, EventArgs e)
        {
            int index = lstChores.SelectedIndex;

            // Control index and that Chore exists.
            if (index != -1)
            {
                Chore chore = choresManager.GetChore(index);
                Guid id = chore.Id;

                familyMemberManager.DeleteFamilyMembersChore(id);
                choresManager.DeleteChore(index); // Deleting chore in ChoreManager

                lstChores.Items.RemoveAt(index); // Deleting chore in listbox


                // Refreshing GUI and updating listbox
                RefreshChoresGroupBox();

                ControlChoresButtons();
                ControlEditChores();
                ControlWeekdayCombobox();

                UpdateListboxChoresOverview();
            }
        }


        /// <summary>
        /// This method edits the Chore´s name:
        /// 1. Controls if input is correct and an item in the listbox is selected.
        /// 2. Get the Chore and set the new name in ChoresManager, for each family member
        ///     and in the listbox.
        /// 3. Refresh GUI for visual cue.
        /// </summary>

        private void btnEditChore_Click(object sender, EventArgs e)
        {
            int index = lstChores.SelectedIndex;

            // Control user input before editing
            if (index != -1 && ControlChoreInput())
            {
                Chore chore = choresManager.GetChore(index); // Get selected chore
                Guid id = chore.Id;
                chore.Name = txtChoreName.Text; // Change name
                chore.FrequencyToDo = (int)cmbTimesPerWeek.SelectedItem; // Change frequency

                lstChores.Items[index] = chore.ToString(); // Change name in listbox

                RefreshChoresGroupBox(); // Refresh GUI
                familyMemberManager.EditFamilyMemberChores(chore, id); // Edit name in all family members

                UpdateListboxChoresOverview();
            }
        }



        /// <summary>
        /// This method is responsible to update the GUI as a visual cue for the user
        /// if an item is selected in the listbox containing chores.
        /// 1. Controls an item is selected.
        /// 2. Resets choices in all other fields but current Chores groupbox.
        /// 3. Controls buttons to be enabled/disabled
        /// </summary>
        private void lstChores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstChores.SelectedIndex;

            if (index != -1)
            {
                Chore chore = choresManager.GetChore(index); // Get Chore

                // Set input in combobox and textbox to the Chore selected
                txtChoreName.Text = chore.Name;
                cmbTimesPerWeek.SelectedItem = chore.FrequencyToDo;

                // Removing input in other groupboxes
                lstFamilyMembers.SelectedIndex = -1;
                RefreshFamilyGroupbox();

                // Controlling buttons (enabled/disabled)
                ControlChoresButtons();
                ControlEditChores();
            }
        }

        /// <summary>
        /// This method refreshes the groupbox to give visual cue to the user.
        /// It also updates the listbox in Groupbox Chores.
        /// </summary>
        private void RefreshChoresGroupBox()
        {
            txtChoreName.Text = "";
            cmbTimesPerWeek.SelectedIndex = -1;
            lstChores.SelectedIndex = -1;
            lstChores.Update();
        }

        /// <summary>
        /// Controls if the buttons in Groupbox Chores should be enabled or disabled.
        /// </summary>
        private void ControlChoresButtons()
        {
            // Checking if any Chore is added and if an item in listbox is selected
            if (lstChores.Items.Count > 0 && lstChores.SelectedIndex != -1)
            {
                btnEditChore.Enabled = true;
                btnDeleteChore.Enabled = true;
            }

            else
            {
                btnEditChore.Enabled = false;
                btnDeleteChore.Enabled = false;
            }
        }

        #endregion
        



        /// <summary>
        /// This method 
        ///     1. Removes all current data
        ///     2. Refreshes GUI
        /// </summary>
        private void ResetFormAndData()
        {
            // Removing all data
            choresManager = new ChoresManager();
            familyMemberManager = new FamilyMemberManager();

            //Refreshing GUI
            lstChores.Items.Clear();
            lstChoresOverview.Items.Clear();
            lstFamilyMembers.Items.Clear();

            txtChoreName.Text = "";
            txtFamilyMemberName.Text = "";

            cmbTimesPerWeek.Items.Clear();
            ControlWeekdayCombobox();

            InitializeGUI();
        }


       

        #region Groupbox Family Members (Adding, editing and deleting)

        /// <summary>
        /// This method is responsible for adding a family member.
        /// If user input is sufficient, a family member is added, the GUI refreshed and 
        /// a new object created.
        /// </summary>

        private void btnAddFamilyMember_Click(object sender, EventArgs e)
        {
            if (ControlFamilyName()) // Controlling user input
            {
                // Creating new object
                FamilyMember familyMember = new FamilyMember(txtFamilyMemberName.Text);

                // Adding object to familyMemberManager
                familyMemberManager.AddFamilyMember(familyMember);

                lstFamilyMembers.Items.Add(familyMember.Name);

                //Refreshing GUI and updating listbox
                RefreshFamilyGroupbox();
                ControlFamilyButtons();
                ControlEditChores();
                ControlWeekdayCombobox();
                UpdateListboxChoresOverview();
            }

        }

        /// <summary>
        /// This method:
        ///     1. Gets amount of family members
        ///     2. Iterates through every family member
        ///     3. Adds the family member´s name in the listbox
        /// </summary>
        private void UpdateListboxFamilyMembers()
        {
            List<FamilyMember> familyMembers = familyMemberManager.GetFamilyMembers;
            int familyMembersCount = familyMembers.Count;

            // Iterating through all family members
            for (int i = 0; familyMembersCount > i; i++)
                lstFamilyMembers.Items.Add(familyMembers[i].Name);
        }


        /// <summary>
        /// This method refreshes the family groupbox, by resetting selection.
        /// </summary>
        private void RefreshFamilyGroupbox()
        {
            txtFamilyMemberName.Text = "";
            lstFamilyMembers.SelectedIndex = -1;
            lstFamilyMembers.Update();
        }

        /// <summary>
        /// This method controls if the user has provided a name in the textbox for
        /// the family member.
        /// </summary>
        /// <returns>True if text box is not empty, else false.</returns>
        private bool ControlFamilyName()
        {
            bool name = !String.IsNullOrEmpty(txtFamilyMemberName.Text);

            if (!name)
                MessageBox.Show("You have to write a name.", "Error: No name found");

            return name;
        }

        /// <summary>
        /// This method is responsible for deleting a family member.
        ///     1. It controls that the family member exist and is chosen in the listbox.
        ///     2. It removes the object from FamilyManager.
        ///     3. Refreshes GUI, controls buttons and counts chore is done in total 
        /// </summary>

        private void btnDeleteFamilyMember_Click(object sender, EventArgs e)
        {
            int index = lstFamilyMembers.SelectedIndex;

            if (familyMemberManager.ControlIndex(index) && index != -1) // Controlling input
            {
                familyMemberManager.DeleteFamilyMember(index); // Deleting family member

                lstFamilyMembers.Items.RemoveAt(index);

                // Refreshing GUI and controlling buttons
                RefreshFamilyGroupbox();
                ControlFamilyButtons();
                ControlEditChores();
                ControlWeekdayCombobox();
                SetChoreFrequencyDone(); // Updating times chore is done
                UpdateListboxChore();
                UpdateListboxChoresOverview();
            }
        }


        /// <summary>
        /// This method is responsible for changing the name of a family member.
        ///     1. Controls input of new name is correct and that the object exists
        ///     2. Refresh GUI to display new name
        /// </summary>

        private void btnEditFamilyMember_Click(object sender, EventArgs e)
        {
            int index = lstFamilyMembers.SelectedIndex;

            // Controlling iput
            if (familyMemberManager.ControlIndex(index) && index != -1 && ControlFamilyName())
            {
                // Getting family member
                FamilyMember familyMember = familyMemberManager.GetFamilyMember(index);
                familyMember.Name = txtFamilyMemberName.Text; // Changing name

                lstFamilyMembers.Items[index] = familyMember.Name;

                // Refreshing GUI
                RefreshFamilyGroupbox();
                UpdateListboxChoresOverview();
            }
        }

        /// <summary>
        /// This method is responsible for displaying the family member´s name in the textbox,
        /// for the user to edit it.
        /// </summary>

        private void lstFamilyMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstFamilyMembers.SelectedIndex;

            if (index != -1) // Controlling index
            {
                // Getting family member from index
                FamilyMember familyMember = familyMemberManager.GetFamilyMember(index);

                txtFamilyMemberName.Text = familyMember.Name;

                RefreshChoresGroupBox();

                // Controlling buttons
                ControlFamilyButtons();
                ControlEditChores();
            }
        }

        /// <summary>
        /// This method is responsible for controlling the buttons in the family groupbox, for
        /// editing and deleting a family member´s name.
        /// </summary>
        private void ControlFamilyButtons()
        {
            // Controlling amount of family members
            if (lstFamilyMembers.Items.Count > 0 && lstFamilyMembers.SelectedIndex != -1)
            {
                btnEditFamilyMember.Enabled = true;
                btnDeleteFamilyMember.Enabled = true;
            }

            else
            {
                btnEditFamilyMember.Enabled = false;
                btnDeleteFamilyMember.Enabled = false;
            }
        }

        /// <summary>
        /// This method is responsible for controlling listbox for overview of chores.
        /// If a family member has been added, it´s enabled.
        /// </summary>
        private void ControlWeekdayCombobox()
        {
            bool familyMembers = lstFamilyMembers.Items.Count > 0;

            if (familyMembers) { cmbWeekDay.Enabled = true; }
            else cmbWeekDay.Enabled = false;
        }

        #endregion

        #region Adding Chores to family member

        /// <summary>
        /// This method is responsible for adding chores to a family member:
        ///     1. Controlling if the family member exists and if one has been selected.
        ///     2. Open FormChores with it´s constructor (title, choresManager, familyMember to be edited).
        ///     3. If the user has accepted the changes in FormCHores (DialogResult.OK):
        ///         the changes are deep copied to the current family member. 
        ///         GUI is updated.
        ///        
        ///         Elseif (Dialogresult.Cancel), changes done in the form are discarded.

        /// </summary>

        private void btnChoresFamilyMember_Click(object sender, EventArgs e)
        {
            int index = lstFamilyMembers.SelectedIndex;

            // Controlling family member exist and if one is selected
            if (index != -1 && familyMemberManager.ControlIndex(index))
            {
                // Getting family member and setting title
                FamilyMember familyMember = familyMemberManager.GetFamilyMember(index);
                string title = $"Editing chores for {familyMember.Name}";

                // Creating form
                using (FormChores choresFamilyMember = new FormChores(title, choresManager, familyMember))
                {
                    // Opening form
                    choresFamilyMember.ShowDialog();

                    // If user accepts changes
                    if (choresFamilyMember.DialogResult == DialogResult.OK)
                    {
                        // Deep copying all the changes made in the form
                        familyMember.DeepCopyFamilyMember(familyMember, choresFamilyMember.GetTempFamilyMember);

                        // Updating GUI
                        SetChoreFrequencyDone();
                        UpdateListboxChore();
                        UpdateListboxChoresOverview();
                    }

                    // If user discards changes
                    else if (choresFamilyMember.DialogResult == DialogResult.Cancel)
                    {
                        choresFamilyMember.Close();
                    }
                }
            }
        }


        /// <summary>
        /// This method is responsible for controlling the "Edit chore" buttons, for editing
        /// the chores a family member has.
        /// </summary>
        private void ControlEditChores()
        {
            int familyCount = lstFamilyMembers.Items.Count;
            int choresCount = lstChores.Items.Count;
            int index = lstFamilyMembers.SelectedIndex;

            if (familyCount > 0 && choresCount > 0 && index != -1) // Controlling input
                btnChoresFamilyMember.Enabled = true;
            else
                btnChoresFamilyMember.Enabled = false;
        }
        #endregion

        #region Chores Overview
        /// <summary>
        /// This method is responsible for updating the listbox for overview for each family members
        /// chores, depending on the weekday selected in the combobox.
        ///     1. Control item in combobox is selected
        ///     2. Iterate through all family members
        ///     3. Get all the chores done the selected day.
        ///     4. Format string and add to listbox.
        /// </summary>
        private void UpdateListboxChoresOverview()
        {

            if (cmbWeekDay.SelectedIndex != -1) // Controlling input
            {
                lstChoresOverview.Items.Clear();

                int familyMembers = familyMemberManager.GetFamilyMembersCount();
                Weekdays day = (Weekdays)cmbWeekDay.SelectedItem; // Converting to enum

                for (int i = 0; familyMembers > i; i++) // Iterating through all family members
                {
                    // Getting family member by index
                    FamilyMember familyMember = familyMemberManager.GetFamilyMember(i);

                    // Getting all chores done selected day
                    string chores = RetreiveChoresWeekday(day, familyMember);

                    // Format string and adding to listbox
                    lstChoresOverview.Items.Add(String.Format("{0,-30}{1}", familyMember.Name,
                        chores));
                    lstChoresOverview.Items.Add("");
                }
            }

            if (cmbWeekDay.Enabled == false)
                cmbWeekDay.SelectedIndex = -1;
        }

        /// <summary>
        /// This method updates the listbox if another weekday in the combobox is selected,
        /// in the groupbox chores overview.
        /// </summary>

        private void cmbWeekDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListboxChoresOverview();
        }

        /// <summary>
        /// This method is responsible for getting all chores done a weekday.
        ///     1. Get all chores done by the family member
        ///     2. Iterate through all the chores.
        ///     3. If the selected day exists in the list of weekdays the chore is to be done, add chore.
        ///     4. Return an string of chores to be done.
        /// </summary>
        /// <param name="day">Weekday to be controlled for if a chore is done</param>
        /// <param name="familyMember">Family member´s chores to be checked if chore is done at parameter "day"</param>
        /// <returns></returns>
        private string RetreiveChoresWeekday(Weekdays day, FamilyMember familyMember)
        {
            List<Chore> chores = familyMember.Chores; // Chores to iterate through
            List<string> choresList = new List<string>();

            foreach (Chore chore in chores) // Iterating through chores
            {
                if (chore.Weekdays.Contains(day)) // Checking if selected day exist in current chore
                {
                    choresList.Add(chore.Name); // Adds chore´s name
                }
            }

            // Converts list of chores > array of chores > string of chores
            string choresStr = String.Join(", ", choresList.ToArray()); 

            return choresStr;
        }


        #endregion
        #region Menu buttons

        /// <summary>
        /// This method is responsible for creating a new file.
        /// It asks the user, if the user selects "yes" all data is removed and GUI is refreshed.
        /// </summary>

        private void ttpNewFile_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("All unsaved changes will be removed.\n" +
                "Are you sure you want to continue?", "Creating new file", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                ResetFormAndData(); // Removes all data and refreshes GUI
            }
        }



        /// <summary>
        /// This method is responsible for saving all the data in the application.
        /// It calls a method in fileManager to save the data to a text file.
        /// </summary>
        private void tsmSaveFile_Click(object sender, EventArgs e)
        {
            string errMessage = "Something went wrong while saving data to file";
            string path; // File path

            FileManager filemanager = new FileManager();


            bool ok = filemanager.SaveHouseholdChoresToList(choresManager.GetChores, familyMemberManager.GetFamilyMembers, out path);
            if (!ok)
                MessageBox.Show(errMessage);
            else
                MessageBox.Show($"Data saved to:\n{path}"); // Shows path and file name
        }

        /// <summary>
        /// This method is responsible for opening a new file and displaying information 
        /// in the GUI from the file.
        /// </summary>

        private void tsmOpenFile_Click(object sender, EventArgs e)
        {
            // Controlling if user wants to open a new file
            DialogResult dialogResult = MessageBox.Show("All unsaved changes will be removed.\n" +
                "Are you sure you want to continue?", "Opening new file", MessageBoxButtons.YesNo);

            string errMessage = "Couldn´t open file. Please look over the selected file.";

            if (dialogResult == DialogResult.Yes)
            {
                ResetFormAndData(); // Reset all data and refresh GUI

                FileManager fileManager = new FileManager();

                // Trying to opening file
                bool ok = fileManager.ReadHouseholdChoresFromFile
                    (choresManager.GetChores, familyMemberManager.GetFamilyMembers);

                if (ok) // If file is successfully opened
                {
                    // Refresh GUI
                    SetChoreFrequencyDone();
                    UpdateListboxChoresOverview();
                    UpdateListboxChore();
                    UpdateListboxFamilyMembers();
                    ControlWeekdayCombobox();
                }

                else
                    MessageBox.Show(errMessage, "Error!");

            }

        }
        /// <summary>
        /// This method is responsible for exiting the application.
        /// A control message is shown, if the user choses "yes", the application is closed.
        /// </summary>
    
        private void tsmExitMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?",
                "Exiting application", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Thank you for this course!");
                Close();
            }
        }
        #endregion
    }
}
