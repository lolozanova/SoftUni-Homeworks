using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private ICollection<Product> bag;


        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            bag = new List<Product>();
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public int Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public string AddProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                bag.Add(product);
                this.Money -= product.Cost;
                return $"{this.Name} bought {product.Name}";
            }
            else
            {
              return $"{this.Name} can't afford {product.Name}";
            }
        }
       

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Name} - ");
            if (bag.Count>0)
            {
                sb.AppendLine(String.Join(", ", bag));
            }
            else
            {
                sb.AppendLine("Nothing bought");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
