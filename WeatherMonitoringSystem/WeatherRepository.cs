using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace WeatherMonitoringSystem
{
    using System.Data.SqlClient;

    public class WeatherRepository
    {
        private readonly string _connectionString = "Server=localhost,1433;Database=WeatherDB;User Id=sa;Password=Your_password123;";

        public void SaveDailySummary(DailySummary summary)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO DailySummaries (Date, AverageTemperature, MaxTemperature, MinTemperature, DominantWeatherCondition) VALUES (@Date, @AverageTemperature, @MaxTemperature, @MinTemperature, @DominantWeatherCondition)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", summary.Date);
                    command.Parameters.AddWithValue("@AverageTemperature", summary.AverageTemperature);
                    command.Parameters.AddWithValue("@MaxTemperature", summary.MaxTemperature);
                    command.Parameters.AddWithValue("@MinTemperature", summary.MinTemperature);
                    command.Parameters.AddWithValue("@DominantWeatherCondition", summary.DominantWeatherCondition);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
