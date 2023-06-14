
using Workout_Planner.Model.Enums;

namespace Workout_Planner.Model
{

    /// <summary>
    /// This class is responsible for copuling workouts with weekdays.
    /// It contains a dictionary with methods for adding, deleting and editing workouts.
    /// Each key is a weekday and each value is of the class WorkoutManager.
    /// </summary>

    public class ScheduleManager
    {
        // Dictionary holding all weekdays
        private Dictionary<Weekdays, WorkoutManager> schedule = new Dictionary<Weekdays, WorkoutManager>();

        /// <summary>
        /// Adds each weekday to the dictionary upon creation
        /// </summary>
        public ScheduleManager() 
        {
            foreach (Weekdays weekday in Enum.GetValues(typeof(Weekdays)))
            {
                schedule[weekday] = new WorkoutManager();
            };

        }

        /// <summary>
        /// Used for adding a workout to the dictionary
        /// </summary>
        /// <param name="weekday">Weekday the workout should be added</param>
        /// <param name="workout">Which workout should be added</param>
        public void Add(Weekdays weekday, Workout workout)
        {
            WorkoutManager manager;

            // Checking value
            if(schedule.ContainsKey(weekday))
            {
                manager = schedule[weekday];
                manager.Add(workout);
            }

        }

        /// <summary>
        /// Removes a workout from the selected day
        /// </summary>
        /// <param name="weekday"></param>
        /// <param name="id"></param>
        public void Remove(Weekdays weekday, Guid id) 
        {
            WorkoutManager manager;

            // Checking value
            if (schedule.ContainsKey(weekday))
            {
                manager = schedule[weekday];
                manager.DeleteItemByID(id);
            }
        }

        /// <summary>
        /// Removes a workout from all the days
        /// </summary>
        /// <param name="id"></param>
        public void Remove(Guid id)
        {
            foreach(WorkoutManager manager in schedule.Values)
            {
                manager.DeleteItemByID(id);
            }
    
        }

        /// <summary>
        /// Edits the selected workout for the selected day, e.g if weekday == Monday it searches for the 
        /// workout with the given ID and replaces it in the list of workouts for that selected day.
        /// </summary>
        /// <param name="weekday">Weekday the workout takes place</param>
        /// <param name="newWorkout">New workout to replace</param>
        /// <param name="id">Id used to match workouts</param>
        public void EditWorkout(Weekdays weekday, Workout newWorkout, Guid id)
        {
            schedule[weekday].EditItem(id, newWorkout);
        }


        /// <summary>
        /// Edits the workout by id in the list by calling method in WorkoutManager that replaces the given Workout
        /// in the list of workouts of WorkoutManager.
        /// </summary>
        /// <param name="id">Id of workout to replace</param>
        /// <param name="newWorkout">New workout to replace current workout with same Id</param>
        public void EditWorkout(Guid id, Workout newWorkout)
        {

            foreach(WorkoutManager manager in schedule.Values) 
            { 
                manager.Edit(id, newWorkout);
            }

        }

        /// <summary>
        /// Clears all workouts in WorkoutManager for the selected day
        /// </summary>
        /// <param name="day">Day to clear all workouts from</param>
        public void ClearSelectedDay(Weekdays day)
        {
            WorkoutManager workoutManager = schedule[day];
            workoutManager.Clear();
        }

        /// <summary>
        /// Returns the workoutmanager of the selected day
        /// </summary>
        /// <param name="day">Weekday of workoutmanager to return</param>
        /// <returns>WorkoutManager of the selected day</returns>
        public WorkoutManager GetSelectedDayWorkouts(Weekdays day)
        {
            return schedule[day];
        }


        /// <summary>
        /// Call method in WorkoutManager for checking if the given workout is unique
        /// </summary>
        /// <param name="day">Day to control the workouts</param>
        /// <param name="id">ID of workout to control</param>
        /// <returns>True if there´s no workout with the same id (Guid)</returns>
        public bool IsWorkoutUnique(Weekdays day, Guid id)
        {
            bool unique = true;
            if (!schedule[day].ControlWorkoutUnique(id)){ unique = false; }
  
            return unique;
        }

    }
}
