using System;
using System.Collections.Generic;

namespace HouseholdChores
{
    /// <summary>
    /// This class purpose is to maintain information about:
    /// 1. Chore´s name
    /// 2. Frequency chore is to be done
    /// 3. Frequency chore is done
    /// 4. Unique ID
    /// 5. Weekdays when chore is to be done.
    /// 
    /// The class is used in ChoresManager as a mold for other classes to use freely. 
    /// </summary>
    class Chore
    {
        // Instance variables
        private string name;
        private int frequencyToDo;
        private int frequencyDone = 0;
        private Guid id; // Unique GUID to identify the Chore
        private List<Weekdays> weekdays = new List<Weekdays>(); // Weekdays chore is to be done

        // Constructors with different parameters
        #region Constructor


        public Chore(string name, int frequency, Guid id)
        {
            this.name = name;
            this.frequencyToDo = frequency;
            this.id = id;
        }

        public Chore(string name, Guid id, List<Weekdays> weekdays)
        {
            this.name = name;
            this.id = id;
            this.weekdays = weekdays;
        }

        public Chore(string name, int frequency, Guid id, List<Weekdays> weekdays)
        {
            this.name = name;
            this.frequencyToDo = frequency;
            this.id = id;
            this.weekdays = weekdays;

        }

        #endregion

        /// <summary>
        /// This method overwrites the current list and adds new weekdays given as an argument.
        /// </summary>
        /// <param name="weekdays">A list of weekdays</param>
        public void SetWeekdays(List<Weekdays> weekdays)
        {
            this.weekdays = new List<Weekdays>(); // Creating new List

            foreach (Weekdays day in weekdays) // Adding days from argument
                this.weekdays.Add(day);

        }

        /// <summary>
        /// This method takes the chore´s name, frequency to be done and frequency done.
        /// It then formats it and returns it as a string.
        /// </summary>
        /// <returns>Returns a string of the chore´s name, frequency to be done and frequency done.</returns>
        public override string ToString()
        {
            return String.Format("{0,-25}{1,-20}{2}", name,
                $"{frequencyToDo} times", $"{frequencyDone} times");
        }


        /// <summary>
        /// This method:
        /// 1. Iterates through every day in the list weekdays.
        /// 2. Creates a substring of each day and adds it to an array.
        /// 3. Joins the array of substrings to one string.
        /// 4. Returns the string.
        /// </summary>
        /// <returns>Returns an array of days as substrings (Monday, Tuesday = Mon, Tue)</returns>
        public string WeekdaysTruncated()
        {
            int length = weekdays.Count;

            string[] days = new string[length];

            for (int i = 0; length > i; i++)
            {
                days[i] = weekdays[i].ToString().Substring(0, 3);
            }

            string weekdaysTrunc = String.Join(", ", days);

            return weekdaysTrunc;
        }

        /// <summary>
        /// This method returns an integer of the number of days in weekdays.
        /// </summary>
        /// <returns>Number of days in the list weekdays</returns>
        public int CountWeekdays()
        { return weekdays.Count; }

        // Setters & Getters
        #region Setter & Getter
        public string Name { get { return name; } set { name = value; } }
        public int FrequencyToDo { get { return frequencyToDo; } set { frequencyToDo = value; } }
        public int FrequencyDone { get { return frequencyDone; } set { frequencyDone = value; } }
        public Guid Id { get { return id; } }
        public List<Weekdays> Weekdays { get { return weekdays; } set { weekdays = value; } }

        #endregion
    }
}
