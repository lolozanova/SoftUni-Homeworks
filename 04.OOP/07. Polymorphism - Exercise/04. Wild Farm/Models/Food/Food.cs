using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Food
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get;}

        public override string ToString()
        {
            return base.ToString(); 
        }
    }
}
