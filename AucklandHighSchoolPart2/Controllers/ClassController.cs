using AucklandHighSchoolPart2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AucklandHighSchoolPart2.Controllers
{
    public class ClassController : Controller
    {
        // GET: List of Classes
        public ActionResult Index()
        {
            using (var db = new AucklandHighSchoolEntities())
            {
                //Declear list of classes
                List<ClassViewModel> list = new List<ClassViewModel>();

                //Get list of subject names
                var subjectName = (from c in db.Classes
                                   join s in db.Subjects
                                       on c.SubjectId equals s.Id into box
                                   from b in box.DefaultIfEmpty()
                                   select new
                                   {
                                       Id = c.Id,
                                       ClassName = c.Name,
                                       SubjectName = b == null ? "" : b.Name
                                   });

                //Get list of teacher names
                var teacherName = (from c in db.Classes
                                   join t in db.Teachers
                                       on c.TeacherId equals t.Id into box
                                   from b in box.DefaultIfEmpty()
                                   select new
                                   {
                                       Id = c.Id,
                                       TeacherName = (b == null) ? "" : b.FirstName + " " + b.LastName
                                   });

                //Get number of enrolments belong to each class
                var enrollmentCount = (from c in db.Classes
                                       join e in db.Enrollments
                                           on c.Id equals e.ClassId into box
                                       from b in box.DefaultIfEmpty()
                                       select new
                                       {
                                           Id = c.Id,
                                           Enrollment = b
                                       }).GroupBy(x => new { x.Id }).Select(x => new
                                       {
                                           Id = x.Key.Id,
                                           EnrollmentCount = x.Where(g => g.Enrollment != null).Distinct().Count()
                                       });

                //Join three above list to get final list by comparing class ids
                list = (from s in subjectName
                        join e in enrollmentCount on s.Id equals e.Id
                        join t in teacherName on s.Id equals t.Id
                        select new ClassViewModel
                        {
                            ClassName = s.ClassName,
                            TeacherName = t.TeacherName,
                            SubjectName = s.SubjectName,
                            EnrolmentCount = e.EnrollmentCount
                        }).ToList();

                //Pass list to front end view
                return View(list);
            }
        }
    }
}