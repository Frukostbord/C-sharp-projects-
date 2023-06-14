using Duplicate_finder.Interface;

namespace Duplicate_finder.Model
{

    /// <summary>
    /// List class inheriting from interface IListManager.
    /// Base class that can be used for classes that want to have a list of generic items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
        /// Adds List of type T to f_list
        /// </summary>
        /// <param name="items">Items to add</param>
        public void Add(List<T> items)
        {
            if (items != null) foreach (T t in items) f_list.Add(t);
        }
        /// <summary>
        /// Adds item of type T to f_list
        /// </summary>
        /// <param name="item">Item to add</param>
        public void Add(T item)
        {
            if (item != null) f_list.Add(item);
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


    }
}
