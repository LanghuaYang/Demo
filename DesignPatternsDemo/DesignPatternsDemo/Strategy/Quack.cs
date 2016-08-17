using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Strategy
{
    public class Quack:Iquack
    {
        public void quack()
        {
            Console.WriteLine("I can quack gua gua");
        }
    }
}
