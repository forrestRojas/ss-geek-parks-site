using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            IList<DailyWeather> forecast = IWeatherDAO.GetWeather(code);


            return View();   //ParkDetail model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
