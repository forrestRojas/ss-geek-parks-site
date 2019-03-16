using System.Collections.Generic;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface IParkDAO
    {
        IList<ParkData> GetParks();

        ParkData GetPark(string code);
    }
}