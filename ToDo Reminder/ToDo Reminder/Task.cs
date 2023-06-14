using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Reminder
{
    /// <summary>
    /// This class contains information and methods for a Task.
    /// A task has three instance variables:
    ///     taskDate - Representing due date of task
    ///     priority - Priority level of a task
    ///     description - What the task entails
    ///     
    /// </summary>
    public class Task
    {
        // Local variables
        private DateTime taskDate; // Due date of Task
        private PriorityType priority; // Priority level
        private string description; // Description of Task

        /// <summary>
        /// Basic constructor.
        /// </summary>
        public Task()
        { }

        /// <summary>
        /// Constructor with three parameters for creating a new Task.
        /// </summary>
        /// <param name="taskDate">Due date for the task to be completed</param>
        /// <param name="priority">Priority level of the task</param>
        /// <param name="description">Description of the task</param>
        public Task (DateTime taskDate, PriorityType priority, string description)
        {
            this.taskDate = taskDate;
            this.priority = priority;
            this.description = description;
        }


        #region Retreive string

        /// <summary>
        /// This method returns a formatted string of which date the Task is to be finished.
        /// </summary>
        /// <returns>Date the task is to completed as a string</returns>
        public string DateToString()
        {
            return $"den {taskDate.ToString("dd MMMM yyyy")}";
        }

        /// <summary>
        /// This method returns a formatted string of when during the day the Task is to be finished.
        /// </summary>
        /// <returns>Time of day (24 h) the task is to completed as a string</returns>
        public string HourToString()
        {
            return taskDate.ToString("HH:mm");
        }

        /// <summary>
        /// This method formats the information of the current task to return it as a string.
        /// The information is:
        ///     Date 
        ///     Priority 
        ///     Description.
        /// </summary>
        /// <returns>A formatted string of the Task</returns>
        public override string ToString()
        {
            string date = DateToString();
            string hour = HourToString();
            string priorityEdited = priority.ToString().Replace("_"," ");

            return String.Format("{0,-28}{1,-9}{2,-25}{3}", date, hour, priorityEdited, description);
        }

        #endregion


        #region Setters & Getters
        // Setters & Getters
        public DateTime TaskDate
        { get { return taskDate; } set { taskDate = value; } }
        public PriorityType Priority
        { get { return priority; } set { priority = value; } }
        public string Description
        { get { return description; } set { description = value; } }
        #endregion

    }
}
