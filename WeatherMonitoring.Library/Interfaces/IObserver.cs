
namespace WeatherMonitoring.Library.Interfaces;


public interface IObserver
{
    void Update(float temperature, float humidity, float pressure);
}

