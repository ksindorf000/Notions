using Notions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Notions.Controllers
{
    public class BlogPostController : Controller
    {
        //Create the context to avoid having to use "using" statements
        BlogPostContext db = new BlogPostContext();

        // GET: BlogPost
        public ActionResult Index()
        {
            //List of 3 posts for homepage
            ViewBag.ShortPostList = db.BlogPosts.OrderByDescending(p => p.Created).ToList().Take(3);
            return View();
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // CREATE: BlogPost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body,TeaserText,ImgUrl")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.Created = DateTime.Now;
                db.BlogPosts.Add(blogPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogPost);
        }

        // GET: BlogPost Details
        public ActionResult Details(int id)
        {
            BlogPost blog = db.BlogPosts.First(b => b.Id == id);
            return View(blog);
        }
    }
}