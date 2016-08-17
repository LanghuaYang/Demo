using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Observer
{
    public abstract class Observer
    {
        public Observer(Subject subject)
        {
            subject.EatHandler += Response;
        }
        public abstract void Response(object sender, EatEventArgs e);
    }
}
