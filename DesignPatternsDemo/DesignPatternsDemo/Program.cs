using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsDemo.Decorator;
using DesignPatternsDemo.Observer;
using DesignPatternsDemo.Strategy;

namespace DesignPatternsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Food f = new Noodle();
            f = new Tomato(f);
            f = new Egg(f);
            Console.WriteLine(f.GetDescription() +　"一份" +　f.Cost().ToString() + "¥");

            Customer c = new Customer("steak");
            Waiter w = new Waiter(c);
            Cook co = new Cook(c);
            c.OrderMeal();

            MallardDuck md = new MallardDuck();
            WoodDuck wd = new WoodDuck();
            md.Display();
            md.PerformFly();
            md.PerformQuack();
            wd.Display();
            wd.PerformFly();
            wd.PerformQuack();

            Console.Read();
        }
    }
}
