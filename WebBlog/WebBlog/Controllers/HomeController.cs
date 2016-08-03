using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBlog.Models;

namespace WebBlog.Controllers
{
    public class HomeController : Controller
    {
        WebBlogDBContext db = new WebBlogDBContext();
        public ActionResult Index()
        {
            var articlelist = db.Articles.Take(10).ToList();
            return View(articlelist);
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

        //Home/Browse?tag=C#
        public ActionResult Browse(string tagname)
        {
            var articlelist = db.Tags.Include("Articles").Single(t => t.Name == tagname);
            return View(articlelist);
        }

        [ChildActionOnly]
        public ActionResult SideBarTagsMenu()
        {
            var taglist = db.Tags.ToList();
            return PartialView(taglist);
        }
    }
}