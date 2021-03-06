﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using taka3;
using taka3.Controllers;

namespace taka3.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Groups()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Groups() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void NewsFeed()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.NewsFeed() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
