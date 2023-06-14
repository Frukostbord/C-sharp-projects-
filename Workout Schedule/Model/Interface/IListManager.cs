namespace Duplicate_finder.Interface
{
    /// <summary>
    /// Interface blueprint from a list class
    /// </summary>
    /// <typeparam name="T">Generic type T</typeparam>
    public interface IListManager<T>
    {
        void Add(T item); // Adds T item
        public void Add(List<T> list); // Adds List<T> items
        void Clear(); // Clears items
        T GetItem(int index); // Get item from index
        bool CheckIndex(int index); // Control if index is valid
        void DeleteItemByIndex(int index); // Delete item by index
        void InsertItem(int index, T item); // Insert T item at index

    }
}
