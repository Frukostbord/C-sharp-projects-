using Workout_Planner.Model.Enums;

namespace Workout_Planner.Model
{

    /// <summary>
    /// This class represents all information of a workout.
    /// It contains information of:
    ///     > How a workout if performed
    ///     > Sets, reps, duration etc
    ///     > What the exercise focuses on
    ///     > Name of the workout
    /// </summary>
    public class Workout
    {

        #region Constructors
        public Workout() { }
        public Workout((string name, string description, List<WorkoutFocus> workoutFoci) workoutInfo)
        {
            Name = workoutInfo.name;
            Description = workoutInfo.description;
            WorkoutFocusList = workoutInfo.workoutFoci;

            Id = Guid.NewGuid();
        }
        #endregion 

        // Properties with information relevant for the workout
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public int Duration { get; set; }
        public int Weight { get; set; }
        public List<WorkoutFocus> WorkoutFocusList { get; set; }
        public string WorkoutFoci // Returns a string of the workout focuses
        {
            get 
            { 
                return String.Join(", ", WorkoutFocusList);
            }
        }

    }
}
