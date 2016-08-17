using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Strategy
{
    public class FlyWithWings:Ifly
    {
        public void Fly()
        {
            Console.WriteLine("I can fly with my wings");
        }
    }
}
