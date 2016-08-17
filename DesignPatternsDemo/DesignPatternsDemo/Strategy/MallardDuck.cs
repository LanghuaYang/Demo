using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Strategy
{
    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            base.fly = new FlyWithWings();
            base.quack = new Quack();
        }
        public override void Display()
        {
            Console.WriteLine("MallardDuck.....");
        }
    }
}
