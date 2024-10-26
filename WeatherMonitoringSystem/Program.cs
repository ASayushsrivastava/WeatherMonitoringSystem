// See https://aka.ms/new-console-template for more information
using WeatherMonitoringSystem;

class Program
{
    static async Task Main(string[] args)
    {
        var cities = new[] { "Delhi", "Mumbai", "Chennai", "Bangalore", "Kolkata", "Hyderabad" };
        var weatherService = new WeatherService();
        var dataService = new DataProcessingService();
        var alertService = new AlertService(35); // Temperature threshold example
        var repository = new WeatherRepository();

        while (true)
        {
            foreach (var city in cities)
            {
                var weatherData = await weatherService.GetWeatherAsync(city);
                dataService.AddWeatherData(weatherData);

                if (alertService.CheckForAlert(weatherData))
                {
                    alertService.TriggerAlert($"High temperature detected in {city}: {weatherData.Temp}°C");
                }
            }

            var dailySummary = dataService.CalculateDailySummary(DateTime.Now);
            repository.SaveDailySummary(dailySummary);

            // Wait 5 minutes before the next call
            await Task.Delay(TimeSpan.FromMinutes(5));
        }
    }
}
