using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBlog.Models;
using System.ComponentModel;

namespace WebBlog.Controllers
{
    public class CommentController : Controller
    {
        WebBlogDBContext db = new WebBlogDBContext();

        [ChildActionOnly]
        // GET: Comment
        public ActionResult Index(int articleId)
        {
            var comments = from article in db.Articles
                           from c in article.Comments
                           where article.ArticleId == articleId
                           select c;
            return PartialView(comments.ToList<Comment>());
        }


        //public ActionResult Create()
        //{
        //    return PartialView();
        //}

         //POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Comment comment)
        {
            //HttpRequest
            //HttpResponse   
            //HttpRuntime
            //HttpApplication
            //System.ComponentModel.Component;
            //System.Web.IHttpModule
            //System.Web.HttpApplication
            //HttpWorkerRequest
            if (ModelState.IsValid)
            {
                comment.CreateTime = System.DateTime.Now;
                comment.IP = Request.UserHostAddress;
                comment.UserName = User.Identity.Name;
                Comment c = new Comment()
                {
                    CommentId = comment.CommentId,
                    Article = db.Articles.Single(a => a.ArticleId == comment.ArticleId),
                    body = comment.body,
                    UserName = comment.UserName,
                    IP = comment.IP,
                    CreateTime = comment.CreateTime,
                };
                db.Comments.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index", "Comment", new { articleId = comment.ArticleId });
            }
            return View();// Json();
        }
    }
}
