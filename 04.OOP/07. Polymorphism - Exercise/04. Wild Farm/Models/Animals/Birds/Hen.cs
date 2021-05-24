using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double GainWeight = 0.35;
        private readonly List<string> favoriteFood = new List<string>() {nameof(Fruit), nameof(Meat), nameof(Seeds), nameof(Vegetable) };

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Cluck";   
        }

        public override void Eat(IFood food)
        {
           base.BaseEat(food, favoriteFood, GainWeight);
        }
    }
}
