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
        /// <returns>A Bool to indicate if the <see cref="Survey"/> was saved.</returns>
        /// <param name="survey">A Survey to be added to teh database</param>
        bool NewSurvey(Survey survey);
    }
}
