using Duplicate_finder.ViewModel;

namespace Duplicate_finder;

/// <summary>
/// Creating bindings between the View and View Model
/// </summary>

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

            })
            ;

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<ViewModelBase>();

        return builder.Build();
    }
}
