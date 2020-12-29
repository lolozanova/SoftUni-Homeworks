using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personsInfo = Console.ReadLine().Split(new char[] { ';', '=' });
            string[] productsInfo = Console.ReadLine().Split(new char[] { ';', '=' });

            Person person = null;
            
            List<Person> people = new List<Person>();
            for (int i = 0; i < personsInfo.Length-1; i += 2)
            {
                string personsName = personsInfo[i];
                int money = int.Parse(personsInfo[i + 1]);
                try
                {
                    person = new Person(personsName, money);
                    people.Add(person);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }

            }

            Product product = null;
            List<Product> products = new List<Product>();
            for (int i = 0; i < productsInfo.Length-1; i += 2)
            {
                string productName = productsInfo[i];
                int cost = int.Parse(productsInfo[i + 1]);
                try
                {
                    product = new Product(productName, cost);
                    products.Add(product);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }

            }
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] bought = command.Split();
                string personsName = bought[0];
                string productsName = bought[1];

                Person currPerson = people.FirstOrDefault(x => x.Name == personsName);
                Product currProduct = products.FirstOrDefault(x => x.Name == productsName);
                if (currPerson !=null && currProduct != null)
                {
                    Console.WriteLine(currPerson.AddProduct(currProduct));

                }
            }

            foreach (Person pers in people)
            {
                Console.WriteLine(pers);
            }
        }
    }
}
