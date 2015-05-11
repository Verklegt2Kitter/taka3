using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using taka3.Models;
using taka3.Services;
using SecurityWebAppTest.Models;

namespace taka3.Controllers
{
    public class HomeController : Controller
    {
		UserService userService = new UserService();

        public ActionResult Index()
        {

			IdentityManager manager = new IdentityManager();


			var user = new ApplicationUser
			{
				UserName = "username",
				Email = "Steve@Jobs.com",
				//PasswordHash = password,
				FirstName = "John",
				LastName = "Smith",
				Country = "Kazakhstan",
				BirthDate = DateTime.Parse("1988-02-05 17:30:00"),
				Gender = "male"
			};

			var temp = manager.GetUser("username");
			if(temp == null)
			{
				manager.CreateUser(user, "123456");
			}



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
        public ActionResult FileUpload(HttpPostedFileBase file, int? postid)
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

				UserPost model = new UserPost();
				model.UserID = User.Identity.GetUserId();
				model.Image = path;
				//.....

				userService.AddPosts(model);
				
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

			IdentityManager manager = new IdentityManager();

	        var userid = User.Identity.GetUserName();

			var user = manager.GetUser(userid);

			var firstname = user.FirstName;	//Skilar firstname

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