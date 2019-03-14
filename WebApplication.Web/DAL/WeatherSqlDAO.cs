using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {
        private readonly string connectionString;

        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<DailyWeather> GetWeather(string code)
        {
            IList<DailyWeather> WeatherForecast = new List<DailyWeather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from weather where parkCode = @parkCode order by fiveDayForecastValue", conn);
                    cmd.Parameters.AddWithValue("@parkCode", code);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DailyWeather dailyWeather = ConvertSqlToWeather(reader);
                        WeatherForecast.Add(dailyWeather);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return WeatherForecast;
        }

        private DailyWeather ConvertSqlToWeather(SqlDataReader reader)
        {
            DailyWeather dailyWeather = new DailyWeather
            {
                ForecastDay = Convert.ToInt32(reader["fiveDayForecastValue"]),
                LowTemp = Convert.ToInt32(reader["low"]),
                HiTemp = Convert.ToInt32(reader["high"]),
                Forecast = Convert.ToString(reader["forecast"])
            };
            return dailyWeather;
        }
    }
}
