using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;


namespace WebApplication.Web.Controllers
{
    public class SurveyController : Controller
    {
        private readonly IParkDAO parkDAO;
        private readonly IWeatherDAO weatherDAO;
        private readonly ISurveyDAO surveyDAO;

        public SurveyController(IParkDAO parkDAO, IWeatherDAO weatherDAO, ISurveyDAO surveyDAO)
        {
            this.parkDAO = parkDAO;
            this.weatherDAO = weatherDAO;
            this.surveyDAO = surveyDAO;
        }

        [HttpGet]
        public IActionResult DailySurvey()
        {
            if(Request.Cookies["SurveyComplete"] != null)
            {
                return RedirectToAction("FavoriteParks");
            }
            ParkData park = new ParkData();
            IList<ParkData> parks = parkDAO.GetParks();
            ViewData["ParkList"] = parks;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DailySurvey(string parkId, string userEmail, string userState, string activityLevel)
        {
            //TODO Add survey result to table
            return RedirectToAction("FavoriteParks");
        }

        [HttpGet]
        public IActionResult FavoriteParks()
        {
            IList<ParkData> parks = parkDAO.GetParks();
            IList<Survey> surveys = surveyDAO.GetSurveys();
            Dictionary<string, int> surveyCount =
                (from park in parks
                    join survey in surveys on park.Code equals survey.ParkCode into parkSurveys
                    orderby park.Name ascending
                    select new { parks = park.Name, surveys = parkSurveys.Count() }
                ).ToDictionary(p => p.parks, s => s.surveys);

            foreach (ParkData park in parks)
            {
                park.SurveyCount = surveyCount[park.Name];
            }

            return View(parks);
        }

    }
}