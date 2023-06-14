namespace Duplicate_finder.Interface
{
    /// <summary>
    /// Interface blueprint from a list class
    /// </summary>
    /// <typeparam name="T">Generic type T</typeparam>
    public interface IListManager<T>
    {
        void Add(List<T> item);
        void Add(T item);
        void Clear();
        T GetItem(int index);
        bool CheckIndex(int index);

    }
}
