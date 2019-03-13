using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class DailyWeather
    {
        /// <summary>
        /// The park identifier code
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// The forecast day for the park
        /// </summary>
        public int ForecastDay { get; set; }

        /// <summary>
        /// The expected low temp for the forecast day in degrees F
        /// </summary>
        public double LowTemp { get; set; }

        /// <summary>
        /// The expected high temp for the forecast day in degrees F
        /// </summary>
        public double HiTemp { get; set; }

        /// <summary>
        /// The projected forecast for the day
        /// </summary>
        public string Forecast { get; set; }
    }
}
