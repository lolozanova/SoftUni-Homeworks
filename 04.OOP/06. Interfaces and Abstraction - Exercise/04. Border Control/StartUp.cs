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

            List<IIdentifiable> allCitizens = new List<IIdentifiable>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] info = input.Split();

                if (info.Length == 3)
                {
                    AddCitizen(allCitizens, info);

                }
                else if (info.Length == 2)
                {
                    AddRobot(allCitizens, info);
                }

                input = Console.ReadLine();
            }

            string fakeIds = Console.ReadLine();

            var fakeCitizens = allCitizens.Where(c => c.Id.EndsWith(fakeIds)).ToList() ;

            foreach (var fake in fakeCitizens)
            {
                Console.WriteLine(fake.Id);
            }
         }

        private static void AddRobot(List<IIdentifiable> allCitizens, string[] info)
        {
            string model = info[0];
            string id = info[1];

            Robot robot = new Robot(model, id);
            allCitizens.Add(robot);
        }

        private static void AddCitizen(List<IIdentifiable> allCitizens, string[] info)
        {


            string name = info[0];
            string age = info[1];
            string id = info[2];

            Citizen citizen = new Citizen(name, age, id);
            allCitizens.Add(citizen);
        }


    }
}

