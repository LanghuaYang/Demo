using AucklandHighSchoolPart2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AucklandHighSchoolPart2.Controllers
{
    public class TeacherController : Controller
    {
        // GET: List of Teachers
        public ActionResult Index()
        {
            using (var db = new AucklandHighSchoolEntities())
            {
                //Declear list of teachers
                List<TeacherViewModel> list = new List<TeacherViewModel>();

                //Get number of classes each teacher teaches
                var classCount = (from t in db.Teachers
                                  join c in db.Classes
                                    on t.Id equals c.TeacherId into box
                                  from b in box.DefaultIfEmpty()
                                  select new
                                  {
                                      Teacher = t,
                                      Class = b
                                  }).GroupBy(x => new { x.Teacher }).Select(x => new {
                                      Id = x.Key.Teacher.Id,
                                      Name = x.Key.Teacher.FirstName + " " + x.Key.Teacher.LastName,
                                      Gender = x.Key.Teacher.Gender,
                                      ClassCount = x.Where(g => g.Class != null).Distinct().Count()
                                  });

                //Get number of subjects each teacher teaches
                var subjectCount = (from t in db.Teachers
                                    join c in db.Classes
                                      on t.Id equals c.TeacherId into box
                                    from b in box.DefaultIfEmpty()
                                    join s in db.Subjects
                                    on b.SubjectId equals s.Id into otherBox
                                    from o in otherBox.DefaultIfEmpty()
                                    select new
                                    {
                                        Teacher = t,
                                        Subject = o
                                    }).GroupBy(x => new { x.Teacher }).Select(x => new {
                                        Id = x.Key.Teacher.Id,
                                        SubjectCount = x.Where(g => g.Subject != null).Distinct().Count()
                                    });

                //Join two above list to get final list by comparing teacher ids
                list = (from c in classCount
                        join s in subjectCount on c.Id equals s.Id
                        select new TeacherViewModel
                        {
                            Name = c.Name,
                            Gender = c.Gender,
                            SubjectCount = s.SubjectCount,
                            ClassCount = c.ClassCount
                        }).ToList();

                //Pass list to front end view
                return View(list);
            }
        }
    }
}