using System;
using System.Collections.Generic;
using System.Text;

namespace _04._First_and_Reserve_Team
{
    public class Person
    {
        public Person(string firstName, string secondName, int age)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Age = age;
        }

        public string FirstName { get;}
        public string SecondName { get;}

        public int Age { get; }
    }
}
