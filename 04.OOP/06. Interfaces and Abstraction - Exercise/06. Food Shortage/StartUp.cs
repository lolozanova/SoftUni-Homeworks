using BorderControl.Interfaces;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string [] citizensArg = Console.ReadLine().Split();
                if (citizensArg.Length==4)
                {
                    AddCitizen(buyers, citizensArg);
                }
                else if (citizensArg.Length == 3)
                {
                    AddRebel(buyers,citizensArg);
                }

            }

            string buyersName = Console.ReadLine();
            while (buyersName != "End")
            {
                if (buyers.All(c=>c.Name != buyersName))
                {

                }
                else
                {
                    IBuyer buyer = buyers.FirstOrDefault(c => c.Name == buyersName);
                    buyer.BuyFood();    
                }
              
                
                buyersName = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(c => c.Food));
        }

        private static void AddRebel(List<IBuyer> buyers, string[] citizensArg)
        {
            string name = citizensArg[0];
            int age = int.Parse(citizensArg[1]);
            string group = citizensArg[2];

            Rebel rebel = new Rebel(name, age, group);
            buyers.Add(rebel);
        }

        private static void AddCitizen(List<IBuyer> buyers, string[] citizensArg)
        {
            string name = citizensArg[0];
            string age = citizensArg[1];
            string id = citizensArg[2];
            string birthdate = citizensArg[3];

            Citizen citizen = new Citizen(name, age, id, birthdate);
            buyers.Add(citizen);
        }
    }
}


