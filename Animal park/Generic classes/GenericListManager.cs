using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;

namespace Apu_Animal_Park_4
{
    /// <summary>
    /// A generic list manager that takes a variable or object to be used in a list, e.g:
    /// T = obj, then (List<obj> l = new List<obj>();)
    /// The list manager can add, delete, change and sort objects in the list.
    /// </summary>
    /// <typeparam name="T">T type variable to be used</typeparam>
    public class GenericListManager<T> : IGenericListManager<T>

    {
        List<T> m_list = new List<T>();

        public int Count { get { return m_list.Count; } } // nr of items in list

        /// <summary>
        /// Adds item to list if it isn´t null
        /// </summary>
        /// <returns>True if item was added, else false</returns>
        public bool Add(T type)
        {
            if (type != null)
            {
                m_list.Add(type);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Controls index given in list
        /// </summary>
        /// <param name="index">Index to control</param>
        /// <returns>True if index is OK, else false</returns>
        public bool CheckIndex(int index)
        {
            if (index >= 0 && index < Count)
                return true;
            return false;

        }

        /// <summary>
        /// Replaces T type at given index
        /// </summary>
        /// <param name="type">T type to replace with</param>
        /// <param name="index">Index T type should replace</param>
        /// <returns>True if successfull</returns>
        public bool ChangeAt(T type, int index)
        {
            if (type != null && CheckIndex(index))
            {
                m_list[index] = type;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deletes all items in m_list
        /// </summary>
        public void DeleteAll()
        {
            m_list.Clear();
        }

        /// <summary>
        /// Deletes item in m_list at given index
        /// </summary>
        /// <param name="index">Of item to be deleted</param>
        /// <returns>True if deleted</returns>
        public bool DeleteAt(int index)
        {
            if (CheckIndex(index))
            {
                m_list.RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retreives object at given index
        /// </summary>
        /// <param name="index">Index of object to be retreived</param>
        /// <returns>Item at given index</returns>
        public T GetAt(int index)
        {
            if (CheckIndex(index)) { return m_list[index]; }
            return default;
        }

        /// <summary>
        /// Virtual dummy class to be edited by subclasses
        /// </summary>
        /// <returns>A list of string[] arrays</returns>
        public virtual List<string[]> ToListStringArray()
        {
            List<string[]> list = new List<string[]>();

            return list;
        }

        /// <summary>
        /// Returns an array strings[] of given object
        /// </summary>
        /// <returns></returns>
        public string[] ToStringArray()
        {
            string[] strings = new string[Count];

            for (int i = 0; i < Count; i++)
            {
                T info = GetAt(i);
                strings[i] = info.ToString();
            }

            return strings;
        }

        /// <summary>
        /// Sort objects according to the Icomprarer
        /// </summary>
        /// <param name="sort">Icomparer method to be used for sorting</param>
        public void SortObjects(IComparer<T> sort)
        {
            m_list.Sort(sort);
        }

        /// <summary>
        /// Let´s the user serialize an entire list to json.
        /// </summary>
        /// <param name="filePath">Filepath to serialize the file to</param>
        public void JsonSerialization(string filePath)
        {
            JsonSerializer serializer;

            if (!String.IsNullOrEmpty(filePath)) // Checking value OK
            {
                serializer = new JsonSerializer();

                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(streamWriter, m_list); // Serializing the entire list (m_list)
                }
            }
        }

        /// <summary>
        /// Let´s the user deserialize a file and retreive it as a list.
        /// Then adds each item to the list in this class (m_list)
        /// </summary>
        /// <param name="filePath"></param>
        public void JsonDeserialization(string filePath)
        {
            // Reads the entire file
            string jsonString = File.ReadAllText(filePath);

            // Deserialize the file and get a list of objects
            List<Object> objects = JsonConvert.DeserializeObject<List<Object>>(jsonString);

            // Adds each object in the list of object to m_list
            foreach (Object obj in objects)
            {
                m_list.Add((T)obj);
            }

        }

        /// <summary>
        /// Lets the user binary serialize all the objects in m_list
        /// </summary>
        /// <param name="filePath">Filepath of file to be deserialized</param>
        public void BinarySerialization(string filePath)
        {
            Stream stream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            if (!String.IsNullOrEmpty(filePath))
            {

                using (stream = File.Open(filePath, FileMode.Create)) // Creates the file
                {
                    foreach (object obj in m_list)
                    {
                        binaryFormatter.Serialize(stream, obj);
                    }
                }

                stream.Close();
            }
        }

        /// <summary>
        /// Lets the user deseralize a binary serialized file of objects.
        /// </summary>
        /// <param name="filePath">Filepath of file to be deserialized</param>
        public void BinaryDeserialization(string filePath)
        {
            FileStream fileStream;
            BinaryFormatter binaryFormatter;
            Object obj;

            if (!String.IsNullOrEmpty(filePath)) // Check file OK
            {
                using (fileStream = new FileStream(filePath, FileMode.Open))
                {

                    binaryFormatter = new BinaryFormatter();

                    while (fileStream.Position < fileStream.Length)
                    {
                        // Deserialize to object
                        obj = binaryFormatter.Deserialize(fileStream);
                        // Cast to correct type and add object to m_list
                        m_list.Add((T)obj);
                    }
                }
            }
        }

        /// <summary>
        /// Serializes the m_list of objects to XML format
        /// </summary>
        /// <param name="filePath">Filepath to serialize to XML</param>
        public void XMLSerialization(string filePath)
        {
            XmlSerializer xmlSerializer;
            StreamWriter streamWriter;

            if (!String.IsNullOrEmpty(filePath))
            {
                using (streamWriter = new StreamWriter(filePath))
                {
                    xmlSerializer = new XmlSerializer(typeof(List<T>)); // Type (T) to serialize
                    xmlSerializer.Serialize(streamWriter, m_list); // Serializes m_list with objects of type T
                }
            }

        }

        /// <summary>
        /// Deserialization of a XML file containing information about food items.
        /// </summary>
        /// <param name="filepath">File path aimed to deserialize</param>

        public void XMLDeserialization(string filepath)
        {
            XmlSerializer serializer;
            List<T> foodItem;

            if (!String.IsNullOrEmpty(filepath))
            {
                using (Stream reader = new FileStream(filepath, FileMode.Open))
                {
                    serializer = new XmlSerializer(typeof(List<T>));

                    // Call the Deserialize method to restore the object's state.
                    foodItem = (List<T>)serializer.Deserialize(reader);

                    // Adding each food item
                    foreach (var food in foodItem)
                        m_list.Add(food);

                }
            }
        }
    }
}
