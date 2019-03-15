﻿using System;
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
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DailySurvey(int n)
        {
            return RedirectToAction("FavoriteParks");
        }

        [HttpGet]
        public IActionResult FavoriteParks()
        {
            IList<ParkData> parks = parkDAO.GetParks();

            return View(parks);
        }

    }
}