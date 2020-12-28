using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {


        public Person(string firstName , string secondName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = secondName;
            Age = age;
            Salary = salary;
        }
        public string FirstName { get; private set; }

        public string  LastName { get; private set; }

        public int Age { get; private set; }

        public decimal Salary { get; private set; }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age>=30)
            {
                Salary += percentage / 100 * Salary;
            }
            else
            {
                Salary += percentage / 200 * Salary;
            }
          
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}
