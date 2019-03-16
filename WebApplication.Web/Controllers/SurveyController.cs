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
        public IActionResult AddToSurvey(string ParkCode, string UserEmail, string UserState, string ActivityLevel)
        {
            Survey newSurvey = new Survey();
            newSurvey.ParkCode = ParkCode;
            newSurvey.UserEmail = UserEmail;
            newSurvey.UserState = UserState;
            newSurvey.ActivityLevel = ActivityLevel;
            surveyDAO.NewSurvey(newSurvey);

            // set cookie so user can't participate again today
            Response.Cookies.Append("SurveyComplete", "true");

            return RedirectToAction("FavoriteParks");
        }

        [HttpGet]
        public IActionResult FavoriteParks()
        {
            IList<ParkData> parks = parkDAO.GetParks();
            IList<Survey> surveys = surveyDAO.GetSurveys();
            IDictionary<string, int> surveyCount = parkDAO.GetParkSurveyCounts(parks, surveys);

            foreach (ParkData park in parks)
            {
                park.SurveyCount = surveyCount[park.Name];
            }

            return View(parks);
        }
    }
}