using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auckland_High_School.ViewModel
{
    public class TeacherViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int TotalSubject { get; set; }
        public int TotalClass { get; set; }
    }
}