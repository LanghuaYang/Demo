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
    public class CustomerController : Controller
    {
        private CobraDBContext db = new CobraDBContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllData()
        {
            //序列化类型为
            //“System.Data.Entity.DynamicProxies.OrderHeader_46903D1AB62AB2D49CE800A1B995BF8A62AD4475430B76E9131CF80246D19F91”
            //的对象时检测到循环引用。
            //for bugfix
            var customers = from c in db.People
                            select new
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Address1 = c.Address1,
                                Address2 = c.Address2,
                                City = c.City
                            };
            return Json(customers, JsonRequestBehavior.AllowGet);
        }

        // GET: Get Single Customer
        [HttpGet]
        public JsonResult GetbyID(int id)
        {
            object customer = db.People.Find(id);
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        // POST: Save New Customer
        [HttpPost]
        public JsonResult Insert(Person person)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                db.People.Add(person);
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
        public JsonResult Update(Person person)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
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
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool status = false;
            Person person = db.People.Find(id);
            //remove the orderdetails
            //remove the orderheader
            db.People.Remove(person);
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
            Person person = db.People.Find(id);
            var ordertotal = ((from o in db.OrderHeaders.Where(x => x.PersonId == id)
                              select new
                              {
                                  order = o,
                                  orderdetails = o.OrderDetails,
                              }).GroupBy(x => x.order).Select(g => new OrderDetailViewModel
                              (){
                                  customerName = person.Name,
                                  date = g.Key.OrderDate,
                                  ProductCount = g.Key.OrderDetails.Select(S => S.Product.Id).Count(),
                                  Products = g.Key.OrderDetails.Select( p => p.Product).ToList(),
                              })).ToList();
            return Json(ordertotal,JsonRequestBehavior.AllowGet);
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
