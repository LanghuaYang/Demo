using AucklandHighSchoolPart2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AucklandHighSchoolPart2.Controllers
{
    public class StudentController : Controller
    {
        // GET: List of Students
        public ActionResult Index()
        {
            using(var db = new AucklandHighSchoolEntities())
            {
                //Declear list of students
                List<StudentViewModel> list = new List<StudentViewModel>();

                //Connect to database and get list
                list = (from s in db.Students
                        join e in db.Enrollments on s.Id equals e.StudentId into box
                        from b in box.DefaultIfEmpty()
                        select new
                        {
                            Student = s,
                            Enrollment = b
                        }).GroupBy(x => new { x.Student }).Select(x => new StudentViewModel
                        {
                            Name = x.Key.Student.FirstName + " " + x.Key.Student.LastName,
                            Gender = x.Key.Student.Gender,
                            EnrolmentCount = x.Where(g => g.Enrollment != null).Distinct().Count()
                        }).ToList();

                //Pass list to front end view
                return View(list);
            }
        }
    }
}