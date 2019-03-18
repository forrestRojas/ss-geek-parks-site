using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    /// <summary>
    /// Represents a PArkSqlDAO
    /// </summary>
    public class ParkSqlDAO : IParkDAO
    {
        /// <summary>
        /// The Sql Connection string
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Creates a new ParkSqlDAO
        /// </summary>
        /// <param name="connectionString">The sql Connection string</param>
        public ParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets a Single park from the SQL Database via the park code.
        /// </summary>
        /// <param name="code">The park's unique code.</param>
        /// <returns>a <see cref="ParkData"/> model.</returns>
        public ParkData GetPark(string code)
        {
            ParkData park = new ParkData();
            string sqlQuery = "SELECT p.*, COALESCE(s.cnt, 0) AS SurveyCount " +
                              "FROM park AS p LEFT JOIN (SELECT parkCode, COUNT(parkCode) AS cnt " +
                                                        "FROM survey_result " +
                                                        "GROUP BY parkCode" +
                                                        ") AS s ON p.parkCode = s.parkCode " +
                              "WHERE p.parkCode = @parkCode " +
                              "ORDER BY p.parkCode;";
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.AddWithValue("@parkCode", code);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        park = ConvertSqlToPark(reader);
                    }
                }
            }
            catch (SqlException)
            {

                throw;
            }
            return park;
        }

        /// <summary>
        /// Gets all the parks form the SQL Database.
        /// </summary>
        /// <returns>An <see cref="List{T}"/> of <see cref="ParkData"/>.</returns>
        public IList<ParkData> GetParks()
        {
            List<ParkData> parks = new List<ParkData>();
            string sqlQuery = "SELECT p.*, COALESCE(s.cnt, 0) AS SurveyCount " +
                              "FROM park AS p " +
                              "LEFT JOIN (SELECT parkCode, COUNT(parkCode) AS cnt " +
                                         "FROM survey_result " +
                                         "GROUP BY parkCode" +
                                         ") AS s ON p.parkCode = s.parkCode " +
                              "ORDER BY p.parkCode;";
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ParkData park = ConvertSqlToPark(reader);
                        parks.Add(park);
                    }

                }
            }
            catch (SqlException)
            {

                throw;
            }

            return parks;
        }

        /// <summary>
        /// Converts the reader data into a <see cref="ParkData"/> model.
        /// </summary>
        /// <param name="reader">A <see cref="SqlDataReader"/></param>
        /// <returns>A <see cref="ParkData"/> model.</returns>
        private ParkData ConvertSqlToPark(SqlDataReader reader)
        {
            ParkData park = new ParkData
            {
                Name = Convert.ToString(reader["parkName"]),
                Code = Convert.ToString(reader["parkCode"]),
                State = Convert.ToString(reader["state"]),
                Climate = Convert.ToString(reader["climate"]),
                Campsites = Convert.ToInt32(reader["numberOfCampsites"]),
                Acreage = Convert.ToInt32(reader["acreage"]),
                AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                Description = Convert.ToString(reader["parkDescription"]),
                Elevation = Convert.ToInt32(reader["elevationInFeet"]),
                EntryFee = Convert.ToDecimal(reader["entryFee"]),
                TrailMiles = Convert.ToInt32(reader["milesOfTrail"]),
                YearFounded = Convert.ToInt32(reader["yearFounded"]),
                Quote = Convert.ToString(reader["inspirationalQuote"]),
                QuoteAuthor = Convert.ToString(reader["inspirationalQuoteSource"]),
                NumSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]),
                SurveyCount = Convert.ToInt32(reader["SurveyCount"])
            };

            return park;
        }
    }
}
