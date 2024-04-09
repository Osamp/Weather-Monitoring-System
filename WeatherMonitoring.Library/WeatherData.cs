using WeatherMonitoring.Library.Interfaces;

namespace WeatherMonitoring.Library;
/// <summary>
/// Represents the weather data subject in the observer pattern.
/// </summary>
public class WeatherData
{
    private static WeatherData instance;
    private List<IObserver> observers = new List<IObserver>();
    private float temperature;
    private float humidity;
    private float pressure;

    /// <summary>
    /// Private constructor to enforce the singleton pattern.
    /// </summary>
    private WeatherData() { }
    // <summary>
    /// Gets the singleton instance of the WeatherData class.
    /// </summary>
    /// <returns>The singleton instance of WeatherData.</returns>
    public static WeatherData GetInstance()
    {
        if (instance == null)
        {
            instance = new WeatherData();
        }
        return instance;
    }
    /// <summary>
    /// Registers an observer to receive updates from this WeatherData instance.
    /// </summary>
    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }
    /// <summary>
    /// Removes an observer from the list of registered observers.
    /// </summary>
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }
    /// <summary>
    /// Notifies all registered observers about the change in weather conditions.
    /// </summary>
    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(temperature, humidity, pressure);
        }
    }
    /// <summary>
    /// Invokes the NotifyObservers method, indicating that the weather measurements have changed.
    /// </summary>
    public void MeasurementsChanged()
    {
        NotifyObservers();
    }
    /// <summary>
    /// Sets the weather measurements (temperature, humidity, pressure) and notifies observers.
    /// </summary>
    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        MeasurementsChanged();
    }
}
