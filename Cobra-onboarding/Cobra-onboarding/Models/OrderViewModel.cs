using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cobra_onboarding.Models
{
    public class OrderViewModel
    {

        public int OrderId{get;set;}
        public string DateTime{get;set;}
        public PersonViewModel person{get;set;}
        public List<ProductViewModel> products {get; set;}

    }
    public class PersonViewModel
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
    }
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int count { get; set; }
    }
}