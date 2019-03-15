using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class ParkData
    {
        /// <summary>
        /// The unique park code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The name of the park
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The state in which the park is located
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The park's acreage
        /// </summary>
        public int Acreage { get; set; }

        /// <summary>
        /// The park's elevation in feet above sea level
        /// </summary>
        public int Elevation { get; set; }

        /// <summary>
        /// Miles of hiking trails in the park
        /// </summary>
        public int TrailMiles { get; set; }

        /// <summary>
        /// The number of campsites in the park.
        /// </summary>
        public int Campsites { get; set; }

        /// <summary>
        /// The park's average overall climate
        /// </summary>
        public string Climate { get; set; }

        /// <summary>
        /// The year the park was instituted
        /// </summary>
        public int YearFounded { get; set; }

        /// <summary>
        /// The average annual visitor count
        /// </summary>
        public int AnnualVisitorCount { get; set; }

        /// <summary>
        /// A famous quote related to the park
        /// </summary>
        public string Quote { get; set; }

        /// <summary>
        /// The person to whom the quote is attributed
        /// </summary>
        public string QuoteAuthor { get; set; }

        /// <summary>
        /// The park description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Entry Fee for the park
        /// </summary>
        public decimal EntryFee { get; set; }

        /// <summary>
        /// The number of animal species in the park
        /// </summary>
        public int NumSpecies { get; set; }

        /// <summary>
        /// The number of surveys the park has.
        /// </summary>
        public int SurveyCount { get; set; }
    }
}
