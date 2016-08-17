using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Decorator
{
    public class Egg : Ingredient
    {
        Food meal;
        public Egg(Food meal)
        {
            description = "Egg";
            this.meal = meal;
        }
        public override double Cost()
        {
            return meal.Cost() + 4.5;
        }
        public override string GetDescription()
        {
            return description + meal.GetDescription();
        }
    }
}
