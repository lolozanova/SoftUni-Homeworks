using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine

    {
        private Vehicle car;
        private Vehicle truck;

        public Engine()
        {

        }

        public void Run()
        {
            for (int i = 0; i < 2; i++)
            {
                string[] vehicleArgs = Console.ReadLine().Split();
                string type = vehicleArgs[0];
                double fuel = double.Parse(vehicleArgs[1]);
                double consumption = double.Parse(vehicleArgs[2]);

                if (type == "Car")
                {
                    car = new Car(fuel, consumption);

                }
                else if (type == "Truck")
                {
                    truck = new Truck(fuel, consumption);
                }
            }

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] command = Console.ReadLine().Split();
                string vehicleType = command[1];

                if (command[0] == "Drive")
                {
                    double distance = double.Parse(command[2]);
                    try
                    {
                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(distance));
                        }
                        else if (vehicleType == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message); ;
                    }
                   
                }
                else if (command[0] == "Refuel")
                {
                    double liters = double.Parse(command[2]);

                    if (vehicleType == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

    }
}
