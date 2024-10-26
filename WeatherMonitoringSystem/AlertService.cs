using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringSystem
{
    public class AlertService
    {
        private readonly double _temperatureThreshold;

        public AlertService(double temperatureThreshold)
        {
            _temperatureThreshold = temperatureThreshold;
        }

        public bool CheckForAlert(WeatherData data)
        {
            return data.Temp > _temperatureThreshold;
        }

        public void TriggerAlert(string message)
        {
            Console.WriteLine($"Alert: {message}");
        }
    }
}
