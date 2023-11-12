using WeatherApp.ViewModels;

namespace WeatherApp;

public partial class MainPage : ContentPage
{
    public MainPage(WeatherViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}