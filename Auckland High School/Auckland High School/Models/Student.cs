using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auckland_High_School.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string gender { get; set; }
        public virtual List<Class> classes { get; set; }
    }
}