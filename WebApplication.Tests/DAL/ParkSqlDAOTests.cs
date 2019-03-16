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
    // TODO MOVE To the DAL Test Folder
    [TestClass]
    public class ParkSqlDAOTests
    {
        IList<ParkData> mockParks;
        IList<Survey> mockSurveys;
        IParkDAO mockParkDAO;

        [TestInitialize]
        public void Initialize()
        {
            const string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=NPGeek;Integrated Security=True";

            mockParkDAO = new ParkSqlDAO(connectionString);
            ISurveyDAO mockSurveyDAO = new SurveySqlDAO(connectionString);

            mockParks = mockParkDAO.GetParks();
            mockSurveys = mockSurveyDAO.GetSurveys();
        }

        [TestMethod]
        public void Returns_Dictionary_Of_ParkNames_And_SurveyCount()
        {
            // Arange
            IDictionary<string, int> expected = new Dictionary<string, int>();

            //ACT
            IDictionary<string, int> actual = mockParkDAO.GetParkSurveyCounts(mockParks, mockSurveys);

            //Assert
            CollectionAssert.AreEquivalent(expected.ToList(), actual.ToList());
        }
    }
}
