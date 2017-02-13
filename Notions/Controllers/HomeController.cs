using Notions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Notions.Controllers
{
    public class HomeController : Controller
    {
        //Create the context to avoid having to use "using" statements
        BlogPostContext db = new BlogPostContext();

        // GET: BlogPost
        public ActionResult Index()
        {
            //List of 3 posts for homepage
            ViewBag.ShortPostList = db.BlogPosts.OrderBy(p => p.Created).ToList().Take(3);
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
    }
}