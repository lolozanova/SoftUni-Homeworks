using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double GainWeight = 0.40;
        private List<string> favoriteFood = new List<string>() {nameof(Meat) };
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override void Eat(IFood food)
        {
            base.BaseEat(food, favoriteFood, GainWeight);
        }
    }
}
