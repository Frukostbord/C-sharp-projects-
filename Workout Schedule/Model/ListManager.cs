using Duplicate_finder.Interface;

namespace Duplicate_finder.Model
{

    /// <summary>
    /// List class inheriting from interface IListManager.
    /// Base class that can be used for classes that want to have a list of generic items.
    /// </summary>
    /// <typeparam name="T">Generic type T</typeparam>
    public class ListManager<T> : IListManager<T>
    {
        /// <summary>
        /// Creates new list
        /// </summary>
        private List<T> f_list = new List<T>();
        
        /// <summary>
        /// Number of items in list
        /// </summary>
        public int Count { get { return f_list.Count; } }
        
        /// <summary>
        /// Adds item of type T to f_list
        /// </summary>
        /// <param name="item">Item to add</param>
        public void Add(T item)
        {
            if (item != null) f_list.Add(item);
        }

        /// <summary>
        /// Adds List of generic type to the class list.
        /// </summary>
        /// <param name="list">List of T items</param>
        public void Add(List<T> list) 
        { 
            if(list != null && list.Count>0)
            {
                foreach(var T in list) f_list.Add(T);
            }
        }

        /// <summary>
        /// Inserts T item at given index
        /// </summary>
        /// <param name="index">Index to insert</param>
        /// <param name="item">T item to insert</param>
        public void InsertItem(int index, T item) 
        { 
            if(CheckIndex(index))
                f_list.Insert(index, item);
        }

        /// <summary>
        /// Clears entire list
        /// </summary>
        public void Clear()
        {
            f_list = new List<T> { };
        }

        /// <summary>
        /// Gets item T at given index
        /// </summary>
        /// <param name="index">Index to get item T from</param>
        /// <returns>Returns T type item</returns>
        public T GetItem(int index)
        {
            if (CheckIndex(index)) return f_list[index];
            return default;
        }

        /// <summary>
        /// Checks if integer value given is valid index in f_list
        /// </summary>
        /// <param name="index">Index to control</param>
        /// <returns>True if valid, else false</returns>
        public bool CheckIndex(int index)
        {
            if (index > f_list.Count || 0 > index) return false;
            return true;
        }

        /// <summary>
        /// Deletes an item at a given index
        /// </summary>
        /// <param name="index">Item at given index to delete</param>
        public void DeleteItemByIndex(int index)
        {
            if(CheckIndex(index))
            {
                f_list.RemoveAt(index);
            }

        }

    }
}
