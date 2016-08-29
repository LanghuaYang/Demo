using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Auckland_High_School.Models;
using Auckland_High_School.ViewModel;

namespace Auckland_High_School.Controllers
{
    public class ClassController : Controller
    {
        private SchoolDBContext db = new SchoolDBContext();

        // GET: Class
        public ActionResult Index()
        {
            var TotalEnrollment = (from c in db.Classes
                                   from stu in db.Students.Where(j => j.classes.Contains(c)).DefaultIfEmpty()
                                   select new
                                   {
                                       cla = c,
                                       student = stu
                                   }).GroupBy(x => x.cla).Select(x => new
                                   {
                                       ClaId = x.Key.ClassId,
                                       EnrollmentCount = x.Where(g => g.student != null).Distinct().Count()
                                   });

            var classes = from e in TotalEnrollment
                          from c in db.Classes.Where(j => j.ClassId == e.ClaId).DefaultIfEmpty()
                          from t in db.Teachers.Where(j => j.classes.Contains(c)).DefaultIfEmpty()
                          from s in db.Subjects.Where(j => j.Classes.Contains(c)).DefaultIfEmpty()
                          select new ClassViewModel()
                          {
                              ClassId = e.ClaId,
                              Name = c.Name,
                              Subject = s.Name,
                              FirstName = t.FirstName,
                              LastName = t.LastName,
                              TotalEnrollment = e.EnrollmentCount
                          };

            return View(classes);
        }

        // GET: Class/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // GET: Class/Create
        public ActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "Name");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "FirstName");
            return View();
        }

        // POST: Class/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassId,TeacherId,SubjectId,Name")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(@class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "Name", @class.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "FirstName", @class.TeacherId);
            return View(@class);
        }

        // GET: Class/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "Name", @class.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "FirstName", @class.TeacherId);
            return View(@class);
        }

        // POST: Class/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassId,TeacherId,SubjectId,Name")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "Name", @class.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "FirstName", @class.TeacherId);
            return View(@class);
        }

        // GET: Class/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class @class = db.Classes.Find(id);
            db.Classes.Remove(@class);
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
