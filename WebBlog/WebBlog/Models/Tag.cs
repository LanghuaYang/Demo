using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBlog.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public List<Article> Articles { get; set; }
    }
}