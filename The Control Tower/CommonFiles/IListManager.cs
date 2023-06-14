namespace The_Control_Tower___Delegates_and_Events
{
    /// <summary>
    /// Contains basic blueprints of manipulating generic object in a list by methods, for a class to inherit.
    /// </summary>
    /// <typeparam name="T">T type</typeparam>
    internal interface IListManager<T>
    {
        int Count { get; } // Retreives the number of objects in the list

        void Add(T type); // Allows addition of object to list
        bool ChangeAt(T type, int index); // Allows changing of object at index x, for a new object
        bool CheckIndex(int index); // Allows controlling of index, if it´s within range
        void DeleteAll(); // Deletion of all objects in list
        bool DeleteAt(int index); // Delete Object at given index
        T GetAt(int index); // Get object at given index

    }
}
