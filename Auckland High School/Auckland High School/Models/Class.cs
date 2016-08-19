using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auckland_High_School.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public Teacher teacher { get; set; }
        public Subject subject { get; set; }
        public virtual List<Student> students { get; set; }
    }
}