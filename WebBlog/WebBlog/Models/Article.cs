using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.ComponentModel.DataAnnotations;

namespace WebBlog.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public int AuthorId { get; set; }

        //.Net程序集的的内置特性,不是entity framework的特性，所以，，MVC用户界面验证会自动响应
        //[Required]
        //[MaxLength(500)]
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishTime { get; set; }
        public virtual Author Author { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Comment> Comments { get; set; }
    }
}