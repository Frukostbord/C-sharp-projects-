using Workout_Planner.View;
using Workout_Planner.View_Model;

namespace Workout_Planner;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        // For creating main page
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<ViewModelMainPage>();

        // For creating other windows in the program
        builder.Services.AddTransient<SchedulePage>();
        builder.Services.AddTransient<ViewModelSchedule>();
        builder.Services.AddTransient<WorkoutsPage>();
        builder.Services.AddTransient<ViewModelWorkouts>();



        return builder.Build();

    }
}
