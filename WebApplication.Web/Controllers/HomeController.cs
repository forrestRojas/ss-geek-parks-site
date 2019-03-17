using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IParkDAO parkDAO;
        private readonly IWeatherDAO weatherDAO;

        public HomeController(IParkDAO parkDAO, IWeatherDAO weatherDAO, ISurveyDAO surveyDAO)
        {
            this.parkDAO = parkDAO;
            this.weatherDAO = weatherDAO;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IList<ParkData> parks = this.parkDAO.GetParks();
            return this.View(parks);
        }

        [HttpGet]
        public IActionResult Detail(string code)
        {
            ParkData park = this.parkDAO.GetPark(code);
            string advisories = string.Empty;
            IList<DailyWeather> forecast = this.weatherDAO.GetWeather(code);
            if (forecast[0].Forecast == "snow")
            {
                advisories += "Snow advisory. Pack snowshoes. ";
            }

            if (forecast[0].Forecast == "rain" || forecast[0].Forecast == "thunderstorms")
            {
                advisories += "Rain advisory. Pack rain gear and wear waterproof shoes. ";
            }

            if (forecast[0].Forecast == "thunderstorms")
            {
                advisories += "Thunderstorm advisory. Seek shelter and avoid hiking on exposed ridges. ";
            }

            if (forecast[0].Forecast == "sunny")
            {
                advisories += "Weather advisory. Pack sunblock. ";
            }

            if (forecast[0].HiTemp > 75)
            {
                advisories += "Heat advisory. Bring an extra gallon of water. ";
            }

            if (forecast[0].HiTemp - forecast[0].LowTemp > 20)
            {
                advisories += "Temperature differential advisory.  Wear breathable layers. ";
            }

            if (forecast[0].LowTemp < 20)
            {
                advisories += "Cold advisory. Beware of exposure to frigid temperatures. ";
            }

            ParkDetailViewModel model = new ParkDetailViewModel
            {
                Park = park,
                Forecast = forecast,
                WeatherAdvisories = advisories
            };


            return this.View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
