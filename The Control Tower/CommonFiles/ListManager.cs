using System.Collections.Generic;

namespace The_Control_Tower___Delegates_and_Events
{
    /// <summary>
    /// Contains basic blueprints of manipulating generic object in a list by methods, for a class to inherit.
    /// </summary>
    /// <typeparam name="T">T type</typeparam>

    internal class ListManager<T> : IListManager<T>
    {

        List<T> m_list = new List<T>();

        public int Count { get { return m_list.Count; } } // nr of items in list

        /// <summary>
        /// Adds item to list if it isn´t null
        /// </summary>
        /// <returns>True if item was added, else false</returns>
        public void Add(T type)
        {
            if (type != null)
            {
                m_list.Add(type);
            }
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



    }
}
