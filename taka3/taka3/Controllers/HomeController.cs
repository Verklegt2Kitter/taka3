using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using taka3.Models;

namespace taka3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
			//Sendir á Fréttaveituna(NewsFeed) ef notandi er skráður inn	-Védís
			if (Request.IsAuthenticated)
			{
				return View("NewsFeed");
			}
			else
			{
				return View();
			}
        }

        //steindor gerði fall sem sækir myndir
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Content/images"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                /*using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }*/

            }
            // after successfully uploading redirect the user
            return RedirectToAction("ProfilePage", "Home");
        }

        public ActionResult Groups()
        {
            ViewBag.Message = "Your application groups page.";

            return View();
        }

        public ActionResult NewsFeed()
        {
            ViewBag.Message = "Your newsfeed.";

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

        //fanney gerði heimasíðu hópa
       public ActionResult GroupProfilePage()
        {
            ViewBag.Message = "Group homepage.";

            ApplicationDbContext db = new ApplicationDbContext();

            //1. hvaða hópur --- Fanney, úr fyrirlestri Dabs

            // 2. sækja hópmeðlimi
           var groupMembers = new List<string>();


            var statuses = (from s in db.GroupPosts
                            where groupMembers.Contains(s.UserName)
                            select s).ToList();
            return View();
        }

    }
}