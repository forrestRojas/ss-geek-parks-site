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

        public HomeController(IParkDAO parkDAO, IWeatherDAO weatherDAO)
        {
            this.parkDAO = parkDAO;
            this.weatherDAO = weatherDAO;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IList<ParkData> parks = this.parkDAO.GetParks();
            return View(parks);
        }

        [HttpGet]
        public IActionResult Detail(string code)
        {
            ParkData park = parkDAO.GetPark(code);
            string advisories = String.Empty;
            IList<DailyWeather> forecast = weatherDAO.GetWeather(code);
            if (forecast[0].Forecast == "snow")
            {
                advisories += "Snow advisory. Pack snowshoes. ";
            }
            if (forecast[0].Forecast == "rain" || forecast[0].Forecast == "thunderstorms")
            {
                advisories += "Rain advisory. Pack rain gear and wear waterproof shoes. "
            }
            if (forecast[0].Forecast == "thunderstorms")
            {
                advisories += "Thunderstorm advisory. Seek shelter and avoid hiking on exposed ridges. ";
            }
            if (forecast[0].Forecast == "sunny")
            {
                advisories += "Weather advisory. Pack sunblock. ";
            }
            if(forecast[0].HiTemp > 75)
            {
                advisories += "Heat advisory. Bring an extra gallon of water. ";
            }
            if (forecast[0].HiTemp - forecast[0].LowTemp > 20)
            {
                advisories += "Temperature differential advisory.  Wear breathable lyers. ";
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


            return View(model);   //ParkDetailViewModel model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
