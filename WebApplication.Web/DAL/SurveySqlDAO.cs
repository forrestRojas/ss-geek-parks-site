using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class SurveySqlDAO : ISurveyDAO
    {
        private readonly string connectionString;

        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Survey> GetSurveys()
        {
            throw new NotImplementedException();
        }

        public void NewSurvey(Survey survey)
        {
            throw new NotImplementedException();
        }
    }
}
