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
        private Bus bus;


        public Engine()
        {

        }

        public void Run()
        {
            for (int i = 0; i < 3; i++)
            {
                string[] vehicleArgs = Console.ReadLine().Split();
                string type = vehicleArgs[0];
                double fuel = double.Parse(vehicleArgs[1]);
                double consumption = double.Parse(vehicleArgs[2]);
                double tankCapacity = double.Parse(vehicleArgs[3]);

                if (type == "Car")
                {
                    car = new Car(fuel, consumption, tankCapacity);

                }
                else if (type == "Truck")
                {
                    truck = new Truck(fuel, consumption, tankCapacity);
                }
                else if (type == "Bus")
                {
                    bus = new Bus(fuel, consumption, tankCapacity);
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
                        else if (vehicleType == "Bus")
                        {
                            Console.WriteLine(bus.Drive(distance));
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message); ;
                    }

                }
                else if (command[0] == "DriveEmpty")
                {
                    double distance = double.Parse(command[2]);
                    try
                    {
                        Console.WriteLine(bus.DriveEmpty(distance));

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                }
                else if (command[0] == "Refuel")
                {
                    double liters = double.Parse(command[2]);
                    try
                    {
                        if (vehicleType == "Car")
                        {
                            car.Refuel(liters);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(liters);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(liters);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message); ;
                    }
                   
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

    }
}
