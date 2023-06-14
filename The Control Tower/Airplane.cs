using System;
using System.Windows.Threading;

namespace The_Control_Tower___Delegates_and_Events
{
    /// <summary>
    /// This class is responsible for all the information and methods of an airplane.
    /// The main functions are:
    /// 1. Allow the user to take off and land the airplane
    ///     Time (hours by the user) is measured in seconds, e.g a flight of 2 hours takes 2 seconds
    /// 2. Uses events and delegates to inform decoupled classes of events of the airplane (take off and landing)
    /// </summary>

    internal class Airplane
    {
        // Field

        public EventHandler<AirplaneEventArgs>? landed;
        public EventHandler<AirplaneEventArgs>? takeOff;
        public delegate void FlightHeightEventHandler(object? source, FlightHeightEventArgs e);
        public event FlightHeightEventHandler? FlightHeightChange;

        private bool inFlight; // If it´s in flight
        private string id; // Flight ID
        private string name;
        private string destination;
        private double time;
        private int flightHeight; // Current altitude
        private TimeOnly depatureTime;
        DispatcherTimer? dispatchTimer; // Counts ticks (1 tick = 1 second)


        // Constructor
        public Airplane(string name, string id, string destination, double time)
        {
            this.name = name;
            this.id = id;
            flightHeight = 0;
            this.destination = destination;
            this.time = time;
            inFlight = false;


        }

        // Contains properties and checks for each value, e.g control if an integer given as a value is an integer
        #region Properties

        public int FlightHeight
        {
            get { return flightHeight; }
            set
            {
                bool ok = int.TryParse(value.ToString(), out int holder);
                if (ok) { flightHeight = value; }
            }
        }

        public bool InFlight
        {
            get { return inFlight; }
            set
            {
                if (value.GetType() == typeof(bool)) { inFlight = value; }
            }
        }
        public string Destination { get { return destination; } set { if (String.IsNullOrEmpty(value)) { destination = value; } } }
        public string Id { get { return id; } set { if (String.IsNullOrEmpty(value)) { id = value; } } }
        public double Time
        {
            get { return time; }
            set
            {
                if (value.GetType() == typeof(double)) { time = value; }
            }
        }
        public TimeOnly LocalTime
        {
            get { return depatureTime; }
            set
            {
                bool ok = TimeOnly.TryParse(value.ToString(), out TimeOnly holder);
                if (ok) { depatureTime = value; }
            }
        }
        public string Name { get { return name; } set { if (String.IsNullOrEmpty(value)) { name = value; } } }

        #endregion

        /// <summary>
        /// Checks each tick if enough flight time has gone, which is:
        /// different of current time from departure time in seconds (e.g current time 16:00:05 - departure time 16:00:00).
        /// If enough time has passed, call method to make the airplane land.
        /// </summary>

        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);

            // Check how many seconds has gone from departure
            double timeLeft = (currentTime - depatureTime).TotalSeconds;

            // Sufficient time has passed, make the airplane land
            if (timeLeft >= time) OnLanding();
        }

        /// <summary>
        /// Randomizes a integer number
        /// </summary>
        /// <returns>Random integer between 150 and 25000</returns>
        private int RandomHeight()
        {
            Random random = new Random();
            int height = random.Next(150, 25000);

            return height;
        }

        /// <summary>
        /// This method is responsible for handling the situation of when the airplane lans by doing the following:
        /// 1. Sets depature time to now
        /// 2. Sets destination to "Home"
        /// 3. Sets InFlight to false
        /// 4. Raises event with airplane information
        /// 5. Stops timer
        /// </summary>
        public void OnLanding()
        {
            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);

            flightHeight = 0;

            string name = $"Flight {this.name} (Flight ID: {id})";
            string message = $"has landed at {destination} at {currentTime:hh:mm:ss}";

            destination = "Home";

            InFlight = false;
            landed?.Invoke(this, new AirplaneEventArgs(name, message));

            StopTimer();
        }

        /// <summary>
        /// This method is responsible for handling the situation of when the airplane takes off by doing the following:
        /// 1. Sets depature time to now
        /// 2. Sets a random altitude
        /// 3. Sets InFlight to true
        /// 4. Raises event with airplane information
        /// 5. Starts timer
        /// </summary>
        public void OnTakeOff()
        {
            depatureTime = TimeOnly.FromDateTime(DateTime.Now);

            flightHeight = RandomHeight();

            string name = $"Flight {this.name} (Flight ID: {id})";
            string message = $"has departed for {destination} at {depatureTime:hh:mm:ss}";

            InFlight = true;
            takeOff?.Invoke(this, new AirplaneEventArgs(name, message));

            SetupTimer();
        }

        /// <summary>
        /// Timer according to assignment.
        /// Timespan (h,m,s), so each tick is one second.
        /// </summary>
        public void SetupTimer()
        {
            dispatchTimer = new DispatcherTimer();
            dispatchTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatchTimer.Interval = new TimeSpan(0, 0, 1);
            dispatchTimer.Start();
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void StopTimer()
        {
            dispatchTimer?.Stop();
        }


        public void ControlFlightHeight(string strHeight)
        {
            int height;
            bool ok = int.TryParse(strHeight, out height);

            // Random minimum and maximum value (i don´t know actual minimum and maximum flight height)
            if (ok && height >= 150 && height <= 25000 && height != flightHeight) 
            {
                OnNewFlightHeight(height);
            }

        }

        /// <summary>
        /// Raises an event and passes FlightHeightEventArgs as information
        /// </summary>
        /// <param name="height">New flight height</param>
        protected void OnNewFlightHeight(int height)
        {
            // String message to be sent
            string message = $"Flight {name} (Flight ID: {id}) changed altitude from {FlightHeight} metres to {height} metres";

            FlightHeightChange?.Invoke(this, new FlightHeightEventArgs(message));

            FlightHeight = height; // Sets new altitude
        }

    }
}
