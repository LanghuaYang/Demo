using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cobra_onboarding.Models
{
    public class OrderDetailViewModel
    {
        public string customerName { get; set; }
        public string date{get;set;}
        //public int OrderCount{get;set;}
        public int ProductCount{get;set;}
        public List<ProductViewModel1> Products { get; set; }
    }
    public class ProductViewModel1
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}