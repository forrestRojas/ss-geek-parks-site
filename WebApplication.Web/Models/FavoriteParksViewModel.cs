using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    /// <summary>
    /// Represents a Favorite Parks View Model.
    /// </summary>
    public class FavoriteParksViewModel
    {
        /// <summary>
        /// Gets or sets a List of parks.
        /// </summary>
        public IList<ParkData> Parks { get; set; }

        /// <summary>
        /// Gets or Sets a List of Surveys.
        /// </summary>
        public IList<Survey> Surveys { get; set; }
    }
}
