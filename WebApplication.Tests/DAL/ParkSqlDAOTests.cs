using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class ParkSqlDAOTests
    {
        IList<ParkData> mockParks;
        IParkDAO mockParkDAO;

        [TestInitialize]
        public void Initialize()
        {
            const string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=NPGeek;Integrated Security=True";

            mockParkDAO = new ParkSqlDAO(connectionString);
            ISurveyDAO mockSurveyDAO = new SurveySqlDAO(connectionString);

            mockParks = mockParkDAO.GetParks();
        }
    }
}
