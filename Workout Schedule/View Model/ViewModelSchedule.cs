using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Workout_Planner.Model;
using Workout_Planner.Model.Enums;

namespace Workout_Planner.View_Model
{
    /// <summary>
    /// This class is responsible for coupling workouts with weekdays.
    /// It uses two classes to do so:
    ///     1. The WorkoutManager class is a class pertaining ALL workouts for the user
    ///     2. The ScheduleManager class is for coupling Workouts with certain weekdays
    /// </summary>

    public class ViewModelSchedule : ViewModelBase
    {

        #region Field

        private ObservableCollection<Weekdays> weekdays;
        private ObservableCollection<Workout> workoutSelectedWeekday; // Workouts for the selected day (in the picker)
        private ObservableCollection<Workout> workout; // Selected workout of all the workouts
        private WorkoutManager workoutManager = new(); // Contains all the workouts created by the user
        private ScheduleManager scheduleManager = new(); // Contains all the workouts for each day

        private IList<object> selectedWorkouts = new List<object>(); // Selected workouts by the user
        private Workout selectedWeekdayWorkout; // Selected workout for the given day in the schedule

        private Weekdays selectedWeekday; // Selected weekday in the picker

        int sets;
        int repetitions;
        int duration;
        int weight;
        #endregion

        #region Properties
        public Workout SelectedWeekdayWorkout
        {
            get { return selectedWeekdayWorkout; }
            set 
            { 
                selectedWeekdayWorkout = value;  
                OnPropertyChanged(nameof(SelectedWeekdayWorkout));
                CollectionViewScheduleItemSelected(); // Updates entry with the information
            }
        }

        public IList<object> SelectedWorkouts
        {
            get { return selectedWorkouts; }
            set { selectedWorkouts = value; OnPropertyChanged(nameof(SelectedWorkouts)); }
        }

        public ObservableCollection<Weekdays> Weekdays
        {
            get { return weekdays; }
            set { weekdays = value; 
                OnPropertyChanged(nameof(Weekdays)); 
                UpdateCollectionViewSchedule();// Updates Collectionview of the schedule
            
            }

        }

        public ObservableCollection<Workout> Workout
        {
            get { return workout; } set { workout = value; OnPropertyChanged(nameof(Workout)); }

        }

        public ObservableCollection<Workout> WorkoutSelectedWeekday
        {
            get { return workoutSelectedWeekday; }
            set { 
                workoutSelectedWeekday = value; 
                OnPropertyChanged(nameof(WorkoutSelectedWeekday));
                UpdateCollectionViewSchedule(); // Updates Collectionview of the schedule
            }

        }

        public string SelectedWeekdayText
        {
            get { return $"{selectedWeekday}'s workout"; }
        }

        public Weekdays SelectedWeekday
        {

            get { return selectedWeekday; }
            set 
            { 
                selectedWeekday= value;
                OnPropertyChanged(nameof(SelectedWeekday));
                OnPropertyChanged(nameof(SelectedWeekdayText)); // Sets text for the selected weekday
                UpdateCollectionViewSchedule();
            } 
        }

        public int Sets
        {
            get { return sets; }


            set
            {
                sets = value;
                OnPropertyChanged(nameof(Sets));
            }
        }

        public int Repetitions
        {
            get { return repetitions; }


            set
            {
                repetitions = value;
                OnPropertyChanged(nameof(Repetitions));
            }
        }

