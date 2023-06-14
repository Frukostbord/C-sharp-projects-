using Workout_Planner.View;
namespace Workout_Planner;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(SchedulePage), typeof(SchedulePage));
        Routing.RegisterRoute(nameof(WorkoutsPage), typeof(WorkoutsPage));
    }
}
