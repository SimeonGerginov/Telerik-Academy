﻿using System;

using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Models;

namespace Dealership.Factories
{
    public class DealershipFactory : IDealershipFactory
    {
        public IVehicle CreateCar(string make, string model, decimal price, int seats)
        {
            return new Car(make, model, price, seats);
        }

        public IVehicle CreateMotorcycle(string make, string model, decimal price, string category)
        {
            return new Motorcycle(make, model, price, category);
        }

        public IVehicle CreateTruck(string make, string model, decimal price, int weightCapacity)
        {
            return new Truck(make, model, price, weightCapacity);
        }

        public IUser CreateUser(string username, string firstName, string lastName, string password, string role)
        {
            Role roleAsEnum;
            Enum.TryParse<Role>(role, out roleAsEnum);

            return new User(username, firstName, lastName, password, roleAsEnum);
        }

        public IComment CreateComment(string content)
        {
            return new Comment(content);
        }
    }
}
