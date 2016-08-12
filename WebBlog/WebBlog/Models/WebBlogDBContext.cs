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

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
    //    //modelBuilder.Entity<Article>().ToTable("Species");
    //    modelBuilder.Entity <Article> ().Property(t => t.Title).IsRequired();
    //    modelBuilder.Entity <Article> ().Property(t => t.Title).HasMaxLength(250);
    //    modelBuilder.Entity<Article>().Property(t => t.Body).IsMaxLength();

    //    //第二种方法是如果你有很多配置需要执行,OnModelCreating 可能很快不堪重负(代码太多)。应该使用位于EntityTypeConfiguration的实体类来分组配置
    //    //在OnModelCreating方法内部的时候，由DbModelBuilder开始，后面跟着Entity方法来确定哪个实体进行配置。
    //    //在EntityConfiguration类中，是由继承于EntityTypeConfiguration类的类开始的，这里的实体类型已经指定
    //    //modelBuilder.Configurations.Add(new ArticleConfiguration());
    //    //public class ArticleConfiguration: EntityTypeConfiguration <Article> 
    //    //{
    //    //    public ArticleConfiguration() 
    //    //    {
    //    //        Property(t = >t.Name).IsRequired();
    //    //    }
    //    //}
            
    //}
    }
}