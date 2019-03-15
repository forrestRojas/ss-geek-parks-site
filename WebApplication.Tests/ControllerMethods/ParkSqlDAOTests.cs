using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests.ControllerMethods
{
    // TODO MOVE To the DAL Test Folder
    [TestClass]
    public class ParkSqlDAOTests
    {
        Mock<IList<ParkData>> mockParks;
        Mock<IList<Survey>> mockSurveys;
        Mock<IParkDAO> mockParkDAO;

        [TestInitialize]
        public void Initialize()
        {
            const string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=NPGeek;Integrated Security=True";

            mockParkDAO = Mock.Get(new ParkSqlDAO(connectionString)).As<IParkDAO>();
            Mock<ISurveyDAO> mockSurveyDAO = Mock.Get(new SurveySqlDAO(connectionString)).As<ISurveyDAO>();

            mockParkDAO.SetupGet(m => m.GetParks()).Returns(mockParks.Object);
            mockSurveyDAO.SetupGet(m => m.GetSurveys()).Returns(mockSurveys.Object);
        }

        [TestMethod]
        public void Returns_Dictionary_Of_ParkNames_And_SurveyCount()
        {
            // Arange
            IDictionary<string, int> expected = new Dictionary<string, int>();

            //ACT
            IDictionary<string, int> actual = mockParkDAO.Object.GetParkSurveyCounts(mockParks.Object, mockSurveys.Object);

            //Assert
            CollectionAssert.AreEquivalent(expected.ToList(), actual.ToList();
        }
    }
}
