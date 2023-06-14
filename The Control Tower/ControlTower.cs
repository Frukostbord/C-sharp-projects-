using System;

namespace The_Control_Tower___Delegates_and_Events
{
    /// <summary>
    /// This class contains a list of instance of airplane´s
    /// It controls, through delegate and events, which airplanes are to depart and relays information when
    /// an airplane has landed.
    /// </summary>
    internal class ControlTower : ListManager<Airplane>
    {

        public EventHandler<AirplaneEventArgs>? landed; // Eventhandler for when an airplane lands
        public EventHandler<AirplaneEventArgs>? takeOff; // Eventhandler for when an airplane takes off
        public delegate void FlightHeightEventHandler(object? source, FlightHeightEventArgs e); // Delegate holding string message ("e")
        public event FlightHeightEventHandler? FlightHeightChange; 


        /// <summary>
        /// Invokes an event and relays information about the airplane further through AirplaneEventArgs.
        /// </summary>
        /// <param name="e">Information about the airplane</param>
        public void AirplaneStatusUpdate(object? sender, AirplaneEventArgs e) => takeOff?.Invoke(sender, e);


        /// <summary>
        /// Invokes an event of a new flight height saved in FlightHeightEventArgs and relays it further.
        /// </summary>
        /// <param name="e">Instance of FlightHeightEventArgs containing string message of changed flight height</param>
        public void NewAirplaneFlightHeight(object? sender, FlightHeightEventArgs e) => FlightHeightChange?.Invoke(sender, e);

        /// <summary>
        /// Orders takeoff of an airplane by calling a method in the airplane, which in turn raises (invokes) an event.
        /// </summary>
        /// <param name="index">Index of airplane to take off</param>
        public void OrderTakeoff(int index)
        {
            Airplane airplane;

            // Checking if index is valid
            if (ControlIndex(index))
            {
                airplane = GetAt(index);

                // Raises an event if airplane isn´t in flight
                if (!airplane.InFlight) airplane?.OnTakeOff();
            }
        }

        /// <summary>
        /// Checks if the index given is valid. If it is, gets instance of airplane in a list of objects and calls method in
        /// the instance of airplane.
        /// </summary>
        public void FlightHeight(int index, string height)
        {
            Airplane airplane;

            if(ControlIndex(index))
            {
                airplane= GetAt(index);
                airplane?.ControlFlightHeight(height);
            }


        }


        /// <summary>
        /// Controls to see if an integer has a valid value ( 0 or above and less than number of items in the list)
        /// </summary>
        /// <param name="index">Index given as an integer to control</param>
        /// <returns>True if index is valid, else false</returns>
        private bool ControlIndex(int index)
        {
            if (index >= 0 && Count > index) return true;
            return false;
        }



    }
}
