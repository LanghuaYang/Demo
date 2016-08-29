using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBlog.Models;

namespace WebBlog.Controllers
{
    public class PersonalPageController : Controller
    {
        WebBlogDBContext db = new WebBlogDBContext();
        // GET: PersonalPage
        //PersonalPage/Index?author=xxx
        public ActionResult Index(string author)
        {
            var articlelist = db.Authors.Include("Articles").Include("Author").Single(a => a.Name == author);
            return View(articlelist);
        }

        //PersonalPage/Browse?tag=C#
        public ActionResult Browse(int authorId,string tagname)
        {
            //tagname == "" means to return all the articles of the author
            if (tagname == null)
            {
                var articlelist = from article in db.Articles.Include("Author")
                                  where article.AuthorId == authorId
                                  select article;
                return View(articlelist);
            }
            else 
            {
                var articlelist = from author in db.Authors
                                  join article in db.Articles.Include("Author") on author.AuthorId equals article.AuthorId
                                  from tag in article.Tags
                                  where (author.AuthorId == authorId && tag.Name == tagname)
                                  select (article);
                return View(articlelist);
            }
        }

        public ActionResult Details(int authorId, int articleId)
        {
            var article = db.Articles.Find(articleId);               
            //should open a new tag
            return View(article);
        }

        [ChildActionOnly]
        public ActionResult PersonalPageSideBarTagsMenu(int authorId)
        {
            //select dbo.Authors.AuthorId,Title,T.Name
            //    from dbo.Authors left join dbo.articles on dbo.Authors.AuthorId = 1
            //    inner join dbo.TagArticles as TA  on TA.Article_ArticleId = dbo.articles.ArticleId 
            //    inner join dbo.Tags as T on TA.Tag_TagId = T.TagId;
            //var query =   from author in db.Authors
            //              from article in db.Articles
            //              from tag in db.Tags
            //              where author.AuthorId == authorId
            //              select new WebBlog.ViewModels.PersonalTag() { TagId = tag.TagId, Name = tag.Name, AuthorId = author.AuthorId };
            var query = from article in db.Articles
                        join author in db.Authors on article.AuthorId equals author.AuthorId
                        from tag in article.Tags 
                        where author.AuthorId == authorId
                        group tag by new { tag.TagId,tag.Name} into g
                        select new WebBlog.ViewModels.PersonalTag() { TagId = g.Key.TagId, Name = g.Key.Name, AuthorId = authorId };
            List<WebBlog.ViewModels.PersonalTag> taglist = query.ToList<WebBlog.ViewModels.PersonalTag>();
            //var query = db.Authors.Include("Articles").Include("Tags").Where(a => a.AuthorId == authorId).ToList();

            return PartialView(query);
        }
    }
}