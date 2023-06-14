using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo_Reminder
{
    /// <summary>
    /// This is the Main form of the program. 
    /// It´s main function is add, change & delete tasks for the user. The tasks can be saved as a text file as well as opened to be displayed
    /// in the form. 
    /// 
    /// Tasks are saved as instances in a list in TaskManager, called tasksList.
    /// 
    /// Menubar:
    ///     Create new File:
    ///         Resets and discards all information unless saved. Refreshes GUI.
    ///     Open file:
    ///         Tries to open a text file with tasks by calling methods in TaskManager & FileManager.
    ///     Save file:
    ///         Saves the tasks in a text file.
    ///     Exit:
    ///         Exits the program. User is asked to confirm the action.
    ///     About:
    ///         Shows AboutBox, displaying information to the user of the program.
    ///         
    /// Tasks:
    ///     To add a task, the user has to:
    ///         1. Set time in the future.
    ///         2. Set a priority
    ///         3. Write a description
    ///         
    ///     The user can change and delete tasks with the "Change" and "Delete" buttons, if a task exist and is selected.
    ///        
    /// </summary>
    public partial class FormMain : Form
    {
        private TaskManager taskManager = new TaskManager();

        public FormMain()
        {
            InitializeComponent();
            InitializeGUI();
        }

        #region GUI controls
        /// <summary>
        /// Initializing GUI for the user.
        ///     - Adds & sets combobox with priority levels.
        ///     - Formats & sets datetimepicker.
        ///     - Set initial time before timer takes over, displaying time.
        ///     - Checks "Change" & "Delete" button.
        /// </summary>
        private void InitializeGUI()
        {
            // Adding enums to combobox
            cmbPriority.DataSource = Enum.GetValues(typeof(PriorityType));
            cmbPriority.SelectedIndex = -1;

            // Formatting combobox
            dtpToDo.Format = DateTimePickerFormat.Custom;
            dtpToDo.CustomFormat = "yyyy-MM-dd  HH:mm";
            dtpToDo.Value = DateTime.Now;

            // Label at bottom right displaying time
            txtDescription.Text = "";
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");

            ChangeAndDeleteButtonEnable(); // Controlling "Change" & "Delete" button

        }

        /// <summary>
        /// Resets GUI. Mainly used after an another action is performed by the user to give visual
        /// feedback.
        ///     - Checks "Change" & "Delete" button
        ///     - Sets combobox choice to -1
        ///     - Clears textbox for description
        ///     - Resets date time picker
        ///     - Clears selection in listbox
        /// </summary>
        private void UpdateGUI()
        {
            ChangeAndDeleteButtonEnable();

            cmbPriority.SelectedIndex = -1;

            txtDescription.Text = "";

            dtpToDo.Value = DateTime.Now;

            lstbToDoList.ClearSelected();
        }
        #endregion

        /// <summary>
        /// Timer that continiously updates current time. Displayed in the bottom right of FormMain.
        /// Updates once per second.
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        #region Menu items
        /// <summary>
        /// Removes all data and refreshes GUI. No data is saved. Refreshes GUI for the user as a visual cue.
        /// </summary>

        private void mstripNew_Click(object sender, EventArgs e)
        {
            UpdateGUI(); // Refresh GUI
            lstbToDoList.Items.Clear(); // Clears all items
            taskManager = new TaskManager(); // Removes current instance containing all tasks
        }

        /// <summary>
        /// This method uses other classes methods to open a file.
        ///     FormMain -> TaskManager -> FileManager (Controls and then opens the file).
        /// If the file is successfully opened, each task in the opened taskList is added to the listbox.
        /// Else it shows a error message.
        /// </summary>

        private void mstripOpen_Click(object sender, EventArgs e)
        {
            string errMessage = "Something went wrong when opening the file.";

            bool ok = taskManager.ReadDataFromFile(); // Calls method in TaskManager for opening a file
            if (!ok)
                MessageBox.Show(errMessage);
            else
            {
                // Adding items to the listbox by iterating through tasks in TaskList
                lstbToDoList.Items.Clear();
                UpdateGUI();
                for (int i = 0; i < taskManager.TaskmanagerLength(); i++)
                {
                    Task task = taskManager.RetreiveTask(i);
                    lstbToDoList.Items.Add(task.ToString());
                }
                lstbToDoList.Update();
            }

        }

        /// <summary>
        /// This method uses other classes methods to save a file.
        ///     FormMain -> TaskManager -> FileManager (Adds controls and then saves the file).
        /// If the file is successfully saved, an message of the path and file name is shown to the user.
        /// Else it shows a error message.
        /// </summary>
        private void mstripSave_Click(object sender, EventArgs e)
        {
            string errMessage = "Something went wrong while saving data to file";
            string path; // File path

            bool ok = taskManager.WriteDataToFile(out path);
            if (!ok)
                MessageBox.Show(errMessage);
            else
                MessageBox.Show($"Data saved to:\n{path}"); // Shows path and file name
        }

        /// <summary>
        /// This method is for exiting the application. A messagebox.OKCancel is shown. If the uses presses "OK", the application exits.
        /// Otherwise the user is taken back to the application.
        /// </summary>
        private void mstripExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Any changes not saved will be discarded.\n" +
                "Are you sure you want to exit?", "Warning!", MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK) // If user presses OK, application exits
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// This method opens up the "AboutBox" for the user.
        /// </summary>

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();

            if (aboutBox.ShowDialog() == DialogResult.OK)
                aboutBox.Close(); // Closes AboutBox

        }

        #endregion

        #region Controlling values

        /// <summary>
        /// This method controls:
        ///     1. A description is written by the user
        ///     2. A priority is set by the user
        ///     3. A datetime is set to the future
        /// </summary>
        /// <returns>Returns True if a description is written, a priority selected and datetime is set in the future. 
        /// Else returns False</returns>
        private bool ControlValues()
        {
            bool textDescription = !String.IsNullOrEmpty(txtDescription.Text);
            bool priority = (cmbPriority.SelectedIndex != -1);
            bool time = CompareDates();

            // Error messages for each missing value
            if (!textDescription)
                MessageBox.Show("You have to write a description.", "No description detected!");
            if (!priority)
                MessageBox.Show("You have to select a priority.", "No priority chosen!");
            if (!time)
                MessageBox.Show("The date has to be in the future.\nNothing can be done about the past...",
                    "Please select a time in the future!");


            return textDescription && priority && time; // Returns True if all boolean values are True.

        }

        /// <summary>
        /// This method compares the datetime selected by the user to the date now.
        /// </summary>
        /// <returns>Returns True if the datetime is set in the future, Else returns False</returns>
        private bool CompareDates()
        {
            if (DateTime.Compare(dtpToDo.Value, DateTime.Now) > 0) // Comparing date in datetimepicker to the datetime today
                return true;
            return false;
        }
        #endregion

        #region Form buttons & Listbox

        /// <summary>
        /// Controls input by user by calling ControlValues(). 
        /// If True, this method adds a task to the listbox and taskList in TaskManager.
        /// </summary>

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ControlValues()) // Controlling input by user
            {
                Task task = new Task(dtpToDo.Value, (PriorityType)cmbPriority.SelectedValue,
                    txtDescription.Text); // Creating an instance of task

                taskManager.AddTask(task); // Adding task to taskList

                lstbToDoList.Items.Add(task.ToString()); // Adding task to listbox
                lstbToDoList.Update();

                UpdateGUI(); // Visual feedback to the user that the task has been added.
            }
        }


        /// <summary>
        /// This method´s function is to change a task that´s already been added by the user.
        /// 1. It controls that a task has been selected and that the edited values are valid.
        /// 2. If all controls go through, the task chosen is edited to the new information.
        /// </summary>
        private void btnChange_Click(object sender, EventArgs e)
        {
            int index = lstbToDoList.SelectedIndex;

            // Controlling selected index in listbox, controlling task exits in taskList & that values are valid
            if (index != -1 && taskManager.ControlIndexInList(index) && ControlValues()) 
            {
                Task task = new Task(dtpToDo.Value, (PriorityType)cmbPriority.SelectedValue,
                txtDescription.Text); // Creating a new instance of task from user input

                taskManager.EditTask(index, task); // Calling method in other class to replace edited task
                lstbToDoList.Items[index] = task.ToString(); // Updating listbox with changes by the user
                lstbToDoList.Update();

                UpdateGUI(); // Refresh GUI

                MessageBox.Show("Task successfully edited!"); // Feedback to user
            }
        }

        /// <summary>
        /// This method´s function is to delete a task.
        /// 1. It controls that a task has been selected and that it exits in tasksLists in Taskmanager.
        /// 2. If the controls passes, the task is deleted in tasksLists in Taskmanager and in the listbox. 
        /// </summary>

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lstbToDoList.SelectedIndex;

            // Controlling selected index in listbox, controlling task exits in taskList
            if (index != -1 && taskManager.ControlIndexInList(index))
            {
                taskManager.DeleteTask(index); // Calling method in Taskmanager to delete selected task
                lstbToDoList.Items.RemoveAt(index); // Removing item in listbox
                lstbToDoList.Update();

                UpdateGUI(); // Refresh GUI

                MessageBox.Show("Task deleted successfully!"); // Feedback to user
            }


        }

        #endregion

        #region Manipulating buttons and listbox

        /// <summary>
        /// This method enables and disables the "Change" and "Delete" button in the MainForm, by controlling amount of items
        /// in the listbox (tasks) and if a task is selected in the listbox.
        /// </summary>
        private void ChangeAndDeleteButtonEnable()
        {
            if (lstbToDoList.Items.Count > 0 && lstbToDoList.SelectedIndex != -1)
            {
                btnChange.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnChange.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        #endregion

        /// <summary>
        /// This method retrieves the task selected in the listbox by getting it through the index in the tasksList from TaskManager.
        /// E.g, index 2 in the listbox is index 2 in the taskList. After retreiving the task from tasksList, it is displayed 
        /// in the form for the user to see.
        /// </summary>
        private void lstbToDoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstbToDoList.SelectedIndex;
            ChangeAndDeleteButtonEnable();

            if (index != -1)
            {
                Task task = taskManager.RetreiveTask(index);
                txtDescription.Text = task.Description;
                cmbPriority.SelectedItem = task.Priority;
                dtpToDo.Value = task.TaskDate;
            }

        }


    }
}
