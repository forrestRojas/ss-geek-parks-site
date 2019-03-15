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
        private readonly ISurveyDAO surveyDAO;

        public HomeController(IParkDAO parkDAO, IWeatherDAO weatherDAO, ISurveyDAO surveyDAO)
        {
            this.parkDAO = parkDAO;
            this.weatherDAO = weatherDAO;
            this.surveyDAO = surveyDAO;
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
            IList<DailyWeather> forecast = weatherDAO.GetWeather(code);
            ParkDetailVewModel model = new ParkDetailVewModel
            {
                Park = park,
                Forecast = forecast
            };


            return View(model);   //ParkDetail model);
        }

        [HttpGet]
        public IActionResult DailySurvey()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DailySurvey(int n)
        {
            return RedirectToAction("FavoriteParks");
        }

        [HttpPost]
        public IActionResult FavoriteParks()
        {
            IList<Survey> surveys = surveyDAO.GetSurveys();
            IList<ParkData> parks = parkDAO.GetParks();
            FavoriteParksViewModel model = new FavoriteParksViewModel
            {
                Parks = parks,
                Surveys = surveys
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
