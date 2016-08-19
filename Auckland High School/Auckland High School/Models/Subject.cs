using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auckland_High_School.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public virtual List<Class> Classes { get; set; }
    }
}