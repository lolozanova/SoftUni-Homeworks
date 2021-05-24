using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double GainWeight = 0.30;
        private readonly List<string> favoriteFood = new List<string> {nameof(Meat), nameof(Vegetable) };
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "Meow";
        }

        public override void Eat(IFood food)
        {
            base.BaseEat(food, favoriteFood, GainWeight);
        }
    }
}
