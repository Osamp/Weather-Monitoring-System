using WeatherMonitoring.Library.Interfaces;
using WeatherMonitoring.Library;

public class StatisticsDisplay : IObserver, IDisplay
{
    private List<float> temperatures = new List<float>();
    private WeatherData weatherData;

    public StatisticsDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.RegisterObserver(this);
    }

    public void Update(float temperature, float humidity, float pressure)
    {
        temperatures.Add(temperature);
        Display();
    }

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
