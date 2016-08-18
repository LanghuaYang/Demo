using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            //var query = from article in db.Articles
            //            from tag in article.Tags
            //            where article.ArticleId == 2
            //            select new {article.ArticleId,article.Title,tag.TagId,tag.Name};
            //testing();
            System.Linq.Expressions.Expression<Func<int, bool>> lambda = num => num >= 5;
            return View(articlelist);
        }

        private void testing()
        {

            //多对多
            //新建article 新建tag
            //var article = new Article() { Author = db.Authors.Single(a => a.Name == "Jane Austen"), Title = "article1 testing", Body = "123214354364565768769123214354364565768769123214354364565768769", PublishTime = new DateTime(2015, 12, 23, 02, 07, 12)};
            //var tag = new Tag() {Name = "Embedded" ,Articles = new List<Article>()};
            //tag.Articles.Add(article);
            //db.Tags.Add(tag);

            //新建article 已存在tag
            //var tag = new Tag { TagId = 2, Articles = new List<Article>() };
            //db.Tags.Attach(tag);
            //var article = new Article() { Author = db.Authors.Single(a => a.Name == "Jane Austen"), Title = "article2 testing", Body = "123214354364565768769123214354364565768769123214354364565768769", PublishTime = new DateTime(2015, 12, 23, 02, 07, 12) };
            //tag.Articles.Add(article);

            ////已存在article 已存在tag
            //var tag = new Tag { TagId = 2, Articles = new List<Article>() };
            //db.Tags.Attach(tag);
            //var article = new Article() { ArticleId = 3; };
            //db.Articles.Attach(article);
            //tag.Articles.Add(article);

            //删除已存在article和已存在tag的relationship
            //var tag = db.Tags.Include("Articles").Single(t => t.TagId == 6); // load the existing articles

            //var article = tag.Articles
            //    .Single(a => a.ArticleId == 10); // query in memory, no DB query

            //tag.Articles.Remove(article);


            //db.SaveChanges();
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