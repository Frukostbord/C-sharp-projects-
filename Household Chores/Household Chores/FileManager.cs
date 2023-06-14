using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace HouseholdChores
{
    /// <summary>
    /// This class function is to save and open files for the program.
    /// It has two methods, one for opening and one for saving files.
    /// </summary>
    class FileManager
    {
        // Local variables used to marking the files whilst saving and controlling whilst opening
        private const string fileVersionToken = "Household_Chores22-23";
        private const double fileVersionNr = 0.1;

        /// <summary>
        /// This method´s function is to save the chores, family members and family member´s chores.
        /// 1. It opens a SaveDialogFile window for the user to select path and file name.
        /// 2. It controls that the user has pressed "OK" & that a filename has been written.
        /// 3. If the controls are passed, the information is saved.
        /// 4. Returns true if the file is saved, else false.
        /// </summary>
        /// <param name="choresList">List of chores to be saved in a text file</param>
        /// <param name="familyMemberList">List of family members to be saved in a text file</param>
        /// <param name="path">Path selected by the user</param>
        /// <returns>True if text file is successfully saved, else false.</returns>
        public bool SaveHouseholdChoresToList(List<Chore> choresList, List<FamilyMember> familyMemberList, out string path)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog(); // Creating instance of savefiledialog
            saveFileDialog.Filter = "Text Files | *.txt"; // Information to user
            saveFileDialog.DefaultExt = "txt"; // File format
            saveFileDialog.Title = "Saving Household chores"; // Title

            // If user selected "OK" and the file has a name
            if (saveFileDialog.ShowDialog() == DialogResult.OK & saveFileDialog.FileName != "")
            {
                using (Stream stream = File.Open(saveFileDialog.FileName, FileMode.Create)) // Creates the file
                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    // Writing control and amount of tasks
                    streamWriter.WriteLine(fileVersionToken); // Token control
                    streamWriter.WriteLine(fileVersionNr); // Version control
                    streamWriter.WriteLine(choresList.Count); // Amount of chores
                    streamWriter.WriteLine(familyMemberList.Count); // Amount of family members

                    // Iterating through each chore
                    for (int i = 0; choresList.Count > i; i++)
                    {
                        Chore chore = choresList[i]; // Retreive each chore by index

                        // Save information about each chore
                        streamWriter.WriteLine(chore.Name);
                        streamWriter.WriteLine(chore.FrequencyToDo);
                        streamWriter.WriteLine(chore.Id);
                    }

                    // Iterating through each family member
                    for (int i = 0; familyMemberList.Count > i; i++)
                    {
                        FamilyMember familyMember = familyMemberList[i]; // Retreive each family member by index

                        // Save family member´s name and amount of chores
                        streamWriter.WriteLine(familyMember.Name);
                        streamWriter.WriteLine(familyMember.Chores.Count);

                        // Iterate through each chore the current family member has
                        for (int y = 0; familyMember.Chores.Count > y; y++)
                        {
                            Chore choreFamilyMember = familyMember.Chores[y]; // Retreive chore by index

                            // Save data of chore
                            streamWriter.WriteLine(choreFamilyMember.Name);
                            streamWriter.WriteLine(choreFamilyMember.Id);

                            // Save list of Weekdays as a string, seperated by ´,´
                            string weekdays = string.Join(",", choreFamilyMember.Weekdays.ToArray());
                            streamWriter.WriteLine(weekdays);

                        }
                    }

                    // Returns true if successfull
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
        /// This method´s function is to open a text file, set chores and 
        ///     family members and their respective chores.
        /// 1. We open a window for the user to select a file to be opened.
        /// 2. We read the first two lines in the text document as control (Token Version and Version number).
        /// 3. If the controls are satisfied:
        ///     Chores, family members and their respective chore´s are added through reference.
        /// </summary>
        /// <param name="choresList">List of chores to be added</param>
        /// <param name="familyMemberList">List of family members and their respective chores to be added</param>
        /// <returns>True if text file is successfully opened, else false.</returns>
        public bool ReadHouseholdChoresFromFile(List<Chore> choresList, List<FamilyMember> familyMemberList)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog(); // Creating a instance of OpenFileDialog
            openFileDialog.Filter = "Text Files | *.txt"; // Information to user
            openFileDialog.DefaultExt = "txt"; // File format
            openFileDialog.Title = "Opening Household chores"; // Title

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName);

                string versionTest = reader.ReadLine(); // Getting first line in text document to compare to control
                double version = double.Parse(reader.ReadLine()); // Getting second line in text document to compare to control

                if ((versionTest == fileVersionToken) && (version == fileVersionNr)) // Controlling first and second line
                {
                    int choresCount = int.Parse(reader.ReadLine()); // Number of Chores
                    int familyMembersCount = int.Parse(reader.ReadLine()); // Number of family members

                    // Iterating through each chore to be added.
                    for (int i = 0; choresCount > i; i++)
                    {
                        // Getting information
                        string name = reader.ReadLine();
                        int frequency = int.Parse(reader.ReadLine());
                        Guid id = Guid.Parse(reader.ReadLine());

                        // Creating a new chore
                        Chore chore = new Chore(name, frequency, id);

                        // Adding new chore
                        choresList.Add(chore);
                    }

                    // Iterating through every family member
                    for (int i = 0; familyMembersCount > i; i++)
                    {
                        FamilyMember familyMember = new FamilyMember();
                        familyMember.Name = reader.ReadLine(); // Setting name
                        int familyMemberChores = int.Parse(reader.ReadLine()); // Amount of chores

                        // Iterating through each chore for current family member
                        for (int y = 0; familyMemberChores > y; y++)
                        {
                            // Getting information
                            string name = reader.ReadLine();
                            Guid id = Guid.Parse(reader.ReadLine());
                            List<Weekdays> weekdays = WeekdaysStringToList(reader.ReadLine());

                            // Creating new chore
                            Chore chore = new Chore(name, id, weekdays);

                            // Adding chore to current family member
                            familyMember.AddChore(chore);
                        }

                        // Adding current family member with respective chores
                        familyMemberList.Add(familyMember);
                    }

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method:
        /// 1. Takes a string.
        /// 2. Splits it into an array.
        /// 3. Converts each item in array, converts it to an enum and adds it to a list.
        /// 4. Returns list with enums.
        /// </summary>
        /// <param name="weekdaysStr">String to be converted into list of Enum Weekdays</param>
        /// <returns>A list of enum Weekdays</returns>
        private List<Weekdays> WeekdaysStringToList(string weekdaysStr)
        {
            List<Weekdays> weekdays = new List<Weekdays>(); // list to be returned

            string[] weekdaysArray = weekdaysStr.Split(','); // Splitting in to array
            foreach (string dayStr in weekdaysArray) // Iterating through each day
            {
                // Converting to enum, then adding to list weekdays as a enum
                Weekdays day = (Weekdays)Enum.Parse(typeof(Weekdays), dayStr);
                weekdays.Add(day);
            }
            return weekdays;

        }

    }
}
