using Notions.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            //All blog posts
            ViewBag.PostList = db.BlogPosts.OrderBy(p => p.Created).ToList();
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

        // GET: Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,TeaserText,Body,Author,ImgUrl")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.Created = DateTime.Now;
                db.Entry(blogPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogPost);
        }

    }
}