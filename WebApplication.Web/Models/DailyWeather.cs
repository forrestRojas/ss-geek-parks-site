using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class DailyWeather
    {
        /// <summary>
        /// Gets or sets the park identifier code
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// Gets or sets the forecast day for the park
        /// </summary>
        public int ForecastDay { get; set; }

        /// <summary>
        /// Gets or sets the expected low temp for the forecast day in degrees F
        /// </summary>
        public double LowTemp { get; set; }

        /// <summary>
        /// Gets or sets the expected high temp for the forecast day in degrees F
        /// </summary>
        public double HiTemp { get; set; }

        /// <summary>
        /// Gets or sets the projected forecast for the day
        /// </summary>
        public string Forecast { get; set; }
    }
}
