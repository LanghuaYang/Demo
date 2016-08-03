using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBlog.ViewModels
{
    public class PersonalTag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
    }
}