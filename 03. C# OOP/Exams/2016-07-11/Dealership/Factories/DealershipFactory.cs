using Dealership.Contracts;
using System;
using Dealership.Models;
using Dealership.Common.Enums;

namespace Dealership.Factories
{
    public class DealershipFactory : IDealershipFactory
    {
        public IVehicle CreateCar(string make, string model, decimal price, int seats)
        {
            // TODO: Implement this
        }

        public IVehicle CreateMotorcycle(string make, string model, decimal price, string category)
        {
            // TODO: Implement this
        }

        public IVehicle CreateTruck(string make, string model, decimal price, int weightCapacity)
        {
            // TODO: Implement this
        }

        public IUser CreateUser(string username, string firstName, string lastName, string password, string role)
        {
            // TODO: Implement this
        }

        public IComment CreateComment(string content)
        {
            // TODO: Implement this
        }
    }
}
