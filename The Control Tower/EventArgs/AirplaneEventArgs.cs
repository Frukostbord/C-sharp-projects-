using System;

namespace The_Control_Tower___Delegates_and_Events
{
    /// <summary>
    /// Purpose of this class is to relay information of an airplane through events.
    /// </summary>

    public class AirplaneEventArgs : EventArgs
    {
        private string message;
        private string name;

        public string Name { get { return name; } set { if (!String.IsNullOrEmpty(value)) { name = value; } } }
        public string Message { get { return message; } set { if (String.IsNullOrEmpty(value)) { message = value; } } }

        public AirplaneEventArgs(string name, string message)
        {
            this.name = name;
            this.message = message;
        }

    }
}
