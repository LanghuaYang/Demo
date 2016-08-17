using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Decorator
{
    public class Noodle : Food
    {
        public Noodle() { description = "Noodle"; }
        public override double Cost()
        {
            return 5.0;
        }
    }
}
