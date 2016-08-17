using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Decorator
{
    public abstract class Food
    {
        protected string description = "Unknown food";
        public virtual string GetDescription() { return description; }
        public abstract double Cost();
    }
}
