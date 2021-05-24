using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Factories;
using WildFarm.Models.Animals;
using WildFarm.Models.Food;

namespace WildFarm.Core
{
    public class Engine
    {
        private List<Animal> animals;

        public Engine()
        {
            animals = new List<Animal>();
        }
        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string [] animalArgs = input.Split();
                Animal animal =  AnimalFactory.CreateAnimal(animalArgs);

                string[] foodArgs = Console.ReadLine().Split();

                Food food = FoodFactory.CreateFood(foodArgs);

                Console.WriteLine(animal.AskForFood());
                try
                {
                    animal.Eat(food);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message); 
                }

                animals.Add(animal);
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
       
    }
}
