using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        private double capacity;
        public Vehicle(double fuel, double consumption, double tankCapacity)
        {
            this.Fuel = fuel;
            this.Consumption = consumption;
            this.TankCapacity = tankCapacity;
        }

        public double Fuel { get; protected set; }
        public virtual double Consumption { get; }

        public double TankCapacity
        {
            get
            {
                return capacity;
            }
            private set
            {
                if (this.Fuel > value)
                {
                    this.Fuel = 0;
                }

                capacity = value;
            }

        }

        public virtual string Drive(double kilometers)
        {
            double consumpForDistance = this.Consumption * kilometers;

            if (this.Fuel < consumpForDistance)
            {
                throw new InvalidOperationException(String.Format(ExceptionMsg.NotEnougnFuel, this.GetType().Name));
            }

            this.Fuel -= consumpForDistance;
            return $"{this.GetType().Name} travelled {kilometers} km";

        }

        public virtual void Refuel(double liters)
        {
            if (this.Fuel + liters > this.TankCapacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMsg.WrongAmountFuel, liters));
            }
            if (liters <= 0)
            {
                throw new InvalidOperationException(ExceptionMsg.NegativeAmountFuel);
            }
            this.Fuel += liters;

        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Fuel:f2}";
        }
    
    }
}
