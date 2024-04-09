using WeatherMonitoring.Library.Interfaces;
using WeatherMonitoring.Library;

public class ForecastDisplay : IObserver, IDisplay
{
    private float currentPressure = 29.92f;  
    private float lastPressure;
    private WeatherData weatherData;

    public ForecastDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.RegisterObserver(this);
    }

    public void Update(float temperature, float humidity, float pressure)
    {
        lastPressure = currentPressure;
        currentPressure = pressure;

        Display();
    }

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
