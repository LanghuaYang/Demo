using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBlog.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishTime { get; set; }
        public virtual Author Author { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Comment> Comments { get; set; }
    }
}