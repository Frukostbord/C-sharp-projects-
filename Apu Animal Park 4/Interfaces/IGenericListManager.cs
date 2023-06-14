using System.Collections.Generic;
using System.IO;

namespace Apu_Animal_Park_4
{
    /// <summary>
    /// This class contains methods for basic manipulation of a list.
    /// 1. It allows addition, change and deletion of T variable in a list.
    /// 2. It allows the retreival of T variable in a list.
    /// 3. It allows sorting using IComparer
    /// 4. It allows getting information of the T variable in the list as a string[] array, or as a list<string[]> of string arrays
    /// </summary>
    /// <typeparam name="T">Generic variable type</typeparam>


    interface IGenericListManager<T>
    {
        int Count { get; } // Retreives the number of objects in the list

        bool Add(T type); // Allows addition of object to list
        bool ChangeAt(T type, int index); // Allows changing of object at index x, for a new object
        bool CheckIndex(int index); // Allows controlling of index, if it´s within range
        void DeleteAll(); // Deletion of all objects in list
        bool DeleteAt(int index); // Delete Object at given index
        T GetAt(int index); // Get object at given index
        List<string[]> ToListStringArray(); // Return a list<string[]> of information of objects
        string[] ToStringArray(); // Returns a string[] of information of objects
        void SortObjects(IComparer<T> sort); // Allows sorting using IComparer. External methods needed
        void JsonSerialization(string filePath); // Serializing object with Json
        void JsonDeserialization(string filePath); // Deserializing Json file (.json)
        void BinarySerialization(string filePath); // Serializing object with binary serialization
        void BinaryDeserialization(string filePath); // Deserializing binary file (.bin)
        void XMLSerialization(string filePath); // Serializing with XML (.xml)
        void XMLDeserialization(string filePath); // Deserializing XML file (.xml)



    }
}
