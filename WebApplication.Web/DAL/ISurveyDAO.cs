using System;
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
        /// <param name="survey">The data object passed from the controller</param>
        void NewSurvey(Survey survey);
    }
}
