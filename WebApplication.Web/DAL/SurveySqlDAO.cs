using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    /// <summary>
    /// Represents a SurveySqlDAO
    /// </summary>
    public class SurveySqlDAO : ISurveyDAO
    {
        /// <summary>
        /// The sql cnnection string
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Creates a SurveysqlDAO.
        /// </summary>
        /// <param name="connectionString">The sql Connection string</param>
        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Adds a new Survey to the database.
        /// </summary>
        /// <param name="survey">The <see cref="Survey"/> to be added to the SQL Database.</param>
        /// <returns>A Bool to indicate if the <see cref="Survey"/> was saved.</returns>
        public bool NewSurvey(Survey survey)
        {
            bool wasSaved = false;
            try
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
    
                    return wasSaved = (1 == cmd.ExecuteNonQuery());
                }
            }
            catch (SqlException)
            {

                throw;
            }
        }
    }
}
