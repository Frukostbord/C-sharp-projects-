using Duplicate_finder.Model;
using Workout_Planner.Model;
using Workout_Planner.Model.Enums;

namespace Workout_Planner.Model
{/// <summary>
/// This class has a list of all the workouts.
/// It´s responsibility is to:
///     > Add, edit, delete and retreive workouts.
///     
/// It does so by inheriting methods from ListManager
/// </summary>
    public class WorkoutManager : ListManager<Workout>
    {
        /// <summary>
        /// Controls to see if the ID given is in any workout of the Class
        /// </summary>
        /// <param name="id">ID to control</param>
        /// <returns>True if the ID is in one of the workouts, else False</returns>
        public bool ControlWorkoutUnique(Guid id)
        {
            bool ok = true;
            Workout workout;
            for(short i = 0; i < Count; i++) 
            { 
                workout = GetItem(i);
                if(workout.Id== id) { ok = false; }
            }
            return ok;
        }


        /// <summary>
        /// Allows the user to delete an item by providing id (Guid).
        /// </summary>
        /// <param name="id">Guid of workout to be deletedd</param>
        public void DeleteItemByID(Guid id)
        {
            Workout workout;
            for(short i = 0; i < Count; i++) 
            {
                workout = GetItem(i);
                if (workout != null) 
                {
                    if(workout.Id == id) DeleteItemByIndex(i);
                    break;
                }
            }
        }

        /// <summary>
        /// Allows the user to edit an existing workout
        /// </summary>
        /// <param name="id">Ïd of workout to edit</param>
        /// <param name="newWorkout">New workout to replace it</param>
        public void EditItem(Guid id, Workout newWorkout) 
        {
            // Notice - deep copying didn´t allow for new values in the collectionview GUI,
            // therefore we instead replace the workout entirely in the list

            Workout oldWorkout;
            for (short i = 0; i < Count; i++)
            {
                oldWorkout = GetItem(i);

                // If the workout is found
                if (oldWorkout != null && oldWorkout.Id == id)
                {

                    newWorkout.Id = oldWorkout.Id; // Copy over ID
                    DeleteItemByIndex(i); // Delete workout
                    InsertItem(i, newWorkout); // Add new workout to same index

                    break;
                }
            }
        }

        /// <summary>
        /// Allows the user to edit an existing workout, whilst keeping information of all workouts values
        /// such as Repetitions, Weight, Duration and Sets.
        /// </summary>
        /// <param name="id">Ïd of workout to edit</param>
        /// <param name="newWorkout">New workout to replace previous one with</param>
        public void Edit(Guid id, Workout newWorkout)
        {
            // Notice - deep copying didn´t allow for new values in the collectionview GUI,
            // therefore we instead replace the workout entirely in the list

            Workout workout;
            for (short i = 0; i < Count; i++)
            {
                workout = GetItem(i);

                // If the workout is found
                if (workout != null && workout.Id == id)
                {
                    // Copy over ID & Values
                    newWorkout.Id = workout.Id; 
                    newWorkout.Sets = workout.Sets;
                    newWorkout.Weight = workout.Weight;
                    newWorkout.Duration = workout.Duration;
                    newWorkout.Repetitions = workout.Repetitions;
                    DeleteItemByIndex(i); // Delete workout
                    InsertItem(i, newWorkout); // Add new workout to same index

                    break;
                }
            }
        }

    }
}
