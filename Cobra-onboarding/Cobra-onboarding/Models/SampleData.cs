using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Cobra_onboarding.Models
{
    public class SampleData : IDatabaseInitializer<Entities>
    {
        public void InitializeDatabase(Entities context)
        {
            var people = new List<Person>
            {
                new Person { Id = 1,Name = "Math" ,Address1 = "12 preston ave", Address2 = "950a new north road", City = "Auckland"},
                new Person { Id = 2,Name = "English" ,Address1 = "12 preston ave", Address2 = "950a new north road", City = "Auckland"},
                new Person { Id = 3,Name = "IT" ,Address1 = "12 preston ave", Address2 = "950a new north road", City = "Auckland"},
                new Person { Id = 4,Name = "Physics" ,Address1 = "12 preston ave", Address2 = "950a new north road", City = "Auckland"},
                new Person { Id = 5,Name = "Chemistry" ,Address1 = "12 preston ave", Address2 = "950a new north road", City = "Auckland"},
                new Person { Id = 6,Name = "Biology" ,Address1 = "12 preston ave", Address2 = "950a new north road", City = "Auckland"},
            };

            foreach (var p in people)
            {
                context.People.Add(p);
            }

            var orhs = new List<OrderHeader>()
            {
                new OrderHeader { OrderId = 1,OrderDate = new DateTime(2012,02,03,9,40,50), Person = people.Single(g => g.Name == "Math")},
                new OrderHeader { OrderId = 2,OrderDate = new DateTime(2011,11,08,9,50,02), Person = people.Single(g => g.Name == "IT")},
                new OrderHeader { OrderId = 3,OrderDate = new DateTime(2014,02,13,9,10,10), Person = people.Single(g => g.Name == "Biology")},
                new OrderHeader { OrderId = 4,OrderDate = new DateTime(2016,10,03,19,30,50), Person = people.Single(g => g.Name == "Biology")},
                new OrderHeader { OrderId = 5,OrderDate = new DateTime(2014,02,13,9,10,10), Person = people.Single(g => g.Name == "English")},
                new OrderHeader { OrderId = 6,OrderDate = new DateTime(2016,10,03,19,30,50), Person = people.Single(g => g.Name == "Physics")},
                new OrderHeader { OrderId = 7,OrderDate = new DateTime(2014,02,13,9,10,10), Person = people.Single(g => g.Name == "Chemistry")},
                new OrderHeader { OrderId = 8,OrderDate = new DateTime(2016,10,03,19,30,50), Person = people.Single(g => g.Name == "Physics")},
                new OrderHeader { OrderId = 9,OrderDate = new DateTime(2014,02,13,9,10,10), Person = people.Single(g => g.Name == "English")},
                new OrderHeader { OrderId = 10,OrderDate = new DateTime(2016,10,03,19,30,50), Person = people.Single(g => g.Name == "Chemistry")},
            };

            foreach(var o in orhs)
            {
                context.OrderHeaders.Add(o);
            }

            var products = new List<Product>()
            {
                new Product { Id = 1,Name="cola", Price = 2.5},
                new Product { Id = 2,Name="L&P", Price = 3.5},
                new Product { Id = 3,Name="mama", Price = 2.7},
                new Product { Id = 4,Name="Tiger", Price = 4.1},
                new Product { Id = 5,Name="V", Price = 5.5},
                new Product { Id = 6,Name="coconut", Price = 8.0},
                new Product { Id = 7,Name="eco", Price = 7.5},
                new Product { Id = 8,Name="dish washing", Price = 5.5},
                new Product { Id = 9,Name="milk", Price = 2.2},
                new Product { Id = 10,Name="cheese", Price = 12.15},
            };
            foreach(var p in products)
            {
                context.Products.Add(p);
            }

            var ordes = new List<OrderDetail>()
            {
                new OrderDetail { Id = 1,OrderHeader = orhs.Single(g => g.OrderId == 1),Product = products.Single(p => p.Name == "cola")},
                new OrderDetail { Id = 2,OrderHeader = orhs.Single(g => g.OrderId == 2),Product = products.Single(p => p.Name == "L&P")},
                new OrderDetail { Id = 3,OrderHeader = orhs.Single(g => g.OrderId == 3),Product = products.Single(p => p.Name == "mama")},
                new OrderDetail { Id = 4,OrderHeader = orhs.Single(g => g.OrderId == 4),Product = products.Single(p => p.Name == "Tiger")},
                new OrderDetail { Id = 5,OrderHeader = orhs.Single(g => g.OrderId == 5),Product = products.Single(p => p.Name == "V")},
                new OrderDetail { Id = 6,OrderHeader = orhs.Single(g => g.OrderId == 6),Product = products.Single(p => p.Name == "dish washing")},
                new OrderDetail { Id = 7,OrderHeader = orhs.Single(g => g.OrderId == 7),Product = products.Single(p => p.Name == "coconut")},
                new OrderDetail { Id = 8,OrderHeader = orhs.Single(g => g.OrderId == 8),Product = products.Single(p => p.Name == "eco")},
                new OrderDetail { Id = 9,OrderHeader = orhs.Single(g => g.OrderId == 9),Product = products.Single(p => p.Name == "cola")},
                new OrderDetail { Id = 10,OrderHeader = orhs.Single(g => g.OrderId == 10),Product = products.Single(p => p.Name == "cheese")},
            };

            foreach(var o in ordes)
            {
                context.OrderDetails.Add(o);
            }

            context.SaveChanges();
        }
    }
}
