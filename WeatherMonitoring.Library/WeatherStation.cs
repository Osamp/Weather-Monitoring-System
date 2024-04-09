using WeatherMonitoring.Library.Interfaces;

namespace WeatherMonitoring.Library;
/// <summary>
/// Represents a factory class for creating display objects based on the display type.
/// </summary>
public class WeatherStation
{
    /// <summary>
    /// Creates a display object based on the specified display type.
    /// </summary>
    /// <returns>The created display object.</returns>
    /// <exception cref="ArgumentException">Thrown when an invalid display type is provided.</exception>
    public static IDisplay CreateDisplay(string type, WeatherData weatherData)
    {
        switch (type)
        {
            case "CurrentConditions":
                return new CurrentConditionsDisplay(weatherData);
            case "Statistics":
                return new StatisticsDisplay(weatherData);
            case "Forecast":
                return new ForecastDisplay(weatherData);
            default:
                throw new ArgumentException("Invalid display type");
        }
    }
}
