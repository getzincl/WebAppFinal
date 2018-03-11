using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTHeadBrewery.Controllers;

namespace MTHeadBrewery.Tests.Controllers
{
    [TestClass]
    public class BeerContrllerTest
    {
        [TestMethod]
        public void TestDetailsNotNull()
        {
            // Arrange
            BeerController controller = new BeerController();

            // Act
            ActionResult result = controller.Details(5) as ActionResult;

            // Assert
            Assert.IsNotNull(result);


        }

        [TestMethod]
        public void BeerIndex()
        {
            // Arrange
            BeerController controller = new BeerController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCreateNotNull()
        {
            // Arrange
            BeerController controller = new BeerController();

            // Act
            ActionResult result = controller.Create() as ActionResult;

            // Assert
            Assert.IsNotNull(result);


        }

        [TestMethod]
        public void TestEditNotNull()
        {
            // Arrange
            BeerController controller = new BeerController();

            // Act
            ActionResult result = controller.Edit(5) as ActionResult;

            // Assert
            Assert.IsNotNull(result);


        }

       

    }
}
