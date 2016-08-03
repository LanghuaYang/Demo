using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebBlog.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<WebBlogDBContext>
    {
        protected override void Seed(WebBlogDBContext context)
       {
           var authors = new List<Author>
           {
                   new Author() { AuthorId = 1, Name = "Jane Austen" },
                   new Author() { AuthorId = 2, Name = "Charles Dickens" },
                   new Author() { AuthorId = 3, Name = "Miguel de Cervantes" },
                   new Author() { AuthorId = 3, Name = "Laura Yang" }
           };
        

           var tag1 = new Tag() { TagId = 1, Name = "C#" };
           var tag2 = new Tag() { TagId = 2, Name = "JAVA" };
           var tag3 = new Tag() { TagId = 3, Name = "MVC" };
           var tag4 = new Tag() { TagId = 4, Name = "PYTHON" };

           context.Tags.Add(tag1);
           context.Tags.Add(tag2);
           context.Tags.Add(tag3);
           context.Tags.Add(tag4);


           var article1 = new Article { ArticleId = 1, Author = authors.Single(a => a.Name == "Jane Austen"),Title = "The Best Of Men At Work", Body = "123214354364565768769", PublishTime = new DateTime(2015, 12, 23, 02, 07, 12), Tags = new List<Tag>() };
           var article2 = new Article { ArticleId = 2, Author = authors.Single(a => a.Name == "Miguel de Cervantes"), Title = "A Copland Celebration, Vol. I", Body = "123214354364565768769", PublishTime = new DateTime(2015, 12, 23, 03, 07, 12), Tags = new List<Tag>() };
           var article3 = new Article { ArticleId = 3, Author = authors.Single(a => a.Name == "Miguel de Cervantes"), Title = "A Copland Celebration, Vol. 2", Body = "123214354364565768769", PublishTime = new DateTime(2015, 12, 23, 04, 07, 12), Tags = new List<Tag>() };
           var article4 = new Article { ArticleId = 4, Author = authors.Single(a => a.Name == "Jane Austen"), Title = "A Copland Celebration, Vol. 3", Body = "123214354364565768769", PublishTime = new DateTime(2015, 12, 23, 05, 07, 12), Tags = new List<Tag>() };
           var article5 = new Article { ArticleId = 5, Author = authors.Single(a => a.Name == "Miguel de Cervantes"), Title = "A Copland Celebration, Vol. 4", Body = "123214354364565768769", PublishTime = new DateTime(2015, 12, 23, 06, 07, 12), Tags = new List<Tag>() };
           var article6 = new Article { ArticleId = 6, Author = authors.Single(a => a.Name == "Laura Yang"), Title = "A Copland Celebration, Vol. 5", Body = "123214354364565768769", PublishTime = new DateTime(2015, 12, 23, 07, 07, 12), Tags = new List<Tag>() };
           var article7 = new Article { ArticleId = 7, Author = authors.Single(a => a.Name == "Laura Yang"), Title = "A Copland Celebration, Vol. 6", Body = "123214354364565768769", PublishTime = new DateTime(2015, 12, 23, 08, 07, 12), Tags = new List<Tag>() };
           var article8 = new Article { ArticleId = 8, Author = authors.Single(a => a.Name == "Miguel de Cervantes"), Title = "A Copland Celebration, Vol. 7", Body = "123214354364565768769", PublishTime = new DateTime(2015, 12, 23, 09, 07, 12), Tags = new List<Tag>() };

           article1.Tags.Add(tag1);
           article1.Tags.Add(tag2);
           article2.Tags.Add(tag3);
           article2.Tags.Add(tag2);
           article3.Tags.Add(tag1);
           article3.Tags.Add(tag4);
           article4.Tags.Add(tag2);
           article4.Tags.Add(tag3);
           article5.Tags.Add(tag2);
           article5.Tags.Add(tag4);
           article6.Tags.Add(tag1);
           article6.Tags.Add(tag4);
           article7.Tags.Add(tag1);
           article7.Tags.Add(tag3);
           article8.Tags.Add(tag2);
           article8.Tags.Add(tag4);

           context.Articles.Add(article1);
           context.Articles.Add(article2);
           context.Articles.Add(article3);
           context.Articles.Add(article4);
           context.Articles.Add(article5);
           context.Articles.Add(article6);
           context.Articles.Add(article7);
           context.Articles.Add(article8);

            new List<Comment>
            {
                new Comment { body = "The Best Of Men At Work", UserId = 1, IP = "127.2.2.1", ArticleId = 1, CreateTime = new DateTime(2015, 12, 23, 09, 07, 12) },
                new Comment { body = "The Best Of Men At Work", UserId = 2, IP = "127.2.2.1", ArticleId = 2, CreateTime = new DateTime(2015, 12, 23, 09, 07, 12) },
                new Comment { body = "The Best Of Men At Work", UserId = 1, IP = "127.2.2.1", ArticleId = 3, CreateTime = new DateTime(2015, 12, 23, 09, 07, 12) },
                new Comment { body = "The Best Of Men At Work", UserId = 3, IP = "127.2.2.1", ArticleId = 4, CreateTime = new DateTime(2015, 12, 23, 09, 07, 12) },
                new Comment { body = "The Best Of Men At Work", UserId = 5, IP = "127.2.2.1", ArticleId = 5, CreateTime = new DateTime(2015, 12, 23, 09, 07, 12) },
                new Comment { body = "The Best Of Men At Work", UserId = 5, IP = "127.2.2.1", ArticleId = 6, CreateTime = new DateTime(2015, 12, 23, 09, 07, 12) },
                new Comment { body = "The Best Of Men At Work", UserId = 1, IP = "127.2.2.1", ArticleId = 7, CreateTime = new DateTime(2015, 12, 23, 09, 07, 12) },
                new Comment { body = "The Best Of Men At Work", UserId = 2, IP = "127.2.2.1", ArticleId = 8, CreateTime = new DateTime(2015, 12, 23, 09, 07, 12) },
            }.ForEach(a => context.Comments.Add(a));

            context.SaveChanges();
       }
    }
}