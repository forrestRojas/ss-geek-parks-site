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
            if (this.Request.Cookies["SurveyComplete"] != null)
            {
                return this.RedirectToAction("FavoriteParks");
            }

            ParkData park = new ParkData();
            IList<ParkData> parks = this.parkDAO.GetParks();
            this.ViewData["ParkList"] = parks;
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToSurvey(string parkCode, string userEmail, string userState, string activityLevel)
        {
            Survey newSurvey = new Survey();
            newSurvey.ParkCode = parkCode;
            newSurvey.UserEmail = userEmail;
            newSurvey.UserState = userState;
            newSurvey.ActivityLevel = activityLevel;
            this.surveyDAO.NewSurvey(newSurvey);

            // set cookie so user can't participate again today
            this.Response.Cookies.Append("SurveyComplete", "true");

            return this.RedirectToAction("FavoriteParks");
        }

        [HttpGet]
        public IActionResult FavoriteParks()
        {
            IList<ParkData> parks = this.parkDAO.GetParks();

            return this.View(parks);
        }
    }
}