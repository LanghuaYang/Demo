using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBlog.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public List<Article> Articles { get; set; }
    }
}