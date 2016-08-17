﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Observer
{
    public class Waiter:Observer
    {
        public Waiter(Subject s) : base(s) { }
        public override void Response(object sender, EatEventArgs e)
        {
            Console.WriteLine("waier: please cook a " + e.FoodName);
        }
    }
}
