using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class ParkData
    {
        /// <summary>
        /// Gets or sets the unique park code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name of the park
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the state in which the park is located
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the park's acreage
        /// </summary>
        public int Acreage { get; set; }

        /// <summary>
        /// Gets or sets the park's elevation in feet above sea level
        /// </summary>
        public int Elevation { get; set; }

        /// <summary>
        /// Gets or sets the miles of hiking trails in the park
        /// </summary>
        public int TrailMiles { get; set; }

        /// <summary>
        /// Gets or sets the number of campsites in the park.
        /// </summary>
        public int Campsites { get; set; }

        /// <summary>
        /// Gets or sets the park's average overall climate
        /// </summary>
        public string Climate { get; set; }

        /// <summary>
        /// Gets or sets the year the park was instituted
        /// </summary>
        public int YearFounded { get; set; }

        /// <summary>
        /// Gets or sets the average annual visitor count
        /// </summary>
        public int AnnualVisitorCount { get; set; }

        /// <summary>
        /// Gets or sets a famous quote related to the park
        /// </summary>
        public string Quote { get; set; }

        /// <summary>
        /// Gets or sets the person to whom the quote is attributed
        /// </summary>
        public string QuoteAuthor { get; set; }

        /// <summary>
        /// Gets or sets the park description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Entry Fee for the park
        /// </summary>
        public decimal EntryFee { get; set; }

        /// <summary>
        /// Gets or sets the number of animal species in the park
        /// </summary>
        public int NumSpecies { get; set; }

        /// <summary>
        /// Gets or sets the number of surveys the park has.
        /// </summary>
        public int SurveyCount { get; set; }
    }
}
