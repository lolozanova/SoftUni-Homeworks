using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Factories
{
    public  interface IFood
    {
        public Food CreateFood(int quantity);
    }
}
