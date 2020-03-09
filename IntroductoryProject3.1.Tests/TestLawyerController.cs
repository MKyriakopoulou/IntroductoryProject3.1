//using IntroductoryProject3._1.Controllers;
//using IntroductoryProject3._1.Models;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Http.Results;

//namespace IntroductoryProject3._1.Tests
//{
//    [TestClass]
//    class TestSimpleLawyerController
//    {
//        [TestMethod]
//        public void PostProduct_ShouldReturnSameLawyer()
//        {
//            var controller = new LawyerController(new TestLawyerContext());

//            var item = GetDemoLawyer();

//            var result =
//                controller.PostNewLawyer(item) as CreatedAtRouteNegotiatedContentResult<Lawyer>;

//            Assert.IsNotNull(result);
//            Assert.AreEqual(result.RouteName, "DefaultApi");
//            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
//            Assert.AreEqual(result.Content.Name, item.Name);
//        }

//        [TestMethod]
//        public void PutProduct_ShouldReturnStatusCode()
//        {
//            var controller = new LawyerController(new TestLawyerContext());

//            var item = GetDemoLawyer();

//            var result = controller.PostNewLawyer(item) as StatusCodeResult;
//            Assert.IsNotNull(result);
//            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
//            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
//        }



//        [TestMethod]
//        public void GetProduct_ShouldReturnProductWithSameID()
//        {
//            var context = new TestLawyerContext();
//            context.Lawyers.Add(GetDemoLawyer());

//            var controller = new LawyerController(context);
//            var result = controller.GetAllLawyersByID(3) as OkNegotiatedContentResult<Lawyer>;

//            Assert.IsNotNull(result);
//            Assert.AreEqual(3, result.Content.Id);
//        }

//        //[TestMethod]
//        //public void GetProducts_ShouldReturnAllLawyers()
//        //{
//        //    var context = new TestLawyerContext();
//        //    context.Lawyers.Add(new Lawyer { Id = 1, Name = "Demo1" });
//        //    context.Lawyers.Add(new Lawyer { Id = 2, Name = "Demo2" });
//        //    context.Lawyers.Add(new Lawyer { Id = 3, Name = "Demo3" });

//        //    var controller = new LawyerController(context);
//        //    var result = controller.GetAllLawyers() as TestLawyerDTODbSet;

//        //    Assert.IsNotNull(result);
//        //    Assert.AreEqual(3, result.Local.Count);
//        //}

//        [TestMethod]
//        public void DeleteProduct_ShouldReturnOK()
//        {
//            var context = new TestLawyerContext();
//            var item = GetDemoLawyer();
//            context.Lawyers.Add(item);

//            var controller = new LawyerController(context);
//            var result = controller.Delete(3) as OkNegotiatedContentResult<Lawyer>;

//            Assert.IsNotNull(result);
//            Assert.AreEqual(item.Id, result.Content.Id);
//        }

//        Lawyer GetDemoLawyer()
//        {
//            return new Lawyer() { Id = 3, Name = "Demo name" };
//        }
//    }
//}