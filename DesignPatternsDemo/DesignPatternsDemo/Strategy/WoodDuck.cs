using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Strategy
{
    public class WoodDuck : Duck
    {
        public WoodDuck()
        {
            base.fly = new FlyNoWay();
            base.quack = new Squeak();
        }
        public override void Display()
        {
            Console.WriteLine("I am wood Duck....");
        }
    }
}
