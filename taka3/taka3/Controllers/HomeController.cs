﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace taka3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

		public ActionResult ProfilePage()
		{
			ViewBag.Message = "Your profile page.";

			return View();
		}

		public ActionResult Hamburger()
		{
			ViewBag.Message = "Your settings page.";

			return View();
		}

    }
}