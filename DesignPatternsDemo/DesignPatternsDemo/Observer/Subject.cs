using DesignPatternsDemo.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void EatEventHandler(object sender,EatEventArgs e);

namespace DesignPatternsDemo.Observer
{
    public abstract class Subject
    {
        public event EatEventHandler EatHandler;
        public string FoodName { get; set; }
        public void Notify()
        {
            if (EatHandler != null)
            {
                EatHandler(this, new EatEventArgs(FoodName));
            }
        }
    }
}