        public int Duration
        {
            get { return duration; }


            set
            {
                duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }

        public int Weight
        {
            get => weight;

            set
            {
                weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }


        #endregion

        #region Commands
        public Command AddWorkoutToScheduleCommand { get; }
        public Command EditWorkoutInScheduleCommand { get; }
        public Command DeleteWorkoutFromScheduleCommand { get; }
        public Command DeleteAllWorkoutsCommand { get; }
        #endregion

        #region Constructor
        public ViewModelSchedule()
        {
            // Sets weekdays in the picker
            Weekdays = new ObservableCollection<Weekdays>(Enum.GetValues(typeof(Weekdays)).Cast<Weekdays>());

            Workout = new ObservableCollection<Workout>(); // Selected Workout in the common pool of workouts
            WorkoutSelectedWeekday = new ObservableCollection<Workout>(); // Selected workout for given day

            // Commands
            AddWorkoutToScheduleCommand = new Command(AddWorkoutToSchedule);
            EditWorkoutInScheduleCommand = new Command(EditWorkoutInSchedule);
            DeleteWorkoutFromScheduleCommand = new Command(DeleteSelectedWorkout);
            DeleteAllWorkoutsCommand = new Command(DeleteAllWorkouts);

            // Set data from mainpage
            MessagingCenter.Subscribe<ViewModelMainPage, WorkoutManager>(this, "WorkoutManager", OnDataRetrievalWorkouts);
            MessagingCenter.Subscribe<ViewModelMainPage, ScheduleManager>(this, "ScheduleManager", OnDataRetrievalSchedule);
        }

        #endregion


        #region Data update on page opening

        /// <summary>
        /// Getting data of all the workouts.
        /// </summary>
        /// <param name="workoutManager">Common pool of workouts</param>
        private void OnDataRetrievalWorkouts(ViewModelMainPage sender, WorkoutManager workoutManager)
        {
            this.workoutManager = workoutManager;
            UpdateCollectionViewWorkout();
        }

        /// <summary>
        /// Getting data on all the workouts for each day
        /// </summary>
        /// <param name="schedule">All workouts coupled with each week day</param>
        private void OnDataRetrievalSchedule(ViewModelMainPage sender, ScheduleManager schedule)
        {
            this.scheduleManager = schedule;
            UpdateCollectionViewSchedule();
        }

        #endregion
        #region Add Workout to Schedule
        /// <summary>
        /// Iterates all the items selected by the user in the collection view of workout,
        /// and then adds them to the scheduleManager.
        /// </summary>
        private async void AddWorkoutToSchedule() 
        {
            bool ok = ControlWorkoutUnique();

            if (ok && SelectedWorkouts.Count > 0)
            {
                foreach (Workout workout in SelectedWorkouts)
                {
                    scheduleManager.Add(SelectedWeekday, workout);
                }
                UpdateCollectionViewSchedule();
                UpdateCollectionViewWorkout();
                SendDataMainPage();
               
            }

            else if(SelectedWorkouts.Count == 0)
            {
                await Shell.Current.DisplayAlert("No workouts selected!", "You have to select a workout before trying" +
                    "to add.", "OK");
            }

            else if(!ok) 
            {
                await Shell.Current.DisplayAlert("Workout already added!", "You´re trying to add a workout" +
                " that you´ve already added.", "OK");
            }
        }

        /// <summary>
        /// Controls if the selected workout(s) havn´t already been added to the selected day´s workout
        /// </summary>
        /// <returns>True if the selected Workout(s) havn´t been added, else false</returns>
        private bool ControlWorkoutUnique()
        {
            bool ok = true;
            foreach (Workout workout in SelectedWorkouts)
            {
                ok = scheduleManager.IsWorkoutUnique(SelectedWeekday, workout.Id);
                if (!ok) { break; }
            }
            return ok;
        }
        #endregion

        #region Edit workout in schedule
        /// <summary>
        /// Check to see that all Entries have valid values (numbers) and that a workout is selected for
        /// the current day. If so, updates the selected workout with the new values in the entry.
        /// </summary>
        private async void EditWorkoutInSchedule()
        {
            Workout workout;
            bool ok = ControlAllEntries();

            if (ok && SelectedWeekdayWorkout != null)
            {
                workout = SetNewEditedValues(); // Create a new instance of Workout with the new values

                // Replace the new workout object with the old
                scheduleManager.EditWorkout(SelectedWeekday,workout, SelectedWeekdayWorkout.Id); 
                
                UpdateCollectionViewSchedule(); // Refresh GUI
                ClearScheduleEntriesAndSelection(); // Clear entries (sets all values to 0)
                SendDataMainPage();
            }

            else if(SelectedWeekdayWorkout== null) 
            {
                await Shell.Current.DisplayAlert("Error!", "You have to have a " +
                "workout selected before trying to save the new changes.", "OK"); 
            }

            else if(!ok)
            {
                await Shell.Current.DisplayAlert("Error!","All inputs for Weight, Sets, Repetitions and Duration" +
                    " have to be valid positive whole numbers (0 to 9)", "OK");
            }
        }

        /// <summary>
        /// Creates new instance of Workout with given values and deep copy given values
        /// </summary>
        /// <returns>A Workout object with the given values</returns>
        private Workout SetNewEditedValues()
        {
            Workout workout = new 
                Workout((SelectedWeekdayWorkout.Name, SelectedWeekdayWorkout.Description, 
                SelectedWeekdayWorkout.WorkoutFocusList));

            workout.Duration = Duration;
            workout.Weight = Weight;
            workout.Repetitions = Repetitions;
            workout.Sets = Sets;

            return workout;
        }

        #endregion

        #region Delete workout(s) from schedule
        /// <summary>
        /// Deletes the selected workout from the selected day in the Picker. E.g Monday is selected, the
        /// selected workout from Monday will be deleted.
        /// </summary>
        private async void DeleteSelectedWorkout()
        {
            if(SelectedWeekdayWorkout != null) // null check
            {
                // Calls method in manager to delete selected workout for the selected weekday
                scheduleManager.Remove(SelectedWeekday, selectedWeekdayWorkout.Id);
                SendDataMainPage();
                ClearScheduleEntriesAndSelection();
                UpdateCollectionViewSchedule();
            }

            else
            {
                await Shell.Current.DisplayAlert("Error!", "You have to select a workout from the selected day" +
                    "before trying to remove it.", "OK");
            }
        }

        /// <summary>
        /// This method asks the user if all workouts of the selected Day should be canceled. If the user accepts, all workouts
        /// will be deleted.
        /// </summary>
        private async void DeleteAllWorkouts()
        {
            bool ok = await Shell.Current.DisplayAlert("Warning!", "You are about to delete all workouts of the selected day.\n" +
                "Are you sure you want to continue?", "Yes", "No");

            if (ok) 
            {
                scheduleManager.ClearSelectedDay(SelectedWeekday);
                UpdateCollectionViewSchedule();
                ClearScheduleEntriesAndSelection();
                SendDataMainPage();
            }


        }

        #endregion
        #region Refreshing GUI
        /// <summary>
        /// Sets all values to default and removes selection from the collectionview
        /// of all the workouts of the selected day.
        /// </summary>
        private void ClearScheduleEntriesAndSelection()
        {
            SelectedWeekdayWorkout = null;
            Sets = default;
            Weight = default;
            Duration = default;
            Repetitions = default;
        }

        /// <summary>
        /// Sets all the values in the entries to the selected workout for the selected day.
        /// </summary>
        private void CollectionViewScheduleItemSelected()
        {
            if (SelectedWeekdayWorkout != null)
            {
                Sets = selectedWeekdayWorkout.Sets;
                Repetitions = selectedWeekdayWorkout.Repetitions;
                Duration = selectedWeekdayWorkout.Duration;
                Weight = selectedWeekdayWorkout.Weight;
            }
        }

        /// <summary>
        /// Updates the collection view of all the workouts.
        /// </summary>
        private void UpdateCollectionViewWorkout()
        {
            Workout?.Clear();

            if (workoutManager.Count > 0)
            {
                for (short i = 0; i < workoutManager.Count; i++)
                {
                    Workout.Add(workoutManager.GetItem(i));
                }
            }
            
        }

        /// <summary>
        /// Updates the collectionview of all the workouts for a selected day.
        /// </summary>
        private void UpdateCollectionViewSchedule()
        {
            WorkoutSelectedWeekday?.Clear();

            // Get the workoutmanager for the selected day
            WorkoutManager workoutManager = scheduleManager.GetSelectedDayWorkouts(SelectedWeekday);

            // Iterate through each workout in the workoutmanager and add them to the collectionview
            for(short i = 0; i<workoutManager.Count; i++) 
            { 
                WorkoutSelectedWeekday.Add(workoutManager.GetItem(i));
            }
        }
        #endregion

        /// <summary>
        /// Sends data of WorkoutManager with all workouts and ScheduleManager with all workouts for each day
        /// to Main Page
        /// </summary>
        private void SendDataMainPage()
        {
            MessagingCenter.Send(this, "WorkoutManager", workoutManager);
            MessagingCenter.Send(this, "ScheduleManager", scheduleManager);

        }

        /// <summary>
        /// Controls all entries (weight, duration, sets and repetitions) if they are
        /// valid numbers
        /// </summary>
        /// <returns>True if all are valid numbers, else false</returns>
        private bool ControlAllEntries()
        {
            bool ok = false;

            if(SelectedWeekdayWorkout!= null) 
            {
                ok =
                    Sets >= 0 &&
                    Weight >= 0 &&
                    Duration >= 0 &&
                    Repetitions >= 0;

            }
            
            return ok;
        }
  
    }
}
