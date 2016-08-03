using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebBlog.Models
{
    public class WebBlogDBContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}