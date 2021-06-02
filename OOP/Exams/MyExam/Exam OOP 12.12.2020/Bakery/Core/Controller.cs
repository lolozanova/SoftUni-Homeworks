using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;
        private readonly List<decimal> allBils;


        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
            allBils = new List<decimal>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            Drink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            drinks.Add(drink);

            return String.Format(OutputMessages.DrinkAdded, drink.Name, drink.Brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            BakedFood food = null;

            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }

            bakedFoods.Add(food);
            return String.Format(OutputMessages.FoodAdded, food.Name, food.GetType().Name);

        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            Table table = null;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            tables.Add(table);

            return String.Format(OutputMessages.TableAdded, table.TableNumber);
        }

        public string GetFreeTablesInfo()
        {
            var notReservedtables = tables.Where(t => t.IsReserved == false).ToList();
            StringBuilder sb = new StringBuilder();

            foreach (ITable table in notReservedtables)
            {
                sb.AppendLine(table.GetFreeTableInfo()); ;
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            var sortedTables = tables.Where(t => t.IsReserved == true);
            
          
            return $"Total income: {allBils.Sum():f2}lv";


        }

        public string LeaveTable(int tableNumber)
        {

            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();
          allBils.Add(bill);
            table.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {table.TableNumber}");
            sb.AppendLine($"Bill: { bill:f2}");

            return sb.ToString().TrimEnd();

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table is null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            IDrink drink = drinks.Where(d => d.Name == drinkName).FirstOrDefault(d => d.Brand == drinkBrand);
            if (drink is null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);
            return $"Table {table.TableNumber} ordered {drink.Name} {drink.Brand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table is null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            IBakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);
            if (food is null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);
            return String.Format(OutputMessages.FoodOrderSuccessful, table.TableNumber, food.Name);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.Where(t => t.IsReserved == false).FirstOrDefault(t => t.Capacity >= numberOfPeople);
            if (table is null)
            {
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                table.Reserve(numberOfPeople);
                return String.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            }
        }
    }
}
