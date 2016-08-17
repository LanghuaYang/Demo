using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Strategy
{
    public abstract class Duck
    {
        public Ifly fly;
        public Iquack quack;
        public void PerformFly()
        {
            fly.Fly();
        }
        public void PerformQuack()
        {
            quack.quack();
        }
        public abstract void Display();
    }
}
