using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuel, double consumption) : base(fuel, consumption)
        {
        }

        public override double Consumption => base.Consumption+0.9;

      
    }
}
