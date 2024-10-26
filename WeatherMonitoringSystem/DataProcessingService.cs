using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringSystem
{
    using System.Collections.Generic;
    using System.Linq;

    public class DataProcessingService
    {
        private readonly List<WeatherData> _weatherDataList = new List<WeatherData>();

        public void AddWeatherData(WeatherData data)
        {
            _weatherDataList.Add(data);
        }

        public DailySummary CalculateDailySummary(DateTime date)
        {
            var dataForDay = _weatherDataList.Where(d => d.DateTime.Date == date.Date).ToList();

            return new DailySummary
            {
                Date = date,
                AverageTemperature = dataForDay.Average(d => d.Temp),
                MaxTemperature = dataForDay.Max(d => d.Temp),
                MinTemperature = dataForDay.Min(d => d.Temp),
                DominantWeatherCondition = GetDominantCondition(dataForDay)
            };
        }

        private string GetDominantCondition(List<WeatherData> data)
        {
            return data.GroupBy(d => d.Main)
                       .OrderByDescending(g => g.Count())
                       .First().Key;
        }
    }
}
