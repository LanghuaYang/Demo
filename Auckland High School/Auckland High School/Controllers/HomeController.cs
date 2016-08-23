using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auckland_High_School.Models;
using Auckland_High_School.ViewModel;

namespace Auckland_High_School.Controllers
{
    public class HomeController : Controller
    {
        SchoolDBContext db = new SchoolDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SubjectList()
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
                                  StaffCount = x.Where(g => g.te != null).Distinct().Count()
                              });

            var TotalClass = (from s in db.Subjects
                              from c in db.Classes.Where(j => j.SubjectId == s.SubjectId).DefaultIfEmpty()  
                              select new
                              {
                                  su = s,
                                  cl = c
                              }).GroupBy(x => x.su).Select(x => new{ 
                                SubId = x.Key.SubjectId,
                                ClassCount = x.Where(g => g.cl != null).Distinct().Count()
                              });

            var TotalEnrollment = (from s in db.Subjects
                                   from c in db.Classes.Where(j => j.SubjectId == s.SubjectId).DefaultIfEmpty()  
                                   from stu in db.Students.Where(j => j.classes.Contains(c)).DefaultIfEmpty()  
                                   select new
                                   {
                                       su = s,
                                       student = stu
                                   }).GroupBy(x => x.su).Select(x => new{
                                       SubId = x.Key.SubjectId,
                                       EnrollmentCount = x.Where(g => g.student != null).Distinct().Count()
                                   });

            var subjects = (from c in TotalClass
                            join s in TotalStaff on c.SubId equals s.SubId
                            join e in TotalEnrollment on c.SubId equals e.SubId
                            select new SubjectViewModel
                            {
                                Name = db.Subjects.FirstOrDefault(j => j.SubjectId == c.SubId).Name,
                                TotalClass = c.ClassCount,
                                TotalStaff = s.StaffCount,
                                TotalEnrollment = e.EnrollmentCount
                            }).ToList();
                           
            return View(subjects);
        }

        public ActionResult StudentList()
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
                           select new StudentViewModel(){
                             FirstName = db.Students.FirstOrDefault(x=> x.StudentId == s.StuId).FirstName,
                             LastName = db.Students.FirstOrDefault(x => x.StudentId == s.StuId).LastName,
                             Gender = db.Students.FirstOrDefault(x => x.StudentId == s.StuId).gender,
                             TotalEnrollment = s.EnrollmentCount
                           };
            return View(students);
        }

        public ActionResult TeacherList()
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
                               FirstName = db.Teachers.FirstOrDefault(x => x.TeacherId == c.TeaId).FirstName,
                               LastName = db.Teachers.FirstOrDefault(x => x.TeacherId == c.TeaId).LastName,
                               Gender = db.Teachers.FirstOrDefault(x => x.TeacherId == c.TeaId).gender,
                               TotalSubject = s.SubjectCount,
                               TotalClass = c.ClassCount
                           };

            return View(teachers);
        }

        public ActionResult ClassList()
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
                              Name = c.Name,
                              Subject = s.Name,
                              FirstName = t.FirstName,
                              LastName = t.LastName,
                              TotalEnrollment = e.EnrollmentCount
                          };

            return View(classes);
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
    }
}