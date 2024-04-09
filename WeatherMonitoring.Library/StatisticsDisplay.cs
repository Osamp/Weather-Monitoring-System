using WeatherMonitoring.Library.Interfaces;

namespace WeatherMonitoring.Library;
/// <summary>
/// Represents a display showing weather statistics such as average, maximum, and minimum temperatures.
/// </summary>
public class StatisticsDisplay : IObserver, IDisplay
{
    private List<float> temperatures = new List<float>();
    private WeatherData weatherData;

    /// <summary>
    /// Initializes a new instance of the <see cref="StatisticsDisplay"/> class.
    /// </summary>
    public StatisticsDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.RegisterObserver(this);
    }

    /// <summary>
    /// Updates the statistics display with the latest temperature data.
    /// </summary>
    public void Update(float temperature, float humidity, float pressure)
    {
        temperatures.Add(temperature);
        Display();
    }

    /// <summary>
    /// Displays the weather statistics.
    /// </summary>
    public void Display()
    {
        Console.WriteLine("Stastics");
        Console.WriteLine($"Avg temperature = {AverageTemperature()}");
        Console.WriteLine($"Max temperature = {MaxTemperature()}");
        Console.WriteLine($"Min temperature = {MinTemperature()}");

    }

    private float MaxTemperature()
    {
        return temperatures.Count == 0 ? 0 : temperatures.Max();
    }

    private float MinTemperature()
    {
        return temperatures.Count == 0 ? 0 : temperatures.Min();
    }

    private float AverageTemperature()
    {
        return temperatures.Count == 0 ? 0 : temperatures.Average();
    }
}
