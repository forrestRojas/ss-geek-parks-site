using System.Collections.Generic;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    /// <summary>
    /// Represents a IParkDAO Interface.
    /// </summary>
    public interface IParkDAO
    {
        /// <summary>
        /// Gets all the Parks.
        /// </summary>
        /// <returns>An IList of <see cref="ParkData"/></returns>
        IList<ParkData> GetParks();

        /// <summary>
        /// Gets a single park via the code.
        /// </summary>
        /// <param name="code">the park's unquie code.</param>
        /// <returns>a <see cref="ParkData"/>.</returns>
        ParkData GetPark(string code);
    }
}