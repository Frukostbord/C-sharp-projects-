using System.Collections.ObjectModel;
using System.Reflection;
using Workout_Planner.Model;
using Workout_Planner.Model.Enums;


namespace Workout_Planner.View_Model
{
    /// <summary>
    /// This is the ViewModel for the WorkoutsPage. 
    /// It´s main purpose is to allow the user to:
    ///  > Add, edit and delete workouts
    /// The Model contains all the information of the workouts: Workoutmanager and Workout
    /// </summary>
    public class ViewModelWorkouts : ViewModelBase

    {
        #region Field


        private WorkoutManager workoutManager = new();
        private ScheduleManager scheduleManager = new();

        private ObservableCollection<Workout> workout; // Workout to display
        private Workout selectedWorkout; // Selected workout by user

        // Name, description and focus of workout
        private string name = "Name";
        private string description = "Description";

        // Checkboxes selection
        private bool strength;
        private bool cardio;
        private bool flexibility;
        private bool balance;
        private bool coordination;
        #endregion


        #region Properties

  

        public Workout SelectedWorkout
        {
            get { return selectedWorkout; }
            set { 
                selectedWorkout = value;
                OnPropertyChanged(nameof(SelectedWorkout));
                
                // Updates the Entry for the user, so it reflects the information selected by the user
                ClearGUIInput();
                CollectionViewItemSelected();
            }

        }
        public ObservableCollection<Workout> Workout
        {
            get { return workout; }
            set
            {
                workout = value;
                OnPropertyChanged(nameof(Workout));
            }
        }

        public WorkoutManager WorkoutManager
        {
            get { return workoutManager; }
            set 
            { 
                workoutManager = value;
                OnPropertyChanged(nameof(WorkoutManager));
            }

        }

        public string Name
        { get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                    description = value;
                    OnPropertyChanged(nameof(Description));
            }
        }

        public bool Strength
        {
            get => strength;

            set
            {
                if (strength != value)
                {
                    strength = value;
                    OnPropertyChanged(nameof(Strength));
                }

            }

        }

        public bool Cardio
        {
            get => cardio;

            set
            {
                if (cardio != value)
                {
                    cardio = value;
                    OnPropertyChanged(nameof(Cardio));
                }
            }

        }
        public bool Flexibility
        {
            get => flexibility;

            set
            {
                if (flexibility != value)
                {
                    flexibility = value;
                    OnPropertyChanged(nameof(Flexibility));
                }
            }

        }
        public bool Balance
        {
            get => balance;

            set
            {
                if (balance != value)
                {
                    balance = value;
                    OnPropertyChanged(nameof(Balance));
                }
            }

        }
        public bool Coordination
        {
            get => coordination;

            set
            {
                if (coordination != value)
                {
                    coordination = value;
                    OnPropertyChanged(nameof(Coordination));
                }
            }

        }

        #endregion

        #region Constructor
        public ViewModelWorkouts() 
        {
            // Sets the workoutmanager to the retreived one
            MessagingCenter.Subscribe<ViewModelMainPage, WorkoutManager>(this, "WorkoutManager",OnDataRetrievalWorkouts);
            MessagingCenter.Subscribe<ViewModelMainPage, ScheduleManager>(this, "ScheduleManager", OnDataRetrievalSchedule);

            // Commands and information to be displayed
            Workout = new ObservableCollection<Workout>();
            AddWorkoutCommand = new Command(AddWorkout);
            EditWorkoutCommand = new Command(EditWorkout);
            DeleteWorkoutCommand = new Command(DeleteWorkout);
            DeleteAllWorkoutCommand = new Command(DeleteAllWorkouts);

        }
        #endregion

        #region Commands
        // Commands on different button presses
        public Command AddWorkoutCommand { get; }
        public Command EditWorkoutCommand { get; }
        public Command DeleteWorkoutCommand { get; }
        public Command DeleteAllWorkoutCommand { get; }

        #endregion

