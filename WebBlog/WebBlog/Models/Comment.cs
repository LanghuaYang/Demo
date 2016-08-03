using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBlog.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ArticleId { get; set; }
        public string body { get; set; }
        public int UserId { get; set; }
        public string IP { get; set; }
        public DateTime CreateTime { get; set; }
        public virtual Article Article { get; set; }
    }
}