using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore.Models;

namespace MVCMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MVCMusicStoreDBContext db = new MVCMusicStoreDBContext();
        // GET: Store
        public ActionResult Index()
        {
            var genre = db.Genres.ToList();
            return View(genre);
        }
        //Store/Browse?genre=rock
        public ActionResult Browse(string genre)
        {
            var albumlist = db.Genres.Include("Albums").Single(g => g.Name == genre);
            return View(albumlist);
        }

        public ActionResult Details(int id)
        {
            var album = db.Albums.Find(id);
            return View(album);
        }

        // GET: /Store/GenreMenu
        //在 Action 方法上我们增加了 [ChildActionOnly] 标注，这意味着我们仅仅可以通过分部视图来访问这个 Action，
        //这可以防止通过浏览 /Store/GenreMenu 来访问，对于分部视图来说，这不是必须的，
        //但是一个很好的实践，因为我们希望我们的控制器方法被我们希望的方式使用，这里我们还返回了一个分部视图而不是一个普通的视图，
        //这用来告诉视图引擎，不需要对这个视图使用布局，它将会被包含在其他的视图中。
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = db.Genres.ToList();
            return PartialView(genres);
        }
    }
}