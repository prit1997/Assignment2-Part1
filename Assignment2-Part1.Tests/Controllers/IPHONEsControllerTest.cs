using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment2_Part1.Controllers;
using Assignment2_Part1.Models;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System.Web.Mvc;

namespace Assignment2_Part1.Tests.Controllers
{
    [TestClass]
    public class IPHONEsControllerTest
    {
        IPHONEsController controller;
        Mock<IIPHONEsRepository> mock;
        List<IPHONE> iPHONE;

        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange
            mock = new Mock<IIPHONEsRepository>();

            // Mock the IPHONE Data
            iPHONE = new List<IPHONE>
            {
                new IPHONE { PRODUCT_ID = 1, PRODUCT_NAME = "IPhone 8", PRODUCT_SERIES ="S"},
                new IPHONE { PRODUCT_ID = 2, PRODUCT_NAME = "Iphone 7", PRODUCT_SERIES = "S" },
                new IPHONE { PRODUCT_ID = 3, PRODUCT_NAME = "Iphone 5", PRODUCT_SERIES ="SE"}
            };

            // populate the mock object with our sample data
            mock.Setup(m => m.iPHONEs).Returns(iPHONE.AsQueryable());

            // Pass the mock to 2nd constructor
            controller = new IPHONEsController(mock.Object);

        }

        [TestMethod]
        public void IndexViewLoads()
        {
            // Arrange
           
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexReturnsIPHONE()
        {
            // Act

            
            // call Index, set result to an Iphone List as specified in Index's Model
            var actual = (List<IPHONE>)controller.Index().Model;

            // Assert


            // check if the list returned in the view matches the list we passed in to the mock
            CollectionAssert.AreEqual(iPHONE, actual);
        }

        [TestMethod]
        public void DetailsValidIPHONE()
        {
            // Act
            var actual = (IPHONE)controller.Details(1).Model;

            // Assert
            Assert.AreEqual(iPHONE.ToList()[0], actual);
        }

        [TestMethod]
        public void DetailsInvalidIPHONE()
        {
            // Act
            var actual = (IPHONE)controller.Details(11111).Model;

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void DetailsInvalidNoId()
        {
            // Arrange
            int id = 0;

            // Act
            var actual = controller.Details(id);

            // Assert
            Assert.AreEqual("Error", actual.ViewName);
        }





        // GET: Edit
        [TestMethod]
        public void EditIPhoneValid()
        {
            // ACT
            var actual = (IPHONE)controller.Edit(1).Model;

            // ASSERT
            Assert.AreEqual(iPHONE.ToList()[0], actual);
        }

        [TestMethod]
        public void EditInvalidNoProductId()
        {
            //arrange
            int? id = null;

            //act
            var actual = (ViewResult)controller.Edit(id);

            //assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void EditInvalidiPHONEId()
        {
            // Act
            ViewResult result = controller.Edit(-314) as ViewResult;

            // Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        // GET: Delete
        [TestMethod]
        public void DeleteValidiphone()
        {
            // Act            
            var actual = (IPHONE)controller.Delete(1).Model;

            // Assert            
            Assert.AreEqual(iPHONE.ToList()[0], actual);
        }

        // Delete invalid ID test
        [TestMethod]
        public void DeleteInvalidiphoneId()
        {
            // Arrange
            int id = 87656765;

            // Act
            ViewResult actual = (ViewResult)controller.Delete(id);

            // Assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DeleteInvalidNoId()
        {
            // arrange           
            int? id = null;

            // act           
            ViewResult actual = controller.Delete(id);

            // assert           
            Assert.AreEqual("Error", actual.ViewName);
        }

        // POST: Create
        [TestMethod]
        public void CreateValidiphone()
        {
            // arrange
            IPHONE iPhone = new IPHONE
            {
                PRODUCT_ID = 12,
                PRODUCT_NAME = "IPhone 12",
                PRODUCT_SERIES = "S"
            };

            // act
            RedirectToRouteResult actual = (RedirectToRouteResult)controller.Create(iPhone);

            // assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }

        [TestMethod]
        public void CreateInvalidiphone()
        {
            // arrange
            controller.ModelState.AddModelError("key", "error message");

            IPHONE iPhone = new IPHONE
            {
                 PRODUCT_ID = 1,
                PRODUCT_NAME = "IPhone 8",
                PRODUCT_SERIES = "S"
            };

            // act - cast the return type as ViewResult
            ViewResult actual = (ViewResult)controller.Create(iPhone);

            // assert
            Assert.AreEqual("Create", actual.ViewName);
          
        }

        // POST: Edit
        [TestMethod]
        public void EditValidiphone()
        {
            // arrange
            IPHONE iPhone = iPHONE.ToList()[0];

            // act
            RedirectToRouteResult actual = (RedirectToRouteResult)controller.Edit(iPhone);

            // assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }

        [TestMethod]
        public void EditInvalidiphone()
        {
            // arrange
            controller.ModelState.AddModelError("key", "error message");

            IPHONE iPhone = new IPHONE
            {
                    PRODUCT_ID = 1,
                    PRODUCT_NAME = "IPhone 8",
                    PRODUCT_SERIES = "S"
            };

            // act - cast the return type as ViewResult
            ViewResult actual = (ViewResult)controller.Edit(iPhone);

            // assert
            Assert.AreEqual("Edit", actual.ViewName);
            
        }

        // POST: DeleteConfirmed
        [TestMethod]
        public void DeleteConfirmedValidiphone()
        {
            // Act            
            RedirectToRouteResult actual = (RedirectToRouteResult)controller.DeleteConfirmed(1);

            // Assert            
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }

        // Delete invalid ID test
        [TestMethod]
        public void DeleteConfirmedInvalidiphoneId()
        {
            // Arrange
            int id = 87656765;

            // Act
            ViewResult actual = (ViewResult)controller.DeleteConfirmed(id);

            // Assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedInvalidNoId()
        {
            // arrange           
            int? id = null;

            // act           
            ViewResult actual = (ViewResult)controller.DeleteConfirmed(id);

            // assert           
            Assert.AreEqual("Error", actual.ViewName);
        }

    }
}
