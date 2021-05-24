using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
   public static class AnimalFactory
    {
        public static Animal CreateAnimal(params string[] animalArgs)
        {

            Animal animal = null;
            string type = animalArgs[0];
            string name = animalArgs[1];
            double weight = double.Parse(animalArgs[2]);

            if (type == nameof(Hen))
            {
                double wingSize = double.Parse(animalArgs[3]);

                animal = new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Owl))
            {
                double wingSize = double.Parse(animalArgs[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Dog))
            {
                string livingArea = animalArgs[3];
                animal = new Dog(name, weight, livingArea);
            }
            else if (type == nameof(Mouse))
            {
                string livingArea = animalArgs[3];
                animal = new Mouse(name, weight, livingArea);

            }
            else if (type == nameof(Tiger))
            {
                string livingArea = animalArgs[3];
                string breed = animalArgs[4];

                animal = new Tiger(name, weight, livingArea, breed);


            }
            else if (type == nameof(Cat))
            {
                string livingArea = animalArgs[3];
                string breed = animalArgs[4];

                animal = new Cat(name, weight, livingArea, breed);
            }
            return animal; 
        }
    }
}
