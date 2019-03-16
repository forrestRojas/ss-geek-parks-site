using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            List<Survey> surveys = new List<Survey>();

            return surveys;
        }

        public void NewSurvey(Survey survey)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = $"insert into survey_result values (@ParkCode, @UserEmail, @UserState, @ActivityLevel);";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ParkCode", survey.ParkCode);
                cmd.Parameters.AddWithValue("@UserEmail", survey.UserEmail);
                cmd.Parameters.AddWithValue("@UserState", survey.UserState);
                cmd.Parameters.AddWithValue("@ActivityLevel", survey.ActivityLevel);

                cmd.ExecuteNonQuery();

            }
        }
    }
}
