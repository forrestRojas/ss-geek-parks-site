﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        private readonly string connectionString;

        public ParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ParkData GetPark(string code)
        {
            ParkData park = new ParkData();
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT p.*, COALESCE(s.cnt, 0) AS SurveyCount FROM park AS p LEFT JOIN (SELECT parkCode, COUNT(parkCode) AS cnt FROM survey_result GROUP BY parkCode) AS s ON p.parkCode = s.parkCode WHERE p.parkCode = @parkCode ORDER BY p.parkCode;", conn);
                    cmd.Parameters.AddWithValue("@parkCode", code);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        park = this.ConvertSqlToPark(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return park;
        }

        public IList<ParkData> GetParks()
        {
            List<ParkData> parks = new List<ParkData>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT p.*, COALESCE(s.cnt, 0) AS SurveyCount FROM park AS p LEFT JOIN (SELECT parkCode, COUNT(parkCode) AS cnt FROM survey_result GROUP BY parkCode) AS s ON p.parkCode = s.parkCode ORDER BY p.parkCode", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ParkData park = this.ConvertSqlToPark(reader);
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
