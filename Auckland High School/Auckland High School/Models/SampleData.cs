using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Auckland_High_School.Models
{

    public class SampleData : DropCreateDatabaseIfModelChanges<SchoolDBContext>
    {
        protected override void Seed(SchoolDBContext context)
        {
            var Subjects = new List<Subject>
            {
                new Subject { Name = "Math" },
                new Subject { Name = "English" },
                new Subject { Name = "IT" },
                new Subject { Name = "Physics" },
                new Subject { Name = "Chemistry" },
                new Subject { Name = "Biology" },
            };

            foreach (var s in Subjects)
            {
                context.Subjects.Add(s);
            }

            var Teachers = new List<Teacher>
            {
                new Teacher { FirstName = "FirstName1",LastName="LastName1",gender="Male"},
                new Teacher { FirstName = "FirstName2",LastName="LastName2",gender="Male" },
                new Teacher { FirstName = "FirstName3",LastName="LastName3",gender="Female" },
                new Teacher { FirstName = "FirstName4",LastName="LastName4",gender="Female" },
            };
            //Genre = genres.Single(g => g.Name == "Rock")

            var class1 = new Class { Name = "Maths", subject = Subjects.Single(g => g.Name == "Math"), teacher = Teachers.Single(g => g.FirstName == "FirstName1") };
            var class2 = new Class { Name = "IT", subject = Subjects.Single(g => g.Name == "IT"), teacher = Teachers.Single(g => g.FirstName == "FirstName2") };
            var class3 = new Class { Name = "English", subject = Subjects.Single(g => g.Name == "English"), teacher = Teachers.Single(g => g.FirstName == "FirstName3") };
            var class4 = new Class { Name = "Biology", subject = Subjects.Single(g => g.Name == "Biology"), teacher = Teachers.Single(g => g.FirstName == "FirstName4") };

            context.Classes.Add(class1);
            context.Classes.Add(class2);
            context.Classes.Add(class3);
            context.Classes.Add(class4);

            var student1 = new Student { FirstName = "FirstName1", LastName = "LastName1", gender = "Male", classes = new List<Class>() };
            var student2 = new Student { FirstName = "FirstName2", LastName = "LastName2", gender = "Male", classes = new List<Class>() };
            var student3 = new Student { FirstName = "FirstName3", LastName = "LastName3", gender = "Male", classes = new List<Class>() };
            var student4 = new Student { FirstName = "FirstName4", LastName = "LastName4", gender = "Male", classes = new List<Class>() };
            var student5 = new Student { FirstName = "FirstName5", LastName = "LastName5", gender = "Female", classes = new List<Class>() };
            var student6 = new Student { FirstName = "FirstName6", LastName = "LastName6", gender = "Female", classes = new List<Class>() };
            var student7 = new Student { FirstName = "FirstName7", LastName = "LastName7", gender = "Female", classes = new List<Class>() };
            var student8 = new Student { FirstName = "FirstName8", LastName = "LastName8", gender = "Female", classes = new List<Class>() };
            student1.classes.Add(class1);
            student1.classes.Add(class2);
            student2.classes.Add(class2);
            student2.classes.Add(class3);
            student3.classes.Add(class1);
            student3.classes.Add(class2);
            student4.classes.Add(class3);
            student4.classes.Add(class4);
            student5.classes.Add(class1);
            student5.classes.Add(class2);
            student6.classes.Add(class3);
            student6.classes.Add(class4);
            student7.classes.Add(class1);
            student7.classes.Add(class2);
            student8.classes.Add(class3);
            student8.classes.Add(class4);

            context.Students.Add(student1);
            context.Students.Add(student2);
            context.Students.Add(student3);
            context.Students.Add(student4);
            context.Students.Add(student5);
            context.Students.Add(student6);
            context.Students.Add(student7);
            context.Students.Add(student8);

            context.SaveChanges();
        }
    }
}