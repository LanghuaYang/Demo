using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Auckland_High_School.Models;
using Auckland_High_School.ViewModel;

namespace Auckland_High_School.Controllers
{
    public class TeachersController : Controller
    {
        private SchoolDBContext db = new SchoolDBContext();

        // GET: Teachers
        public ActionResult Index()
        {
            var TotalClass = (from c in db.Classes
                              from t in db.Teachers.Where(j => j.classes.Contains(c)).DefaultIfEmpty()
                              select new
                              {
                                  te = t,
                                  cl = c
                              }).GroupBy(x => x.te).Select(x => new
                              {
                                  TeaId = x.Key.TeacherId,
                                  ClassCount = x.Where(g => g.cl != null).Distinct().Count()
                              });

            var TotalSubject = (from s in db.Subjects
                                from c in db.Classes.Where(j => j.SubjectId == s.SubjectId).DefaultIfEmpty()
                                from t in db.Teachers.Where(j => j.classes.Contains(c)).DefaultIfEmpty()
                              select new
                              {
                                  te = t,
                                  su = s
                              }).GroupBy(x => x.te).Select(x => new
                              {
                                  TeaId = x.Key.TeacherId,
                                  SubjectCount = x.Where(g => g.su != null).Distinct().Count()
                              });

            var teachers = from c in TotalClass
                           from s in TotalSubject.Where(j => j.TeaId == c.TeaId).DefaultIfEmpty()
                           select new TeacherViewModel()
                           {
                               TeacherId = c.TeaId,
                               FirstName = db.Teachers.FirstOrDefault(x => x.TeacherId == c.TeaId).FirstName,
                               LastName = db.Teachers.FirstOrDefault(x => x.TeacherId == c.TeaId).LastName,
                               Gender = db.Teachers.FirstOrDefault(x => x.TeacherId == c.TeaId).gender,
                               TotalSubject = s.SubjectCount,
                               TotalClass = c.ClassCount
                           };

            return View(teachers);
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherId,FirstName,LastName,gender")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherId,FirstName,LastName,gender")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
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
