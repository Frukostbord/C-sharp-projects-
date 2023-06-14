namespace Duplicate_finder.Model
{
 /// <summary>
/// This class is responsible for searching duplicate file(s)
/// 1. Gets search criteria from the user and parent directory
/// 2. Searches all files and then filters out according to criteria
/// 3. Returns a list for files found according to criteria
/// </summary>
    public class FileSearcher
    {

        /// <summary>
        /// Main method in this class.
        /// Gets all information and calls other methods to search for files.
        /// </summary>
        /// <param name="path">Parent path to search</param>
        /// <param name="searchParameter">Search criteria</param>
        /// <returns>A list of duplicate files if any are found, else null</returns>
        public static List<FileInformation> GetFiles(string path,
            (bool dateCreated, bool dateModified, bool fileName, bool size, bool type, bool subFolders) searchParameter)
        {
            List<FileInformation> allFiles; // All files
            List<FileInformation> searchedFiles; // Filtered files after search parameters

            if (path != null)
            {
                // Get all files depending on if subfolder are selected
                if (searchParameter.subFolders) { allFiles = SearchFolderAndSubFolders(path); }
                else { allFiles = SearchFolder(path); }

                // If any files are found
                if (allFiles != null)
                {
                    // Filter all files depending on search criteria
                    searchedFiles = FilterSearchParameters(allFiles, searchParameter);
                    return searchedFiles;
                }

            }

            return null;
        }

        #region Searching for files

        /// <summary>
        /// Searches parent directory and child directories
        /// </summary>
        /// <param name="path">Path to search from</param>
        /// <returns>A list of all files from the directory and all children directories</returns>
        private static List<FileInformation> SearchFolderAndSubFolders(string path)
        {
            List<FileInformation> list;

            // Gets all filpaths
            string[] filePaths = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            if (filePaths != null)
            {
                list = new List<FileInformation>();

                // Create FileInformation instance by calling other method and add files to list
                foreach (string filePath in filePaths)
                { list.Add(AddFileInformation(filePath)); }

                return list;
            }

            return null;

        }


        /// <summary>
        /// Searches given directory for files
        /// </summary>
        /// <param name="path">Path to search</param>
        /// <returns>A list of all files from the directory</returns>
        private static List<FileInformation> SearchFolder(string path)
        {
            List<FileInformation> list;

            // Get all file path(s) as strings
            string[] fileInfo = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly);

            if (fileInfo != null)
            {
                list = new List<FileInformation>();

                // Create FileInformation instance by calling other method and add files to list
                foreach (string filePath in fileInfo)
                { list.Add(AddFileInformation(filePath)); }

                return list;
            }

            return null;

        }



        /// <summary>
        /// Creates a record (FileInformation) from a given path
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>Record of FileInformation</returns>
        private static FileInformation AddFileInformation(string path)
        {
            FileInfo file = new FileInfo(path);

            if (file != null)
            {
                FileInformation fileInformation = new FileInformation(path);
                return fileInformation;
            }
            return null;

        }

        #endregion

        #region Filtering search parameters
        /// <summary>
        /// This method is responsible for filtering out all the files that are congruent with
        /// the search parameters.
        /// 1. Iterate through each file (allFiles)
        /// 2. Inner loop compares each file to all the other files.
        /// 2a. If a file is already added to the list of files, continue with the next iteration
        /// 2b. If a file matches with a search criteria, continue to the next iteration
        /// </summary>
        /// <param name="allFiles">All files found</param>
        /// <param name="searchParameter">Search parameters to filter from</param>
        /// <returns>A list of files that are similar in the selected folder from the serach criteria</returns>
        private static List<FileInformation> FilterSearchParameters(List<FileInformation> allFiles,
            (bool dateCreated, bool dateModified, bool fileName, bool size, bool type, bool SubFolders) searchParameter)
        {
            List<FileInformation> list;
            FileInformation file;
            FileInformation file2;


            if (allFiles != null) // Check list isn´t null
            {
                list = new List<FileInformation>();
                // Outer loop to check all files
                for(int i = 0; i < allFiles.Count;i++) 
                {
                    file = allFiles[i];


                    // Inner loop, comparing each selected criteria between files
                    for (int y = 0; y < allFiles.Count; y++)
                    {
                        file2 = allFiles[y];
                        // List for this iteration

                        // If the file found is the same as selected, ignore it and cycle to next loop
                        if (file.FullPath == file2.FullPath || ControlFileInList(file.FullPath, list)) { continue; }
                         
                        // Conditional statements depending on search criteria
                        if (searchParameter.dateModified)
                        {
                            if (file.FileModified == file2.FileModified) { list.Add(file); continue; }
                        }
                        if (searchParameter.dateCreated)
                        {
                            if (file.FileCreation == file2.FileCreation) { list.Add(file); continue; }
                        }
                        if (searchParameter.fileName)
                        {
                            if (file.FileName == file2.FileName) { list.Add(file); continue; }
                        }
                        if (searchParameter.size)
                        {
                            if (file.Size == file2.Size) { list.Add(file); continue; }
                        }
                        if (searchParameter.type)
                        {
                            if (file.FileExtension == file2.FileExtension) { list.Add(file); continue; }
                        }
                    }
                }

                return list;
            }

            return null;

        }

        /// <summary>
        /// Checks to see if a a file has the same path from a list of files
        /// </summary>
        /// <param name="path1">Path to check</param>
        /// <param name="files">Files to check paths from</param>
        /// <returns>True if the path exists in the list of files, else false</returns>
        private static bool ControlFileInList(string path1, List<FileInformation> files)
        {
            foreach(var file in files) 
            { if (path1 == file.FullPath) return true; }
            return false;
        }


        #endregion

    }
}
