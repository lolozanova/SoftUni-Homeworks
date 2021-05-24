using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Commons;
using WildFarm.Models.Food;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double GainWeight = 0.10;
        private readonly List<string> favoriteFood = new List<string>() { nameof(Vegetable), nameof(Fruit) };
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Squeak";
        }

      public override void Eat(IFood food)
        {
            base.BaseEat( food, favoriteFood, GainWeight);
        }
    }
}
