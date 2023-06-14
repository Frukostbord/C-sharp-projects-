using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Reminder
{
    /// <summary>
    /// This class function is to manage Tasks. It contains a list of instances of Tasks, in its´ local variable "taskLists".
    /// It also contains methods to:
    ///     - Control tasksList length
    ///     - Control Index in taskList
    ///     - Editing tasks in tasksList
    ///     - Call to FileManager to open and save tasks in tasksList in a text file.
    /// </summary>
    internal class TaskManager
    {
        private List<Task> tasksList = new List<Task>(); // List containing instances of the object Task

        /// <summary>
        /// Returns length of tasksLists, that contains all instances of the Task.
        /// </summary>
        /// <returns>Length of tasksList</returns>
        public int TaskmanagerLength()
        {
            return tasksList.Count();
        }

        /// <summary>
        /// Controlling that the index given exists (!= null) in tasksLists and that the index is not larger that the length of tasksList.
        /// </summary>
        /// <param name="index">Index to be controlled in tasksLists</param>
        /// <returns>Returns True if there´s an instance of Tasks at given Index, else returns False</returns>
        public bool ControlIndexInList(int index)
        {
            if (tasksList.Count > index && tasksList[index] != null) 
                return true;
            return false;
        }

        #region Editing tasks in tasksList
        /// <summary>
        /// Adds a Task to tasksList.
        /// </summary>
        /// <param name="task">Task to be added</param>
        public void AddTask(Task task)
        {
            tasksList.Add(task);
        }

        /// <summary>
        /// Deletes a Task in tasksList
        /// </summary>
        /// <param name="index">Index to be deleted in taskLists</param>
        public void DeleteTask(int index)
        {
            tasksList.Remove(tasksList[index]);
        }

        /// <summary>
        /// Get a task from tasksList from the index provided.
        /// </summary>
        /// <param name="index">Index of the task to be retreived</param>
        /// <returns>Task at given index</returns>
        public Task RetreiveTask(int index)
        {
            return tasksList[index];
        }

        /// <summary>
        /// Replacing task in tasksList at given index.
        /// </summary>
        /// <param name="index">Index of task to be replaced</param>
        /// <param name="task">New task to replace task at given index</param>
        public void EditTask(int index, Task task)
        {
            tasksList[index] = task;
        }

        #endregion

        /// <summary>
        /// Creates an instance of FileManager, then calls a method in FileManager. 
        /// The method opens, controls and returns a boolean value if the file was successully opened.
        /// </summary>
        /// <returns>Returns True if file is successully opened, else False.</returns>
        public bool ReadDataFromFile()
        {
            FileManager fileManager = new FileManager();
            return fileManager.ReadTaskListFromFile(tasksList);
        }

        /// <summary>
        /// Creates an instance of FileManager, then calls a method in FileManager. 
        /// The method adds controls and returns a boolean value if the file was successully saved.
        /// </summary>
        /// <returns>Returns True if file is successully saved, else False.</returns>
        public bool WriteDataToFile(out string path)
        {
            FileManager fileManager = new FileManager();
            return fileManager.SaveTaskListToFile(tasksList, out path);
        }

    }
}