        /// <summary>
        /// This method is called when the content page is loaded. It replaces the content page´s workout manager
        /// with the given one.
        /// </summary>
        /// <param name="workoutManager">WorkoutManager to replace with the current one</param>
        private void OnDataRetrievalWorkouts(ViewModelMainPage sender, WorkoutManager workoutManager)
        {
            this.workoutManager = workoutManager;
            UpdateCollectionView();
        }

        /// <summary>
        /// Sets the current scheduleManager to the given, with updated values
        /// </summary>
        /// <param name="schedule"></param>
        private void OnDataRetrievalSchedule(ViewModelMainPage sender, ScheduleManager schedule)
        {
            scheduleManager = schedule;
        }

        #region Adding workout
        /// <summary>
        /// Adds a workout to WorkoutManager.
        /// </summary>
        private async void AddWorkout()
        {
            Workout workout;
            List<WorkoutFocus> workoutFocus;

            // Values checks
            if (CheckNameAndDescription() && CheckWorkoutFociSelected())
            {
                // Get data, creates workout and adds it
                workoutFocus = GetWorkoutFoci();
                workout = CreateWorkout(workoutFocus);
                workoutManager.Add(workout);

                // Refresh GUI
                ClearGUIInput();
                UpdateCollectionView();

                // Send data back
                SendDataMainPage();
            }

            else
            {
                await Shell.Current.DisplayAlert("Wrongful input", "You have to write a Name, Description and atleast select one\n" +
                    "focus area of the workout you´re trying to add.", "OK");

            }

        }

        #endregion

        #region Editing workout
        /// <summary>
        /// Edits a workout selected by the user with the newly given information in the checkboxes
        /// and Entry.
        /// </summary>
        private async void EditWorkout()
        {
            if (SelectedWorkout != null && CheckNameAndDescription() && CheckWorkoutFociSelected())
            {
                List<WorkoutFocus> workoutFoci = GetWorkoutFoci();
                Workout workout = CreateWorkout(workoutFoci);

                // Edit the workouts in the common pool of workouts and for all the weekday
                scheduleManager.EditWorkout(SelectedWorkout.Id, workout);
                workoutManager.EditItem(SelectedWorkout.Id, workout);
                
                ClearGUIInput();
                UpdateCollectionView();

                // Send data back
                SendDataMainPage();

            }

            else
                await Shell.Current.DisplayAlert("Wrongful input", "You have to write a Name, Description and atleast select one\n" +
                  "focus area of the workout you´re trying to edit. As well as selecting an item to edit.", "OK");
        }

        #endregion

        #region Deleting workout

        /// <summary>
        /// Deletes the selected workout by the user in WorkoutManager.
        /// </summary>
        private async void DeleteWorkout()
        {
            if (SelectedWorkout != null)
            {
                workoutManager.DeleteItemByID(SelectedWorkout.Id);
                scheduleManager.Remove(SelectedWorkout.Id);

                // Update GUI
                ClearGUIInput();
                UpdateCollectionView();

                // Send data back
                SendDataMainPage();
            }

            else
                await Shell.Current.DisplayAlert("Error", "You have to select a workout before trying to delete it.", "OK");

        }

        /// <summary>
        /// Deletes ALL workouts in WorkoutManager
        /// </summary>
        private async void DeleteAllWorkouts()
        {
            bool ok = await Application.Current.MainPage.DisplayAlert("Warning", "You will lose all your workouts!\nDo you wish to proceed?",
                "Yes", "No");

            if (ok) 
            { 
                workoutManager.Clear();
                scheduleManager = new();

                // Updates GUI
                ClearGUIInput();
                UpdateCollectionView();

                // Send data back
                SendDataMainPage();
            }
        }

        #endregion

        #region GUI
        /// <summary>
        /// Updating Entries and checkboxes to reflect the selected workout from the user.
        /// </summary>
        public void CollectionViewItemSelected()
        {
            if (SelectedWorkout != null && workoutManager.Count > 0)
            {
                Name = selectedWorkout.Name;
                Description = selectedWorkout.Description;
                SetCheckboxValues(selectedWorkout);
            }

        }


