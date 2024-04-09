using WeatherMonitoring.Library.Interfaces;

namespace WeatherMonitoring.Library;
/// <summary>
/// Represents a display showing a weather forecast based on pressure changes.
/// </summary>
public class ForecastDisplay : IObserver, IDisplay
{
    private float currentPressure = 29.92f;
    private float lastPressure;
    private WeatherData weatherData;

    /// <summary>
    /// Initializes a new instance of the <see cref="ForecastDisplay"/> class.
    /// </summary>
    public ForecastDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.RegisterObserver(this);
    }

    /// <summary>
    /// Updates the forecast based on the current pressure.
    /// </summary>
    public void Update(float temperature, float humidity, float pressure)
    {
        lastPressure = currentPressure;
        currentPressure = pressure;

        Display();
    }

    /// <summary>
    /// Displays the weather forecast based on pressure changes.
    /// </summary>
    public void Display()
    {
        Console.Write("Forecast: ");
        if (currentPressure > lastPressure)
        {
            Console.WriteLine("Improving weather on the way!");
        }
        else if (currentPressure == lastPressure)
        {
            Console.WriteLine("More of the same");
        }
        else if (currentPressure < lastPressure)
        {
            Console.WriteLine("Watch out for cooler, rainy weather");
        }
        Console.WriteLine("-----------------");
    }
}
