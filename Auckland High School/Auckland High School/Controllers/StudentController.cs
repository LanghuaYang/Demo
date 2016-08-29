using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Auckland_High_School.Models;
using Auckland_High_School.ViewModel;

namespace Auckland_High_School.Controllers
{
    public class StudentController : Controller
    {
        private SchoolDBContext db = new SchoolDBContext();

        // GET: Student
        public ActionResult Index()
        {
            var TotalEnrollment = (from c in db.Classes
                                   from stu in db.Students.Where(j => j.classes.Contains(c)).DefaultIfEmpty()
                                   select new
                                   {
                                       cla = c,
                                       student = stu
                                   }).GroupBy(x => x.student).Select(x => new
                                   {
                                       StuId = x.Key.StudentId,
                                       EnrollmentCount = x.Where(g => g.cla != null).Distinct().Count()
                                   });

            var students = from s in TotalEnrollment
                           select new StudentViewModel()
                           {
                               StudentId = s.StuId,
                               FirstName = db.Students.FirstOrDefault(x => x.StudentId == s.StuId).FirstName,
                               LastName = db.Students.FirstOrDefault(x => x.StudentId == s.StuId).LastName,
                               Gender = db.Students.FirstOrDefault(x => x.StudentId == s.StuId).gender,
                               TotalEnrollment = s.EnrollmentCount
                           };
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FirstName,LastName,gender")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,FirstName,LastName,gender")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
