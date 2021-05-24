using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double GainWeight = 0.25;
        private readonly List<string> favouriteFood = new List<string>(){nameof(Meat)};
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override void Eat(IFood food)
        {
            base.BaseEat(food, favouriteFood, GainWeight);
        }

       
    }
}
