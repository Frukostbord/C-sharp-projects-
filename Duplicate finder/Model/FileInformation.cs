namespace Duplicate_finder.Model;

/// <summary>
/// This Record holds information of a file, e.g Name, Creation date, Extension etc
/// </summary>

public record FileInformation
{
    // Relevant fileinformation
    public string Path { get; init; }
    public long Size { get; init; }
    public string FileName { get; init; }
    public string FileExtension { get; init; }
    public DateTime FileCreation { get; init; }
    public DateTime FileModified { get; init; }
    public string FullPath { get; init; }

    //Constructor
    public FileInformation(string path)
    {
        FileInfo file = new FileInfo(path);

        FileName = System.IO.Path.GetFileNameWithoutExtension(path);
        Path = file.Directory.FullName;
        Size = file.Length;
        FileExtension = file.Extension;
        FileCreation = file.CreationTime;
        FileModified = file.LastWriteTime;
        FullPath = file.FullName;
    }

    /// <summary>
    /// Formats a file´s information
    /// </summary>
    /// <returns>Returns a formatted string of a file´s information</returns>
    public override string ToString()
    {

        string file = String.Format("{0}{1,30}{2,45}{3,60}",
            $"Name: {FileName}",
            $"Type: {FileExtension.ToLower()}",
            $"Size: {Size} Bytes",
            $"Path: {ShortenString(Path)}");

        return file;
    }

    /// <summary>
    /// Shortens a string
    /// </summary>
    /// <param name="str">String to shorten</param>
    /// <returns>A shortened string</returns>
    private string ShortenString(string str)
    {
        if (str.Length > 35)
            return $"{str.Substring(0, 35)}...";
        return str;
    }
}