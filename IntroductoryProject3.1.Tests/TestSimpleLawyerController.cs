using DTOlibrary;
using IntroductoryProject3._1.Controllers;
using IntroductoryProject3._1.DAL;
using IntroductoryProject3._1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace IntroductoryProject3._1.Tests
{
    [TestClass]
    public class TestSimpleLawyerController
    {
        [TestMethod]
        public void GetAllLawyers_ShouldReturnAllLawyer()
        {
            var testLawyers = GetTestLawyersDTO();
            var controller = new LawyerController(testLawyers);

            var result = controller.GetAllLawyers() as List<LawyerDTO>;
            Assert.AreEqual(testLawyers.Count, result.Count);
        }

        [TestMethod]

        public void GetProduct_ShouldReturnCorrectLawyer()
        {
            var testLawyers = GetTestLawyersDTO();
            var controller = new LawyerController(testLawyers);
            var result = controller.GetAllLawyersByID(4) as OkNegotiatedContentResult<LawyerDTO>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testLawyers[3].Name, result.Content.Name);
        }



        [TestMethod]
        public void GetLawyer_ShouldNotFindLawyer()
        {
            var controller = new LawyerController(GetTestLawyersDTO());

            var result = controller.GetAllLawyersByID(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }


        [TestMethod]
        public void PostNewLawyer_ShouldPostLawyer()
        {
            // Arrange
            var mockRepository = new Mock<ILawyerRepository>();
            var controller = new LawyerController(mockRepository.Object);
            var model = new Lawyer()
            {
                Name = "Max",
                Surname = "Steel",
                Initials = "m.s.",
                Email = "m.s@test.test",
                DateOfBirth = DateTime.Parse("2005-09-01"),
                Gender_id = 1,
                Title_id = 1
            };

            // Act
            IHttpActionResult actionResult = controller.PostNewLawyer(model);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Lawyer>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(model.Name, createdResult.RouteValues["name"]);
        }




        private List<LawyerDTO> GetTestLawyersDTO()
        {
            var testLawyers = new List<LawyerDTO>();
            var controller = new LawyerController();
            testLawyers = controller.GetAllLawyers() as List<LawyerDTO>;

            return testLawyers;
        }
    }
}