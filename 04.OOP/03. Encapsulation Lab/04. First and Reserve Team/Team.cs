using System;
using System.Collections.Generic;
using System.Text;

namespace _04._First_and_Reserve_Team
{
  public  class Team
    {
        private string _name;
        private readonly List<Person> firstTeam;
        private readonly List<Person> secondTeam;

        public Team(string name)
        {
            this._name = name;
            firstTeam = new List<Person>();
            secondTeam = new List<Person>();
        }

        public IReadOnlyCollection<Person> FirstTeam => firstTeam.AsReadOnly();

        public IReadOnlyCollection<Person> ReserveTeam => secondTeam.AsReadOnly();

        public void AddPlayer(Person person)
        {
            if (person.Age <40)
            {
                firstTeam.Add(person);
            }
            else
            {
                secondTeam.Add(person);
            }
        }
    }
}
