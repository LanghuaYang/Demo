using AucklandHighSchoolPart2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AucklandHighSchoolPart2.Controllers
{
    public class SubjectController : Controller
    {
        // GET: List of Subjects
        public ActionResult Index()
        {
            using (var db = new AucklandHighSchoolEntities())
            {
                //Declear list of subjects
                List<SubjectViewModel> list = new List<SubjectViewModel>();

                //Get number of classes belong to each subject
                var classCount = (from s in db.Subjects
                                  join c in db.Classes
                                 on s.Id equals c.SubjectId into box
                                  from b in box.DefaultIfEmpty()
                                  select new
                                  {
                                      Subject = s,
                                      Class = b
                                  }).GroupBy(x => new { x.Subject }).Select(x => new {
                                      Id = x.Key.Subject.Id,
                                      Name = x.Key.Subject.Name,
                                      ClassCount = x.Where(g => g.Class != null).Distinct().Count()
                                  });

                //Get number of teachers belong each subject
                var staffCount = (from s in db.Subjects
                                  join c in db.Classes
                                   on s.Id equals c.SubjectId into box
                                  from b in box.DefaultIfEmpty()
                                  join t in db.Teachers
                                    on b.TeacherId equals t.Id into otherBox
                                  from o in otherBox.DefaultIfEmpty()
                                  select new
                                  {
                                      Subject = s,
                                      Teacher = o
                                  }).GroupBy(x => new { x.Subject }).Select(x => new {
                                      Id = x.Key.Subject.Id,
                                      StaffCount = x.Where(g => g.Teacher != null).Distinct().Count()
                                  });

                //Get number of enrolments belong each subject
                var enrollmentCount = (from s in db.Subjects
                                       join c in db.Classes
                                        on s.Id equals c.SubjectId into box
                                       from b in box.DefaultIfEmpty()
                                       join e in db.Enrollments
                                       on b.Id equals e.ClassId into otherBox
                                       from o in otherBox.DefaultIfEmpty()
                                       select new
                                       {
                                           Subject = s,
                                           Enrollment = o
                                       }).GroupBy(x => new { x.Subject }).Select(x => new {
                                           Id = x.Key.Subject.Id,
                                           EnrollmentCount = x.Where(g => g.Enrollment != null).Distinct().Count()
                                       });

                //Join three above list to get final list by comparing subject ids
                list = (from c in classCount
                        join s in staffCount on c.Id equals s.Id
                        join e in enrollmentCount on c.Id equals e.Id
                        select new SubjectViewModel
                        {
                            Name = c.Name,
                            ClassCount = c.ClassCount,
                            StaffCount = s.StaffCount,
                            EnrolmentCount = e.EnrollmentCount
                        }).ToList();

                //Pass list to front end view
                return View(list);
            }
        }
    }
}