using Workout_Planner.View_Model;

namespace Workout_Planner.View;

public partial class WorkoutsPage : ContentPage
{
	public WorkoutsPage(ViewModelWorkouts vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

}