using BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace BorderControl.Models
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string name, string age, string id)
        {
          
            this.Name = name;
            this.Age = age;
            this.Id = id;

        }

        public string Id { get; private set; }
        public string Name { get; private set; }

        public string Age { get; private set; }
    }
}
