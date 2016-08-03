namespace WebBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        Title = c.String(),
                        Body = c.String(),
                        PublishTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        body = c.String(),
                        UserId = c.Int(nullable: false),
                        IP = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.TagArticles",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Article_ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Article_ArticleId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.Article_ArticleId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Article_ArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagArticles", "Article_ArticleId", "dbo.Articles");
            DropForeignKey("dbo.TagArticles", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "AuthorId", "dbo.Authors");
            DropIndex("dbo.TagArticles", new[] { "Article_ArticleId" });
            DropIndex("dbo.TagArticles", new[] { "Tag_TagId" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropIndex("dbo.Articles", new[] { "AuthorId" });
            DropTable("dbo.TagArticles");
            DropTable("dbo.Tags");
            DropTable("dbo.Comments");
            DropTable("dbo.Authors");
            DropTable("dbo.Articles");
        }
    }
}
