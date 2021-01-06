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

            List<IBirthdatable> allCitizens = new List<IBirthdatable>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] info = input.Split();
                string creation = info[0];
                if (creation == "Citizen")
                {
                    string name = info[1];
                    string age = info[2];
                    string id = info[3];
                    string birthday = info[4];

                    Citizen citizen = new Citizen(name, age, id, birthday);
                    allCitizens.Add(citizen);

                }
                else if (creation == "Pet")
                {
                    string name = info[1];
                    string birthday = info[2];
                    Pet pet = new Pet(name, birthday);
                    allCitizens.Add(pet);

                }
                else if (creation == "Robot")
                {
                }

                input = Console.ReadLine();
            }

            string birthdayYear = Console.ReadLine();

            var birthdayCitizens = allCitizens.Where(c => c.Birthdate.EndsWith(birthdayYear)).ToList();

            if (birthdayCitizens.Count == 0)
            { 
                return;
            }
            foreach (var citizen in birthdayCitizens)
            {
                Console.WriteLine(citizen.Birthdate);
            }

        }

    }
}


