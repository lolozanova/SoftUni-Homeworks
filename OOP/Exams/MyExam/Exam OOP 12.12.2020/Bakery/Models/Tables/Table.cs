using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        private readonly ICollection<IBakedFood> foodOrders;
        private readonly ICollection<IDrink> drinkOrders;
        

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }

       
        public  int TableNumber { get; }
        public  int Capacity 
        {
            get
            {
                return capacity;
            }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                capacity = value;
            }


        }
        public int NumberOfPeople 
        {
            get
            {
                return numberOfPeople;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                numberOfPeople = value;
            }
        }
        public decimal PricePerPerson { get; }
        public  bool IsReserved { get; private set; }
        public decimal Price => this.NumberOfPeople * this.PricePerPerson;



        public void Clear()
        {
            
           foodOrders.Clear();
           drinkOrders.Clear();
            IsReserved = false;
            this.numberOfPeople = 0;
        }
        public decimal GetBill()
        {
            decimal foodBill = foodOrders.Sum(f => f.Price);
            decimal drinkBill = drinkOrders.Sum(d=>d.Price);

            return foodBill + drinkBill + this.Price;
        }
        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }
        public void OrderFood(IBakedFood food)
        
        {
            foodOrders.Add(food);
        }
        public  void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }
    }
}
