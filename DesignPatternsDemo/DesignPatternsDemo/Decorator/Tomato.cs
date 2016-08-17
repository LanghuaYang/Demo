using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Decorator
{
    public class Tomato:Ingredient
    {
        Food meal;
        public Tomato(Food meal)
        {
            description = "Tomato";
            this.meal = meal;
        }
        public override double Cost()
        {
            return meal.Cost() + 2.5;
        }
        public override string GetDescription()
        {
            return description + meal.GetDescription();
        }
    }
}
