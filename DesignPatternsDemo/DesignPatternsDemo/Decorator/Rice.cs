using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Decorator
{
    public class Rice:Food
    {
        public Rice() { description = "Rice"; }
        public override double Cost()
        {
            return 3.0;
        }
    }
}
