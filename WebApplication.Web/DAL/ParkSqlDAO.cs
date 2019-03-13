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
            throw new NotImplementedException();
        }

        public IList<ParkData> GetParks()
        {
            List<ParkData> parks = new List<ParkData>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from park order by parkName;", conn);

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
                NumSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
            };

            return park;
        }
    }
}