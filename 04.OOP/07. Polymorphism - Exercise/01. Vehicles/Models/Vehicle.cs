using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;

namespace Vehicles.Models
{
   public abstract class Vehicle
    {

        public Vehicle(double fuel, double consumption)
        {
            this.Fuel = fuel;
            this.Consumption = consumption;
        }

        public double Fuel { get; protected set;}
        public virtual double  Consumption { get; }


        public  virtual string Drive(double kilometers)
        {
            double consumpForDistance = this.Consumption * kilometers;

            if (this.Fuel <consumpForDistance)
            {
                throw new InvalidOperationException(String.Format(ExceptionMsg.NotEnougnFuel ,this.GetType().Name));
            }

            this.Fuel -= consumpForDistance;
            return $"{this.GetType().Name} travelled {kilometers} km";
           
        }

        public virtual void Refuel(double liters)
        {
            {
                this.Fuel += liters;
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Fuel:f2}";
        }

    }
}
