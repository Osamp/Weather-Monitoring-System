using WeatherMonitoring.Library.Interfaces;
using WeatherMonitoring.Library;
public class CurrentConditionsDisplay : IObserver, IDisplay
{
    private float temperature;
    private float humidity;
    private WeatherData weatherData;

    public CurrentConditionsDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.RegisterObserver(this);
    }

    public void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Current conditions: {temperature}F degrees");
        Console.WriteLine($"        Humidity: {humidity}% ");
    }
}

public class CurrentConditionsDecorator : CurrentConditionsDisplay
{
    public CurrentConditionsDecorator(WeatherData weatherData) : base(weatherData) {}

    public new void Display()
    {
        base.Display();
        Console.WriteLine($"Current time: {DateTime.Now}");
    }
}
