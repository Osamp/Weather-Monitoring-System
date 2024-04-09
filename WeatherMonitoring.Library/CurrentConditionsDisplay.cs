using WeatherMonitoring.Library.Interfaces;

namespace WeatherMonitoring.Library;
/// <summary>
/// Represents a display showing current weather conditions.
/// </summary>
public class CurrentConditionsDisplay : IObserver, IDisplay
{
    private float temperature;
    private float humidity;
    private WeatherData weatherData;
    /// <summary>
    /// Initializes a new instance of the CurrentConditionsDisplay class.
    /// </summary>
    public CurrentConditionsDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.RegisterObserver(this);
    }
    /// <summary>
    /// Updates the current weather conditions.
    /// </summary>
    public void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        Display();
    }
    /// <summary>
    /// Displays the current weather conditions.
    /// </summary>
    public void Display()
    {
        Console.WriteLine($"Current conditions: {temperature}F degrees");
        Console.WriteLine($"        Humidity: {humidity}% ");
    }
}
/// <summary>
/// Represents a decorator that adds additional information to the current weather conditions display.
/// </summary>
public class CurrentConditionsDecorator : CurrentConditionsDisplay
{
    /// <summary>
    /// Initializes a new instance of the CurrentConditionsDecorator class.
    /// </summary>
    public CurrentConditionsDecorator(WeatherData weatherData) : base(weatherData) { }

    /// <summary>
    /// Overrides the Display method to add current time information.
    /// </summary>
    public new void Display()
    {
        base.Display();
        Console.WriteLine($"Current time: {DateTime.Now}");
    }
}
