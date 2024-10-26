using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringSystem
{
    public class DailySummary
    {
        public DateTime Date { get; set; }
        public double AverageTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public double MinTemperature { get; set; }
        public string DominantWeatherCondition { get; set; }
    }
}
