using System;
namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animal = string.Empty; ;
            while ((animal = Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split();

                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];


                switch (animal)
                {
                    case "Cat":
                        Cat cat = new Cat(name, age, gender);
                        Console.WriteLine(cat);
                        break;
                    case "Dog":
                        Dog dog = new Dog(name, age, gender);
                        Console.WriteLine(dog);
                        break;
                    case "Frog":
                        Frog frog = new Frog(name, age, gender);
                        Console.WriteLine(frog);
                        break;

                    case "Kittens":
                        Kitten kitty = new Kitten(name, age);
                        Console.WriteLine(kitty);
                        break;
                    case "Tomcat":
                        Tomcat tom = new Tomcat(name, age);
                        Console.WriteLine(tom);
                        break;
                    default:
                        break;
                }

               
            }

            
        }
    }
}
