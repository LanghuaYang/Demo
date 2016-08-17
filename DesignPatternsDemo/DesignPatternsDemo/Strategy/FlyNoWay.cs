using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Strategy
{
    public class FlyNoWay : Ifly
    {
        public void Fly()
        {
            Console.WriteLine("I can't fly....");
        }
    }
}
