using _04._First_and_Reserve_Team;
using System;

namespace PersonsInfo
{
    public class StartUp
    {
  
        static void Main(string[] args)
        {
            Team team = new Team("SoftUni");

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstName = personArgs[0];
                string secondName = personArgs[1];
                int age = int.Parse(personArgs[2]);

                Person person = new Person(firstName, secondName, age);

                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");

        }
    }
}
