using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auckland_High_School.ViewModel
{
    public class SubjectViewModel
    {
        public string Name { get; set; }

        [System.ComponentModel.DefaultValue(0)]
        public int TotalStaff { get; set; }

        [System.ComponentModel.DefaultValue(0)]
        public int TotalClass { get; set; }

        [System.ComponentModel.DefaultValue(0)]
        public int TotalEnrollment { get; set; }
    }
}