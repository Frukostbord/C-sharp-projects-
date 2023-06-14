using Duplicate_finder.ViewModel;

namespace Duplicate_finder;

public partial class MainPage : ContentPage
{
    /// <summary>
    /// Initializing viewmodel (VM) in MVVM
    /// </summary>
    /// <param name="viewModelBase">ViewModel to initialize</param>

    /* Unmerged change from project 'Duplicate finder (net6.0-windows10.0.19041.0)'
    Before:
        public MainPage(ViewModelBase viewModelBase)
    After:
        public MainPage(ViewModel.ViewModel viewModelBase)
    */
    public MainPage(ViewModelBase viewModelBase)
    {
        InitializeComponent();
        BindingContext = viewModelBase;
    }
}

