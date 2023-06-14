using System;
using System.Windows;

namespace The_Control_Tower___Delegates_and_Events
{
    /// <summary>
    /// This program:
    /// 1. Allows the user to create an airplane (instance) and stores it in control tower (list of airplanes)
    /// 2. Allows the user to make a selected airplane in the listview to takeoff
    ///     Time (hours) is simulated in to seconds
    /// 3. Allows the user to alter a flight´s altitude mid flight
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {

        ControlTower tower = new ControlTower(); // Contains a list of all airplanes and other methods

        // Delegate and event, alerting ControlTower of a new flight height.


        public MainWindow()
        {
            InitializeComponent();
            InitializeMainForm();
        }

        /// <summary>
        /// Initializes buttons and subscribers for the program
        /// </summary>
        private void InitializeMainForm()
        {
            // Disabling buttons
            btnTakeOff.IsEnabled = false;
            btnFlightHeight.IsEnabled = false;

            // Adding subscribers
            tower.takeOff += UpdateAirplaneStatus;
            tower.landed += UpdateAirplaneStatus;
            tower.FlightHeightChange += UpdateAirplaneFlightHeight;
        }

        /// <summary>
        /// Refreshes GUI for the user by calling other methods
        /// </summary>
        private void RefreshGUI()
        {
            RefreshTextBoxes();
            UpdateListViewAirplanes();

        }

        /// <summary>
        /// Removes all the text written in the textboxes
        /// </summary>
        private void RefreshTextBoxes()
        {
            txtName.Text = string.Empty;
            txtFlightID.Text = string.Empty;
            txtFlightTime.Text = string.Empty;
            txtDestination.Text = string.Empty;
        }


        /// <summary>
        /// Iterates through each airplane in controltower and adds it to the listview.
        /// The properties are binded in the XAML, so each column in the listview displays correct information
        /// </summary>
        private void UpdateListViewAirplanes()
        {
            lstvAirplanes.Items.Clear();
            Airplane airplane;

            // Adding each plane by iteration
            for (int i = 0; tower.Count > i; i++)
            {
                airplane = tower.GetAt(i);
                lstvAirplanes.Items.Add(airplane);
            }

            lstvAirplanes.UpdateLayout();
        }

        /// <summary>
        /// Adds an airplane to the towercontrol list of airplanes if information has correct format.
        /// </summary>
        private void btnAddPlane_Click(object sender, RoutedEventArgs e)
        {
            // Late binding
            Airplane airplane;
            string name;
            string id;
            string destination;
            double time;

            // Controlling values
            if (ControlInputValues())
            {
                // Add values to variables to easier reading
                name = txtName.Text;
                id = txtFlightID.Text;
                destination = txtDestination.Text;
                time = double.Parse(txtFlightTime.Text);

                // Create Airplane
                airplane = new Airplane(name, id, destination, time);

                // Subscribe to events
                airplane.takeOff += tower.AirplaneStatusUpdate;
                airplane.landed += tower.AirplaneStatusUpdate;
                airplane.FlightHeightChange += tower.NewAirplaneFlightHeight;

                tower.Add(airplane);

                RefreshGUI();
            }
        }
        #region Controlling input

        /// <summary>
        /// Controls all input for creating a new airplane by calling other methods.
        /// </summary>
        /// <returns>True if all input values are valid, else false</returns>
        private bool ControlInputValues()
        {
            bool ok =
                // Methods controlling individual textbox in GUI
                ControlFlightName() &&
                ControlFlightID() &&
                ControlFlightDestination() &&
                ControlFlightTime();

            return ok;
        }

        /// <summary>
        /// Controls is string given is != null or empty
        /// </summary>
        /// <returns>True is not null or empty, else false</returns>
        private bool ControlFlightName()
        {
            bool ok = !String.IsNullOrEmpty(txtName.Text);
            return ok;
        }

        /// <summary>
        /// Controls is string given is != null or empty
        /// </summary>
        /// <returns>True is not null or empty, else false</returns>
        private bool ControlFlightID()
        {
            bool ok = !String.IsNullOrEmpty(txtFlightID.Text);
            return ok;
        }

        /// <summary>
        /// Controls is string given is != null or empty
        /// </summary>
        /// <returns>True is not null or empty, else false</returns>
        private bool ControlFlightDestination()
        {
            bool ok = !String.IsNullOrEmpty(txtDestination.Text);
            return ok;
        }

        /// <summary>
        /// Controls is string can be converted in to a double
        /// </summary>
        /// <returns>True is a double, else false</returns>
        private bool ControlFlightTime()
        {
            bool ok = double.TryParse(txtFlightTime.Text, out double holder);
            return ok;
        }

        #endregion

        /// <summary>
        /// Calls method in controltower to raise event for airplane to take off
        /// </summary>
        private void btnTakeOff_Click(object sender, RoutedEventArgs e)
        {
            int index = lstvAirplanes.SelectedIndex;
            if (index != -1)
            {
                tower.OrderTakeoff(index);
                lstvAirplanes.SelectedIndex = -1;
            }

        }

        /// <summary>
        /// Handles buttons and labels depending on selection of aircraft in listview, by calling other methods
        /// </summary>
        private void ListviewAirplanesSelectionChanged(object sender, RoutedEventArgs e)
        {
            int index = lstvAirplanes.SelectedIndex;
            Airplane airplane = tower.GetAt(index);


            ControlFlightHeightLabel(index, airplane);
            ControlTakeOffButton(index, airplane);
            ControlFlightHeightButton(index, airplane);
        }

        /// <summary>
        /// Updates label of the airplane´s current flight height
        /// </summary>
        /// <param name="index">Index selected in listview</param>
        /// <param name="airplane">Airplane object</param>
        private void ControlFlightHeightLabel(int index, Airplane airplane)
        {
            // Displays flight height on the label under listview
            if (index != -1 && airplane != null) lblCurrentHeight.Content = $"{airplane.FlightHeight} metres";

            else lblCurrentHeight.Content = string.Empty;

        }

        /// <summary>
        /// Updates take of button to be enabled or disabled
        /// </summary>
        /// <param name="index">Index selected in listview</param>
        /// <param name="airplane">Airplane object</param>
        private void ControlTakeOffButton(int index, Airplane airplane)
        {

            if (index != -1 && !airplane.InFlight) { btnTakeOff.IsEnabled = true; }
            else { btnTakeOff.IsEnabled = false; }
        }

        /// <summary>
        /// Updates flight height button to be enabled or disabled
        /// </summary>
        /// <param name="index">Index selected in listview</param>
        /// <param name="airplane">Airplane object</param>
        private void ControlFlightHeightButton(int index, Airplane airplane)
        {
            if (index != -1 && airplane.InFlight) { btnFlightHeight.IsEnabled = true; }
            else { btnFlightHeight.IsEnabled = false; }
        }

        /// <summary>
        /// Updates listbox with flight information retreived from delegate
        /// </summary>
        /// <param name="e">Flight information</param>
        private void UpdateAirplaneStatus(object? sender, AirplaneEventArgs e) => lstbFlightInfo.Items.Add($"{e.Name} {e.Message}");
        /// <summary>
        /// Updates new height of an airplane in the listbox
        /// </summary>
        /// <param name="e">String message of airplane´s changed altitude</param>
        private void UpdateAirplaneFlightHeight(object? sender, FlightHeightEventArgs e) => lstbFlightInfo.Items.Add(e.Message);

        /// <summary>
        /// Gets information from textbox and index selected in the listview of airplanes.
        /// Calls method in ControlTower with variables.
        /// </summary>

        private void btnFlightHeight_Click(object sender, RoutedEventArgs e)
        {
            string height = txtNewHeight.Text;
            int index = lstvAirplanes.SelectedIndex;

            tower.FlightHeight(index, height);

            txtNewHeight.Text = string.Empty;

        }



    }
}
