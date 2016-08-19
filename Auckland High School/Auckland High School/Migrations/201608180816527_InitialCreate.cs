namespace Auckland_High_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        gender = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        gender = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Class_ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Class_ClassId })
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.Class_ClassId, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Class_ClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Classes", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.StudentClasses", "Class_ClassId", "dbo.Classes");
            DropForeignKey("dbo.StudentClasses", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.StudentClasses", new[] { "Class_ClassId" });
            DropIndex("dbo.StudentClasses", new[] { "Student_StudentId" });
            DropIndex("dbo.Classes", new[] { "SubjectId" });
            DropIndex("dbo.Classes", new[] { "TeacherId" });
            DropTable("dbo.StudentClasses");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
        }
    }
}
