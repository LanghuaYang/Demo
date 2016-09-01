using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Auckland_High_School.Models;
using Auckland_High_School.ViewModel;

namespace Auckland_High_School.Controllers
{
    public class SubjectController : Controller
    {
        private SchoolDBContext db = new SchoolDBContext();

        // GET: Subject
        public ActionResult Index()
        {
            var TotalStaff = (from s in db.Subjects
                              from c in db.Classes.Where(j => j.SubjectId == s.SubjectId).DefaultIfEmpty()
                              from t in db.Teachers.Where(j => j.TeacherId == c.TeacherId).DefaultIfEmpty()
                              select new
                              {
                                  su = s,
                                  te = t
                              }).GroupBy(x => x.su).Select(x => new
                              {
                                  SubId = x.Key.SubjectId,
                                  //Staffs = x.Select(g => g.te).ToList(),
                                  StaffCount = x.Where(g => g.te != null).Distinct().Count()
                              });

            var TotalClass = (from s in db.Subjects
                              from c in db.Classes.Where(j => j.SubjectId == s.SubjectId).DefaultIfEmpty()
                              select new
                              {
                                  su = s,
                                  cl = c
                              }).GroupBy(x => x.su).Select(x => new
                              {
                                  SubId = x.Key.SubjectId,
                                  //Classes = x.Select(g => g.cl).ToList(),
                                  ClassCount = x.Where(g => g.cl != null).Distinct().Count()
                              });

            var TotalEnrollment = (from s in db.Subjects
                                   from c in db.Classes.Where(j => j.SubjectId == s.SubjectId).DefaultIfEmpty()
                                   from stu in db.Students.Where(j => j.classes.Contains(c)).DefaultIfEmpty()
                                   select new
                                   {
                                       su = s,
                                       student = stu
                                   }).GroupBy(p => p.su).Select(x => new
                                   {
                                       SubId = x.Key.SubjectId,
                                       //Enrollments = x.Select(g => g.student).ToList(),
                                       EnrollmentCount = x.Where(g => g.student != null).Distinct().Count()
                                   });

            var subjects = (from c in TotalClass
                            join s in TotalStaff on c.SubId equals s.SubId
                            join e in TotalEnrollment on c.SubId equals e.SubId
                            select new SubjectViewModel
                            {
                                SubjectId = c.SubId,
                                Name = db.Subjects.FirstOrDefault(j => j.SubjectId == c.SubId).Name,
                                //Staffs = s.Staffs,
                                //Classes = c.Classes,
                                //Enrollments = e.Enrollments,
                                TotalClass = c.ClassCount,
                                TotalStaff = s.StaffCount,
                                TotalEnrollment = e.EnrollmentCount
                            }).ToList();

            //var viewModel = db.Subject
            //    .Select(x => new SubjectViewModel
            //    {
            //        SubjectId = x.Id,
            //        Subjects = x.Name,
            //        NumberOfStaffs = x.Class.Select(y => y.Teacher.Id).Distinct().Count(),
            //        NumberOfClasses = x.Class.Select(y => y.Id).Distinct().Count(),
            //        NumberOfEnrolments = x.Class.SelectMany(y => y.Enrolment.Select(z => z.Id)).Distinct().Count()
            //    }).ToList();

            return View(subjects);
        }

        // GET: Subject/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            var classes = db.Classes.Where(x => x.SubjectId == id).ToList();

            var enrollments = (from c in db.Classes.Where(x => x.SubjectId == id)
                              from stu in c.students
                              select stu).ToList();

            var teachers = (from c in db.Classes.Where(j => j.SubjectId == id)
                            from t in db.Teachers.Where(j => j.TeacherId == c.TeacherId)
                           select (t)).ToList();

            if (subject == null)
            {
                return HttpNotFound();
            }
            SubjectViewModel s = new SubjectViewModel() {
                Name = subject.Name,
                Classes = classes,
                Enrollments = enrollments,
                Staffs = teachers};
            return View(s);
        }

        // GET: Subject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectId,Name")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subject);
        }

        // GET: Subject/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectId,Name")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        // GET: Subject/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subjects.Find(id);
            //remove the enrollments
            var st = (from c in db.Classes.Where(x => x.SubjectId == id)
                      from stu in db.Students.Where(x => x.classes.Contains(c))
                      select new 
                      { 
                          student = stu, 
                          cla = c 
                      }).GroupBy(x => x.student).Select(x => new
                      {
                          S = x.Key,
                          C = x.Select(g => g.cla)
                      }).ToList();


            if(st.Count() > 0)
            {
                foreach (var item in st)
                {
                    foreach (var j in item.C)
                    {
                        item.S.classes.Remove(j);
                    }
                }
            }
            //remove the classes belongs to the subject
            var cl = db.Classes.Where(x => x.SubjectId == id).ToList();
            if (cl.Count() > 0)
            {
                foreach (var item in cl)
                {
                    cl.Remove(item);
                }
            }
            //remove the subject
            db.Subjects.Remove(subject);
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
