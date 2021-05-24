using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Commons;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get;  protected set ; }
        public double Weight { get; protected set; }
        public int FoodEaten { get ; protected set ; }

        public abstract string AskForFood();

        public abstract void Eat(IFood food);

        protected void BaseEat(IFood food, List<string> favoriteFood, double gainValue)
        {
            string typeFood = food.GetType().Name;

            if (!favoriteFood.Contains(typeFood))
            {
                throw new ArgumentException(String.Format(ExcMsg.WrongFoodType, this.GetType().Name, typeFood));
            }
           
            this.Weight += food.Quantity * gainValue;
            this.FoodEaten += food.Quantity;

        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

       
    }
}
