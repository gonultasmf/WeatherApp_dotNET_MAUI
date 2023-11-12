using CommunityToolkit.Mvvm.ComponentModel;
using FmgLib.HttpClientHelper;
using System.Windows.Input;
using WeatherApp.Models;

namespace WeatherApp.ViewModels;

public partial class WeatherViewModel : ObservableObject
{
    public WeatherViewModel()
    {
        GetWeather();
    }

    [ObservableProperty]
    private RootModel _rootModel;

    [ObservableProperty]
    private bool isVisible;

    [ObservableProperty]
    private bool isLoading;

    public DateTime Date { get; set; } = DateTime.Now;


    public async void GetWeather()
    {
        Location location = await Geolocation.Default.GetLastKnownLocationAsync();

        if (location != null)
        {
            await GetWeather(location);
        }
    }

    public ICommand SearchCommand =>
        new Command(async (searchText) =>
        {
            var location = await GetCoordinatesAsync(searchText.ToString());
            await GetWeather(location);
        });


    private async Task GetWeather(Location location)
    {
        IsLoading = true;
        string url = $"https://api.weatherapi.com/v1/forecast.json?q={location.Latitude}%2C{location.Longitude}&days=10&lang=tr&key={App.API_KEY}";
        var resultModel = await HttpClientHelper.SendAsync<RootModel>(url, HttpMethod.Get);

        if (resultModel != null)
        {
            RootModel = resultModel;
            IsVisible = true;
        }
        IsLoading = false;
    }


    private async Task<Location> GetCoordinatesAsync(string value)
    {
        var locations = await Geocoding.Default.GetLocationsAsync(value);
        var location = locations?.FirstOrDefault();

        return location;
    }
}
