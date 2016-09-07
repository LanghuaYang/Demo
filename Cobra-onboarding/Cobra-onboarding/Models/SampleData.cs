using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Cobra_onboarding.Models
{
    public class SampleData : IDatabaseInitializer<CobraDBContext>
    {
        public void InitializeDatabase(CobraDBContext context)
        {
            var people = new List<Person>
            {
                new Person { Name = "Math" ,Address1 = "12 preston ave", Address2 = "950a new north road", City = "Auckland"},
                new Person { Name = "English" ,Address1 = "12 preston ave", Address2 = "950a new north road", City = "Auckland"},
                new Person { Name = "IT" ,Address1 = "12 preston ave", Address2 = "950a new north road", City = "Auckland"},
                new Person { Name = "Physics" ,Address1 = "12 preston ave", Address2 = "950a new north road", City = "Auckland"},
                new Person { Name = "Chemistry" ,Address1 = "12 preston ave", Address2 = "950a new north road", City = "Auckland"},
                new Person { Name = "Biology" ,Address1 = "12 preston ave", Address2 = "950a new north road", City = "Auckland"}
            };

            foreach (var p in people)
            {
                context.People.Add(p);
            }

            var orhs = new List<OrderHeader>()
            {
                new OrderHeader { OrderDate = new DateTime(2012-12-03-9-40-50), Person = people.Single(g => g.Name == "Math")},
                new OrderHeader { OrderDate = new DateTime(2011,11,08,9,55,02), Person = people.Single(g => g.Name == "IT")},
                new OrderHeader { OrderDate = new DateTime(2014,02,13,9,11,10), Person = people.Single(g => g.Name == "Biology")},
                new OrderHeader { OrderDate = new DateTime(2016,10,03,19,30,50), Person = people.Single(g => g.Name == "Biology")},
                new OrderHeader { OrderDate = new DateTime(2014,02,13,9,10,10), Person = people.Single(g => g.Name == "English")},
                new OrderHeader { OrderDate = new DateTime(2016,10,03,19,30,51), Person = people.Single(g => g.Name == "Physics")},
                new OrderHeader { OrderDate = new DateTime(2014,02,13,9,10,11), Person = people.Single(g => g.Name == "Chemistry")},
                new OrderHeader { OrderDate = new DateTime(2016,10,13,19,30,50), Person = people.Single(g => g.Name == "Physics")},
                new OrderHeader { OrderDate = new DateTime(2014,02,23,19,10,10), Person = people.Single(g => g.Name == "English")},
                new OrderHeader { OrderDate = new DateTime(2016,11,23,19,36,50), Person = people.Single(g => g.Name == "Chemistry")}
            };

            foreach(var o in orhs)
            {
                context.OrderHeaders.Add(o);
            }

            var products = new List<Product>()
            {
                new Product { Name="cola", Price = 2.5},
                new Product { Name="L&P", Price = 3.5},
                new Product { Name="mama", Price = 2.7},
                new Product { Name="Tiger", Price = 4.1},
                new Product { Name="V", Price = 5.5},
                new Product { Name="coconut", Price = 8.0},
                new Product { Name="eco", Price = 7.5},
                new Product { Name="dish washing", Price = 5.5},
                new Product { Name="milk", Price = 2.2},
                new Product { Name="cheese", Price = 12.15}
            };
            foreach(var p in products)
            {
                context.Products.Add(p);
            }

            var ordes = new List<OrderDetail>()
            {
                new OrderDetail { OrderHeader = orhs.SingleOrDefault(g => g.OrderDate == new DateTime(2009, 8, 1, 12, 0, 0)),Product = products.SingleOrDefault(p => p.Name == "cola")},
                new OrderDetail { OrderHeader = orhs.SingleOrDefault(g => g.OrderDate == new DateTime(2011,11,08,9,55,02)),Product = products.SingleOrDefault(p => p.Name == "L&P")},
                new OrderDetail { OrderHeader = orhs.SingleOrDefault(g => g.OrderDate == new DateTime(2014,02,13,9,11,10)),Product = products.SingleOrDefault(p => p.Name == "mama")},
                new OrderDetail { OrderHeader = orhs.SingleOrDefault(g => g.OrderDate == new DateTime(2016,10,03,19,30,50)),Product = products.SingleOrDefault(p => p.Name == "Tiger")},
                new OrderDetail { OrderHeader = orhs.SingleOrDefault(g => g.OrderDate == new DateTime(2014,02,13,9,10,10)),Product = products.SingleOrDefault(p => p.Name == "V")},
                new OrderDetail { OrderHeader = orhs.SingleOrDefault(g => g.OrderDate == new DateTime(2016,10,03,19,30,51)),Product = products.SingleOrDefault(p => p.Name == "dish washing")},
                new OrderDetail { OrderHeader = orhs.SingleOrDefault(g => g.OrderDate == new DateTime(2014,02,13,9,10,11)),Product = products.SingleOrDefault(p => p.Name == "coconut")},
                new OrderDetail { OrderHeader = orhs.SingleOrDefault(g => g.OrderDate == new DateTime(2016,10,13,19,30,50)),Product = products.SingleOrDefault(p => p.Name == "eco")},
                new OrderDetail { OrderHeader = orhs.SingleOrDefault(g => g.OrderDate == new DateTime(2014,02,23,19,10,10)),Product = products.SingleOrDefault(p => p.Name == "cola")},
                new OrderDetail { OrderHeader = orhs.SingleOrDefault(g => g.OrderDate == new DateTime(2016,11,23,19,36,50)),Product = products.SingleOrDefault(p => p.Name == "cheese")}
            };

            foreach(var o in ordes)
            {
                context.OrderDetails.Add(o);
            }

            context.SaveChanges();
        }
    }
}
