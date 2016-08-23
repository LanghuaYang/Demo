using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBlog.ViewModels
{
    public class NewPost
    {
        //"ArticleId,AuthorId,Title,Body,PublishTime,Tags")
        //public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<int> tags { get; set; }
    }
}