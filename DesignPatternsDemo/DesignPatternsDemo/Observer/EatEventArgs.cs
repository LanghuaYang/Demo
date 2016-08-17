using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Observer
{
    public class EatEventArgs:EventArgs
    {
        public EatEventArgs(string foodname)
        {
            this.FoodName = foodname;
        }
        public string FoodName
        {
            get;
            set;
        }
    }
}
