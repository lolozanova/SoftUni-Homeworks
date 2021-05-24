using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double GainWeight = 1.00;
        private readonly List<string> favoriteFood = new List<string>() { nameof(Meat)};
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }

        public override void Eat(IFood food)
        {
            base.BaseEat(food, favoriteFood, GainWeight);
        }
    }
}
