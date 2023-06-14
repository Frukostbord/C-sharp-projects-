using System;
using System.Windows;

namespace The_Control_Tower___Delegates_and_Events
{

    /// <summary>
    /// Contains a string message regarding the new flight information.
    /// </summary>

    public class FlightHeightEventArgs : EventArgs
    {
        string message;


        public string Message { get { return message; } }

        public FlightHeightEventArgs(string message)
        {
            this.message = message;
        }
    }
}
