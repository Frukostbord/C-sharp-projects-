using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Workout_Planner.Model;
using Workout_Planner.Model.Enums;
using Workout_Planner.View;

namespace Workout_Planner.View_Model
{
    /// <summary>
    /// This is the first page of the application.
    /// It allows the user to:
    ///     > Get an overview of the workouts for each day by selecting the weekday on the Picker
    ///     > To navigate to the Workout and Workout Schedule page
    ///         * Workout page:
    ///             ** The workout page is responsible for editing, adding and deleting workouts
    ///             ** All information is held by ListManager.
    ///         * Workout Schedule page:
    ///             ** This page is responsible for adding workouts to certain days, e.g Adding Bicep curls to Monday and Jogging to Tuesday.
    ///             ** All information is held by DictionaryManager.
    /// </summary>
    public class ViewModelMainPage : ViewModelBase
    {

        #region Field

        // Fields for manipulating the picture of the dumbell
        private double opacity;
        private double scale;
        private double rotation;

        private Weekdays selectedWeekday; // Selected Weekday in the Picker
        private ObservableCollection<Weekdays> weekday; // Weekdays displayed in the Picker
        private ObservableCollection<Workout> workout; // Workouts displayed in the Collectionview

        private ScheduleManager scheduleManager = new(); // Holds workouts for all the days

        private WorkoutManager workoutManager = TestValuesWorkouts(); // Holds all different types of workouts

        #endregion

        #region Properties

        public double Opacity
        {
            get { return opacity; }
            set
            {
                opacity = value;
                OnPropertyChanged(nameof(Opacity));
            }
        }

