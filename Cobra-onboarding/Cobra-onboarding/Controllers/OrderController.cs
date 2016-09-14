using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cobra_onboarding;
using Cobra_onboarding.Models;

namespace Cobra_onboarding.Controllers
{
    public class OrderController : Controller
    {
        private CobraDBContext db = new CobraDBContext();

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllData()
        {
                        //var orders = from o in db.OrderHeaders.Include(o => o.Person)
                        // select new OrderViewModel
                        // {
                        //     OrderId = o.OrderId,
                        //     DateTime = o.OrderDate.ToString(),
                        //     person = new PersonViewModel { PersonId = o.PersonId, Name = o.Person.Name }
                        // };

            var orders = (from o in db.OrderHeaders.Include("OrderDetails")
                            from d in o.OrderDetails
                            select new
                            {
                                order = o,
                                products = d.Product
                            }).GroupBy(x => x.order).Select(x => new OrderViewModel
                            {
                                OrderId = x.Key.OrderId,
                                DateTime = x.Key.OrderDate.ToString(),
                                person = new PersonViewModel { PersonId = x.Key.PersonId, Name = x.Key.Person.Name },
                                //Count = x.Where(g => g.products != null).Distinct().Count()
                                products = x.GroupBy(g => g.products).Select(p => new ProductViewModel
                                {
                                    Id = p.Key.Id,
                                    Name = p.Key.Name,
                                    count = p.Distinct().Count()
                                }).ToList()
                            }).ToList();
            return Json(orders, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCustomerList()
        {
            var Names =  from p in db.People
                         select new PersonViewModel
                         {
                             PersonId = p.Id,
                                Name = p.Name
                          };
            return Json(Names, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProductList()
        {
            var Products = from p in db.Products
                        select new ProductViewModel
                        {
                            Id = p.Id,
                            Name = p.Name,
                            count = 1
                        };
            return Json(Products, JsonRequestBehavior.AllowGet);
        }
        

        // POST: Save New Customer
        [HttpPost]
        public JsonResult Insert(OrderViewModel order)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                var orderHeader = new OrderHeader {
                    OrderDate = DateTime.Parse(order.DateTime),
                    Person = db.People.Single(x => x.Id == order.person.PersonId),
                    PersonId = order.person.PersonId,
                    };

                //also need to save the orderdetails based on the products you choose
                foreach (var p in order.products)
                {
                    OrderDetail od = new OrderDetail
                    {
                        OrderHeader = orderHeader,
                        Product = db.Products.Single(x => x.Name == p.Name)
                    };
                    orderHeader.OrderDetails.Add(od);
                }

                db.OrderHeaders.Add(orderHeader);
                db.SaveChanges();
                return Json(new { success = status });
            }
            return Json(new
            {
                success = false,
                errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
            });
        }

        // POST: Update Existing Customer
        [HttpPost]
        public JsonResult Update(OrderViewModel order)
        {
            bool status = false;
            var orderHeader = db.OrderHeaders.Find(order.OrderId);
            orderHeader.OrderDate = DateTime.Parse(order.DateTime);
            orderHeader.Person = db.People.Find(order.person.PersonId);
            //orderHeader.PersonId = order.person.PersonId;


            //also need to save the orderdetails based on the products you choose
            foreach (var p in order.products)
            {
                OrderDetail od = new OrderDetail
                {
                    OrderHeader = orderHeader,
                    Product = db.Products.SingleOrDefault(x => x.Name == p.Name)
                };
                db.OrderDetails.Add(od);
                orderHeader.OrderDetails.Add(od);
            }

            //also need to save the orderdetails based on the products you choose
            if (ModelState.IsValid)
            {
                db.Entry(orderHeader).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = status });
            }
            return Json(new
            {
                success = false,
                errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
            });
        }

        // DELETE: Delete Customer
        [HttpPost]
        public JsonResult Delete(OrderViewModel order)
        {
            bool status = false;
            if (order == null)
            {
                return Json(new
                {
                    success = status
                });
            }
            OrderHeader orderHeader = db.OrderHeaders.Find(order.OrderId);
            if (orderHeader == null)
            {
                return Json(new
                {
                    success = status
                });
            }

            //remove the orderdetails
            var ods = from o in db.OrderHeaders.Where(x => x.OrderId == order.OrderId)
                      from od in o.OrderDetails
                      select od;
            foreach (var item in ods)
            {
                db.OrderDetails.Remove(item);
            }
            //remove the order
            db.OrderHeaders.Remove(orderHeader);
            db.SaveChanges();
            status = true;
            return Json(new
            {
                success = status
            });
        }

        // GET: Customer/Details/5
        [HttpGet]
        public JsonResult Details(int? id)
        {
            var ordertotal = (from o in db.OrderHeaders.Where(x => x.OrderId == id)
                              select new
                              {
                                  order = o,
                                  orderdetails = o.OrderDetails,
                              }).GroupBy(x => x.order).Select(g => new OrderDetailViewModel
                              ()
                              {
                                  customerName = g.Key.Person.Name,
                                  date = g.Key.OrderDate.ToString(),
                                  ProductCount = g.Key.OrderDetails.Select(S => S.Product.Id).Count(),
                                  Products = g.Key.OrderDetails.Select(x => new ProductViewModel1 { Name = x.Product.Name, Price = x.Product.Price }).ToList(),
                              });
            return Json(ordertotal, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
