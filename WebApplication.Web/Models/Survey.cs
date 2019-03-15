using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    /// <summary>
    /// Represents a Survey.
    /// </summary>
    public class Survey
    {
        /// <summary>
        /// Gets or Sets the Survey Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the Park Code.
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// Gets or Sets the user's Email.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or Sets the User's State of Residence
        /// </summary>
        public string UserState { get; set; }

        /// <summary>
        /// Gets or Sets the user's Activity Level.
        /// </summary>
        public string ActivityLevel { get; set; }
    }
}