        public double Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                OnPropertyChanged(nameof(Scale));
            }
        }


        public double Rotation
        {
            get { return rotation; }
            set
            {
                rotation = value;
                OnPropertyChanged(nameof(Rotation));
            }
        }


        public Weekdays SelectedWeekday
        {
            get { return selectedWeekday; }
            set { selectedWeekday = value; 
                OnPropertyChanged(nameof(SelectedWeekday));
                UpdateCollectionView();
            }
        }

        public ObservableCollection<Weekdays> Weekday
        {
            get => weekday;
            set
            {
                weekday= value;
                OnPropertyChanged(nameof(Weekday));
                
            }

        }

        public ObservableCollection<Workout> Workout
        {
            get => workout;
            set
            {
                workout= value;
                OnPropertyChanged(nameof(Workout));
            }

        }

        #endregion
        #region Constructor
        public ViewModelMainPage()
        {
            // Getting DATA from other content pages
            MessagingCenter.Subscribe<ViewModelWorkouts, WorkoutManager>(this, "WorkoutManager", SetDataWorkoutPageWorkouts);
            MessagingCenter.Subscribe<ViewModelWorkouts, ScheduleManager>(this, "ScheduleManager", SetDataWorkoutPageSchedule);
            MessagingCenter.Subscribe<ViewModelSchedule, WorkoutManager>(this, "WorkoutManager", SetDataSchedulePageWorkouts);
            MessagingCenter.Subscribe<ViewModelSchedule, ScheduleManager>(this, "ScheduleManager", SetDataSchedulePageSchedule);


            // Set Picker with Weekdays
            Weekday = new ObservableCollection<Weekdays>(Enum.GetValues(typeof(Weekdays)).Cast<Weekdays>());

            Workout = new ObservableCollection<Workout>();

            // Buttons commands
            WorkoutSchedulePageCommand = new(async () => await GoToWorkoutSchedulePage());
            WorkoutPageCommand = new(async () => await GoToWorkoutsPage());
            ExitCommand = new Command(Exit);
        }
        #endregion
        #region Go to Schedule page

        public Command WorkoutSchedulePageCommand { get; }

        /// <summary>
        /// Changes content page to Workout Schedule page, which allows the user to couple workouts with different weekdays
        /// </summary>

        async Task GoToWorkoutSchedulePage()
        {
            await Shell.Current.GoToAsync(nameof(SchedulePage));
            MessagingCenter.Send(this, "WorkoutManager", workoutManager);
            MessagingCenter.Send(this, "ScheduleManager", scheduleManager);
        }

        #endregion
        #region Go to Workouts page

        public Command WorkoutPageCommand { get; }

        /// <summary>
        /// Changes contentpage to Workout´s page, which allows the user to edit, delete and add workouts to the common
        /// pool of workouts.
        /// </summary>
        private async Task GoToWorkoutsPage()
        {
            await Shell.Current.GoToAsync(nameof(WorkoutsPage));
            MessagingCenter.Send(this, "WorkoutManager", workoutManager);
            MessagingCenter.Send(this, "ScheduleManager", scheduleManager);
        }

        #endregion

        #region Exit button
        public Command ExitCommand { get; }

        /// <summary>
        /// Asks the user to quit the application. If "Yes" is pressed, exits the application.
        /// </summary>
        protected async void Exit()
        {
            bool ok = await Application.Current.MainPage.DisplayAlert("Confirmation needed",
                    "Are you sure you want to exit the application?", "Yes", "No");

            if (ok) { Environment.Exit(0); }


        }
        #endregion

        #region Retreived data
        /// <summary>
        /// Retreives data for the common pool of workouts from the Workout contentpage
        /// </summary>
        /// <param name="workouts">Workouts to replace the current pool of workouts</param>
        private void SetDataWorkoutPageWorkouts(ViewModelWorkouts sender, WorkoutManager workouts)
        {
            workoutManager = workouts;

        }

        /// <summary>
        /// Retreives data for the schedule of all workouts from the Workout contentpage
        /// </summary>
        /// <param name="schedule">Schedule to replace the schedule of workouts</param>
        private void SetDataWorkoutPageSchedule(ViewModelWorkouts sender, ScheduleManager schedule)
        {
            scheduleManager = schedule;
            UpdateCollectionView();
        }

        ///<summary>
        /// Retreives data for the common pool of workouts from the Schedule contentpage
        /// </summary>
        /// <param name="workouts">Workouts to replace the current pool of workouts</param>
        private void SetDataSchedulePageWorkouts(ViewModelSchedule sender, WorkoutManager workouts)
        {
            workoutManager = workouts;

        }

        /// <summary>
        /// Retreives data for the schedule of all workouts from the Schedule contentpage
        /// </summary>
        /// <param name="schedule">Schedule to replace the schedule of workouts</param>
        private void SetDataSchedulePageSchedule(ViewModelSchedule sender, ScheduleManager schedule)
        {
            scheduleManager = schedule;
            UpdateCollectionView();
        }
        #endregion

        #region Test values

        /// <summary>
        /// Test values added to the common pool of workouts
        /// </summary>
        /// <returns>A object of WorkoutManager with test values</returns>
        private static WorkoutManager TestValuesWorkouts()
        {
            WorkoutManager workoutManager = new WorkoutManager();
            List<Workout> workouts = new List<Workout>()
            {
                {new Workout(("Bicep curl", "Regular Bicep curl", new List<WorkoutFocus>(){WorkoutFocus.Strength})) },
                {new Workout(("Push up", "Regular push up", new List<WorkoutFocus>(){WorkoutFocus.Strength})) },
                {new Workout(("Power yoga", "Yoga combinded with strength training. Excellent for allround body strength", 
                new List<WorkoutFocus>(){WorkoutFocus.Strength, WorkoutFocus.Flexibility})) },
                {new Workout(("Jogging", "Basic jogging. Remember to stretch before and after!", new List<WorkoutFocus>(){WorkoutFocus.Cardio})) },
                {new Workout(("Jumping Jacks", "Good warmup exercise that focuses on range of motion and endurance.", new List<WorkoutFocus>(){WorkoutFocus.Cardio, WorkoutFocus.Strength})) },
                {new Workout(("Medi-yoga", "Good for relaxation and flexibility. Focus on breathing and relaxation.", new List<WorkoutFocus>(){WorkoutFocus.Flexibility, WorkoutFocus.Balance})) },
                {new Workout(("Bench press", "The king of all chest exercises. Retract the Scapula get full range of motion.", new List<WorkoutFocus>(){WorkoutFocus.Strength})) },
                {new Workout(("Pull ups", "Puff your chest out, get your chin above the bar and squeeze those lats!", new List<WorkoutFocus>(){WorkoutFocus.Strength})) },
                {new Workout(("Shadow boxing", "Shadow boxing is a excellent workout to get a feeling how agile you are." +
                "Remember to be light on your feet and keep your guard up!", new List<WorkoutFocus>(){WorkoutFocus.Cardio, WorkoutFocus.Coordination})) },
            };

            foreach(var workout in workouts) { workoutManager.Add(workout); }
            return workoutManager;
        }
        #endregion

        #region Refresh GUI

        /// <summary>
        /// Refreshes the Collectionview
        /// </summary>
        private void UpdateCollectionView()
        {
            Workout?.Clear(); // Clear all previous data

            WorkoutManager manager = scheduleManager.GetSelectedDayWorkouts(SelectedWeekday);

            for(short i = 0; i < manager.Count; i++) 
            { 
                Workout.Add(manager.GetItem(i));
            }
            
        }

        #endregion
    }
}
