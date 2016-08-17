using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Observer
{
    public class Customer:Subject
    {
        public Customer(string foodname)
        {
            base.FoodName = foodname;
        }
        public void OrderMeal()
        {
            Console.WriteLine("Could I have a " + base.FoodName);
            Notify();
        }
    }
}
