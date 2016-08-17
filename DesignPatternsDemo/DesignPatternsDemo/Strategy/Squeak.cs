using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Strategy
{
    public class Squeak : Iquack
    {
        public void quack()
        {
            Console.WriteLine("I can quack zhi zhi zhi ");
        }
    }
}
