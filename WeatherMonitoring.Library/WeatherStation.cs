using WeatherMonitoring.Library.Interfaces;
using WeatherMonitoring.Library;
public class WeatherStation
{
    public static IDisplay CreateDisplay(string type, WeatherData weatherData)
    {
        switch (type)
        {
            case "CurrentConditions":
                return new CurrentConditionsDisplay(weatherData);
            case "Statistics":
                // return new StatisticsDisplay(weatherData);
            case "Forecast":
                // return new ForecastDisplay(weatherData);
            default:
                throw new ArgumentException("Invalid display type");
        }
    }
}
