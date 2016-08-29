using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auckland_High_School.Models;

namespace Auckland_High_School.ViewModel
{
    public class SubjectViewModel
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }

        public List<Teacher> Staffs {get;set;}
        public int TotalStaff { get; set; }

        public List<Class> Classes { get; set; }
        public int TotalClass { get; set; }

        public List<Student> Enrollments { get; set; }
        public int TotalEnrollment { get; set; }
    }
}