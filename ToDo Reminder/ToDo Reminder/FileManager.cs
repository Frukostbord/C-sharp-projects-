using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo_Reminder
{
    /// <summary>
    /// This class function is to save and open files for the program.
    /// It has two methods, one for opening and one for saving files.
    /// </summary>
    class FileManager
    {
        // Local variables used marking the files whilst saving and controlling whilst opening
        private const string fileVersionToken = "ToDoRe_21";
        private const double fileVersionNr = 1.0;

        /// <summary>
        /// This method´s function is to save the tasks in FormMain as a text file.
        /// 1. It opens a SaveDialogFile window for the user to select path and file name.
        /// 2. It controls that the user has pressed "OK" & that a filename has been written.
        /// 3. If the controls are passed, the tasks saved row by row in a text file.
        /// 4. Returns true if the file is saved, else false.
        /// </summary>
        /// <param name="taskList">List of tasks to be saved in a text file</param>
        /// <param name="path">Path selected by the user</param>
        /// <param name="fileName">Filename selected by the user</param>
        /// <returns>True if text file is successfully saved, else false.</returns>
        public bool SaveTaskListToFile(List<Task> taskList, out string path)
        {
   
            SaveFileDialog saveFileDialog = new SaveFileDialog(); // Creating instance of savefiledialog
            saveFileDialog.Filter = "Text Files | *.txt"; // Information to user
            saveFileDialog.DefaultExt = "txt"; // File format
            saveFileDialog.Title = "Saving ToDo tasks"; // Title

            // If user selected "OK" and the file has a name
            if (saveFileDialog.ShowDialog() == DialogResult.OK & saveFileDialog.FileName != "")
            {
                using (Stream stream = File.Open(saveFileDialog.FileName, FileMode.Create)) // Creates the file
                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    // Writing control and amount of tasks
                    streamWriter.WriteLine(fileVersionToken); // Token control
                    streamWriter.WriteLine(fileVersionNr); // Version control
                    streamWriter.WriteLine(taskList.Count); // Amount of tasks

                    for (int i = 0; i < taskList.Count; i++) // Adding tasks by iterating through data for each task
                    {
                        streamWriter.WriteLine(taskList[i].Description);
                        streamWriter.WriteLine(taskList[i].Priority.ToString());
                        streamWriter.WriteLine(taskList[i].TaskDate.Year);
                        streamWriter.WriteLine(taskList[i].TaskDate.Month);
                        streamWriter.WriteLine(taskList[i].TaskDate.Day);
                        streamWriter.WriteLine(taskList[i].TaskDate.Hour);
                        streamWriter.WriteLine(taskList[i].TaskDate.Minute);
                        streamWriter.WriteLine(taskList[i].TaskDate.Second);
                    }
                    path = Path.GetFullPath(saveFileDialog.FileName); // File path, to be returned
                    return true;
                }

            }
            else // If controls aren´t satisfied (exits window or file has no name)
            {
                path = "";
                return false;
            }
        }

        /// <summary>
        /// This method´s function is to open a text file and add it to the FormMain window.
        /// 1. It clears the current taskList.
        /// 2. We open a window for the user to select a file to be opened.
        /// 3. We read the first two lines in the text document as control (Token Version and Version number).
        /// 4. If the controls are satisfied, the tasks are added to FormMain.
        /// </summary>
        /// <param name="taskList">List of tasks to be added</param>
        /// <returns>True if text file is successfully opened, else false.</returns>
        public bool ReadTaskListFromFile(List<Task> taskList)
        {

            // Clears taskList, otherwise creates a new one
            if (taskList != null)
                taskList.Clear();
            else
                taskList = new List<Task>();

            OpenFileDialog openFileDialog = new OpenFileDialog(); // Creating a instance of OpenFileDialog
            openFileDialog.Filter = "Text Files | *.txt"; // Information to user
            openFileDialog.DefaultExt = "txt"; // File format
            openFileDialog.Title = "Opening ToDo tasks"; // Title

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName);

                string versionTest = reader.ReadLine(); // Getting first line in text document to compare to control
                double version = double.Parse(reader.ReadLine()); // Getting second line in text document to compare to control

                if ((versionTest == fileVersionToken) && (version == fileVersionNr)) // Controlling first and second line
                {
                    int count = int.Parse(reader.ReadLine()); // Number of tasks
                    for (int i = 0; i < count; i++) // Loops through each task and adds them to taskList
                    {
                        Task task = new Task();
                        task.Description = reader.ReadLine(); // Description of task
                        task.Priority = (PriorityType)Enum.Parse(typeof(PriorityType), reader.ReadLine()); // Priority of task

                        // Reading date (year, month, day, hour, minute & second)
                        int year = 0, month = 0, day = 0;
                        int hour = 0, minute = 0, second = 0;

                        year = int.Parse(reader.ReadLine());
                        month = int.Parse(reader.ReadLine());
                        day = int.Parse(reader.ReadLine());
                        hour = int.Parse(reader.ReadLine());
                        minute = int.Parse(reader.ReadLine());
                        second = int.Parse(reader.ReadLine());

                        // Setting date from input in text file
                        task.TaskDate = new DateTime(year, month, day, hour, minute, second);

                        taskList.Add(task); // Adding task to taskList
                    }
                    return true;
                }
            }
            return false;
        }
    
    }
}