        /// <summary>
        /// Sets all checkboxes to false and sets the entry boxes to their default values
        /// </summary>
        private void ClearGUIInput()
        {
            Name = "Name";
            Description = "Description";

            Strength = false; 
            Balance = false; 
            Coordination = false; 
            Flexibility = false;
            Cardio = false;
        }

        /// <summary>
        /// 1. Clears the entire collectionview
        /// 2. Iterates through WorkoutManager and adds the Workout(s) to be displayed
        ///     in the collectionview.
        /// </summary>
        private void UpdateCollectionView()
        {
            Workout?.Clear();

            if (workoutManager.Count > 0) 
            { 
                for(short i = 0; i < workoutManager.Count; i++) 
                {
                    Workout.Add(workoutManager.GetItem(i));
                }
            }
        }

        /// <summary>
        /// Sets the checkboxes in the contentpage to reflect the WorkoutFocus of the workout selected
        /// by the user.
        /// </summary>
        /// <param name="workout">Workout´s Workoutfocus to be displayed in the checkboxes</param>
        private void SetCheckboxValues(Workout workout)
        {
            // Iterating through each workoutfocus
            foreach (WorkoutFocus workoutFocus in workout.WorkoutFocusList)
            {
                if (workoutFocus == WorkoutFocus.Strength) { Strength = true; }
                else if (workoutFocus == WorkoutFocus.Flexibility) { Flexibility = true; }
                else if (workoutFocus == WorkoutFocus.Cardio) { Cardio = true; }
                else if (workoutFocus == WorkoutFocus.Coordination) { Coordination = true; }
                else if (workoutFocus == WorkoutFocus.Balance) { Balance = true; }
            }

        }
        #endregion

        #region Controlling DATA

        /// <summary>
        /// Controls that the Entries has been filled with text
        /// </summary>
        /// <returns>True if both have text in them, else false</returns>
        private bool CheckNameAndDescription()
        {
            bool ok = !String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Description);
            return ok;
        }

        /// <summary>
        /// Lambda function of checking if atleast one checkbox has been ticked
        /// </summary>
        /// <returns>True if atleast one checkbox has been checked, else false</returns>
        private bool CheckWorkoutFociSelected() => Strength || Cardio || Flexibility || Balance || Coordination;

        #endregion

        /// <summary>
        /// Creates a Workout object
        /// </summary>
        /// <param name="workoutFoci">List of workout focuses</param>
        /// <returns>A workout object</returns>
        private Workout CreateWorkout(List<WorkoutFocus> workoutFoci)
        {
            var workoutInfo = (Name, Description, workoutFoci);
            Workout workout = new(workoutInfo);

            return workout;
        }



        /// <summary>
        /// Returns a list of WorkoutFocuses from the checkboxes selected by the user.
        /// </summary>
        /// <returns>A list of WorkoutFocus (enum)</returns>
        private List<WorkoutFocus> GetWorkoutFoci()
        {
            List<WorkoutFocus> workoutFocusList = new();

            // All workoutfocuses
            bool[] selectedWorkoutFoci = { Strength, Cardio, Flexibility, Balance, Coordination };

            for (short i = 0; i < selectedWorkoutFoci.Length; i++)
            {
                WorkoutFocus workoutFocus;

                // Adding the workoutfocus if it has been checked.
                if (selectedWorkoutFoci[i])
                {
                    workoutFocus = (WorkoutFocus)i;
                    workoutFocusList.Add(workoutFocus);
                }
            }

            return workoutFocusList;

        }

        /// <summary>
        /// Sends data to the MainPage with all updated values in WorkoutManager and ScheduleManager.
        /// </summary>
        private void SendDataMainPage()
        {
            MessagingCenter.Send(this, "WorkoutManager", workoutManager);
            MessagingCenter.Send(this, "ScheduleManager", scheduleManager);

        }
    }
}
