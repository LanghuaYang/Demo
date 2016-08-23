using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBlog.Models;
using WebBlog.ViewModels;

namespace WebBlog.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private WebBlogDBContext db = new WebBlogDBContext();

        // GET: Post/Create
        public ActionResult Create()
        {
            var tags = db.Tags.Select(c => new
            TagViewModel()
            {
                TagId = c.TagId,
                Name = c.Name
            }).ToList();
            ViewBag.Tags = (List<TagViewModel>)tags;
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewPost post) 
        {
            if (ModelState.IsValid)
            {
                var article = new Article() { 
                Title = post.Title,
                Body = post.Body,};
                // add author 
                article.Author = db.Authors.SingleOrDefault(n => n.Name == User.Identity.Name);
                if (article.Author == null)
                {
                    var author = new Author() { Name = User.Identity.Name };
                    db.Authors.Add(author);
                    article.Author = author;
                }
                article.PublishTime = System.DateTime.Now;
                //add tags
                if (post.tags != null)
                {
                    article.Tags = new List<Tag>();
                    foreach (var tagid in post.tags)
                    {
                        var tag = db.Tags.SingleOrDefault(n => n.TagId == tagid);
                        article.Tags.Add(tag);
                    }
                }
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index", "PersonalPage", new { author = User.Identity.Name });
            }

            ViewBag.Tags = new MultiSelectList(db.Tags, "TagId", "Name");
            return View();
        }


        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", article.AuthorId);
            return View(article);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleId,AuthorId,Title,Body,PublishTime")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", article.AuthorId);
            return View(article);
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
