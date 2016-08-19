using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auckland_High_School.Models;

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
            var subjects = db.Subjects.ToList();
            return View(subjects);
        }

        public ActionResult StudentList()
        {
            var students = db.Students.ToList();
            return View(students);
        }

        public ActionResult TeacherList()
        {
            var teachers = db.Teachers.ToList();
            return View(teachers);
        }

        public ActionResult ClassList()
        {
            var classes = db.Classes.ToList();
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