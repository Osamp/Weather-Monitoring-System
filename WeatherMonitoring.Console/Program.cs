using WeatherMonitoring.Library;

WeatherData weatherData = WeatherData.GetInstance();
    var currentDisplay = new CurrentConditionsDisplay(weatherData);
    var statisticsDisplay = new StatisticsDisplay(weatherData);
    var forecastDisplay = new ForecastDisplay(weatherData);

    // Simulate new weather measurements
    weatherData.SetMeasurements(80, 65, 30.4f);
    weatherData.SetMeasurements(82, 70, 29.2f);