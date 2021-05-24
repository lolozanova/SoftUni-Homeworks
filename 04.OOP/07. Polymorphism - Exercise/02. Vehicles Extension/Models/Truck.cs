using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuel, double consumption, double tankCapacity) : base(fuel, consumption, tankCapacity)
        {
        }

        public override double Consumption { get => base.Consumption + 1.6; }

       

        public override void Refuel(double liters)
        {
            base.Refuel(0.95 * liters);
        }
       
    }
}
