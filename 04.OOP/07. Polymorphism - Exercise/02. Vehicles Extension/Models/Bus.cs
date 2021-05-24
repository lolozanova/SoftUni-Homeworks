using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuel, double consumption, double tankCapacity) : base(fuel, consumption, tankCapacity)
        {
        }

        public override double Consumption => base.Consumption;

        public override string Drive(double kilometers)
        {
           
           double consumpForDistance = (this.Consumption + 1.4 )* kilometers ;
            if (this.Fuel < consumpForDistance)
            {
                throw new InvalidOperationException(String.Format(ExceptionMsg.NotEnougnFuel, this.GetType().Name));
            }

            this.Fuel -= consumpForDistance;
            return $"{this.GetType().Name} travelled {kilometers} km";
        }
        public  string DriveEmpty(double kilometers)
        {
            return base.Drive(kilometers);
        }

     
    }
}

