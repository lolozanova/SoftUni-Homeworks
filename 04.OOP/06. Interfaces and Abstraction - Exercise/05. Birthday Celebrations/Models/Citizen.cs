using BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace BorderControl.Models
{
    public class Citizen : IIdentifiable, IBirthdatable
    {
        public Citizen(string name, string age, string id, string birthdate)
        {
          
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;

        }

        public string Id { get; private set; }
        public string Name { get; private set; }

        public string Age { get; private set; }

        public string Birthdate { get; private set; }
    }
}
