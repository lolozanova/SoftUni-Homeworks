using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuel, double consumption) : base(fuel, consumption)
        {
        }

        public override double Consumption { get => base.Consumption + 1.6; }

       

        public override void Refuel(double liters)
        {
            base.Fuel += 0.95 * liters; //?
        }
       
    }
}
