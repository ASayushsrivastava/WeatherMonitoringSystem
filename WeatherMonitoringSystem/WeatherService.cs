using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace WeatherMonitoringSystem
{
    public class WeatherService
    {
        private readonly string _apiKey = "YOUR_API_KEY";
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}";
            var response = await _httpClient.GetStringAsync(url);
            var weatherData = JsonConvert.DeserializeObject<WeatherData>(response);

            // Convert temperature to Celsius
            weatherData.Temp -= 273.15;
            weatherData.FeelsLike -= 273.15;

            return weatherData;
        }
    }
}
