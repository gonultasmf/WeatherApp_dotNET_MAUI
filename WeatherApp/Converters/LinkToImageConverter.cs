using System.Globalization;

namespace WeatherApp.Converters;

public class LinkToImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string link)
        {
            link = link.StartsWith("//") ? link.Insert(0, "https:") : link;
            var imageSource = ImageSource.FromUri(new Uri(link));

            return imageSource;
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
