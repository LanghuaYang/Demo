using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Observer
{
    public class Cook : Observer
    {
        public Cook(Subject s) : base(s) { }
        public override void Response(object sender, EatEventArgs e)
        {
            Console.WriteLine("Chef: start cooking a " + e.FoodName);
        }
    }
}
