using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cobra_onboarding.Models
{
    public class OrderDetailViewModel
    {
        public string customerName { get; set; }
        public DateTime? date{get;set;}
        //public int OrderCount{get;set;}
        public int ProductCount{get;set;}
        public List<Product> Products {get;set;}
    }
}