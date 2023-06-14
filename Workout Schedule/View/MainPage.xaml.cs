using Workout_Planner.View_Model;
using System.Timers;
using System.Runtime.CompilerServices;

namespace Workout_Planner;

public partial class MainPage : ContentPage
{

	public MainPage(ViewModelMainPage vm)
	{
		InitializeComponent();
		BindingContext = vm;

        _ = DumbbellAnimation(vm);
    
    }

    private async Task DumbbellAnimation(ViewModelMainPage vm)
    {
        bool increase = true;

        while (true)
        {
            await Task.Delay(100);

            if (vm.Opacity >= 1) { increase = false; }
            else if (vm.Opacity <= 0.1) { increase = true; }

            if (increase)
            {
                vm.Opacity += 0.05;
                vm.Scale += 0.05;
                vm.Rotation += 2;
            }

            else
            {
                vm.Opacity -= 0.05;
                vm.Scale -= 0.05;
                vm.Rotation -= 2;
            }

        }
    }



}

