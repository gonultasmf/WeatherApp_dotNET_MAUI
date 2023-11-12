namespace WeatherApp
{
    public partial class App : Application
    {
        public static string API_KEY = "8f8217f9d9fe4ee49bc124343231211";
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}