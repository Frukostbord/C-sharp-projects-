namespace Duplicate_finder.Model
{
    /// <summary>
    /// This class is responsible for holding all duplicate files information
    /// </summary>
    /// <typeparam name="FileInformation">Fileinformation Record</typeparam>
    public class DuplicateFileManager<FileInformation> : ListManager<FileInformation>
    {

        /// <summary>
        /// Takes a file´s path to delete.
        /// </summary>
        /// <param name="filePath">Filepath of file to be deleted</param>
        public void DeleteFile(string filePath)
        {
            if(!string.IsNullOrEmpty(filePath) && File.Exists(filePath)) File.Delete(filePath);
        }

    }
}
