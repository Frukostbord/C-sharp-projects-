using Workout_Planner.Model;
using Workout_Planner.View_Model;

namespace Workout_Planner.View;

public partial class SchedulePage : ContentPage
{
	public SchedulePage(ViewModelSchedule vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}