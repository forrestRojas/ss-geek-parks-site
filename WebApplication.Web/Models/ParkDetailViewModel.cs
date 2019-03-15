using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    /// <summary>
    /// Represents a park detail view model.
    /// </summary>
    public class ParkDetailViewModel
    {
        /// <summary>
        /// Gets or Sets the list of daily weather for the park.
        /// </summary>
        public IList<DailyWeather> Forecast { get; set; }

        /// <summary>
        /// Gets or sets the Park.
        /// </summary>
        public ParkData Park { get; set; }

        /// <summary>
        /// Passes the weather advisories for the first day's forecast
        /// </summary>
        public string WeatherAdvisories { get; set; }


    }
}
