using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringSystem
{
    public class WeatherData
    {
        public string Main { get; set; }
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public long Dt { get; set; }
        public DateTime DateTime => DateTimeOffset.FromUnixTimeSeconds(Dt).DateTime;
    }
}
