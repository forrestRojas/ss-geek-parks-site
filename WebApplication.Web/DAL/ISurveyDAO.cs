﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    /// <summary>
    /// An Interface for the survey DAO.
    /// </summary>
    public interface ISurveyDAO
    {
        /// <summary>
        /// Creates a new survey and adds it to the database.
        /// </summary>
        /// <param name="survey"></param>
        void NewSurvey(Survey survey);

        /// <summary>
        /// Gets all the surveys from the database.
        /// </summary>
        /// <returns></returns>
        IList<Survey> GetSurveys();
    }
}