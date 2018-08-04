using System;
using System.Collections.Generic;
using System.Linq;

using UnitsOfWork.Contracts;

namespace UnitsOfWork
{
    public class Engine : IEngine
    {
        private readonly HashSet<Unit> units;

        public Engine()
        {
            this.units = new HashSet<Unit>();
        }

        public void Start()
        {
            while (true)
            {
                var commandAsString = Console.ReadLine().Split(' ');
                var command = commandAsString[0];
                var commandParameters = commandAsString
                    .Skip(1)
                    .ToArray();

                if (command == Constants.TerminationCommand)
                {
                    break;
                }

                switch (command)
                {
                    case Constants.AddCommand:
                        this.AddUnit(commandParameters);
                        break;
                    case Constants.RemoveCommand:
                        this.RemoveUnit(commandParameters);
                        break;
                    case Constants.FindCommand:
                        this.FindUnits(commandParameters);
                        break;
                    case Constants.PowerCommand:
                        this.TopUnits(commandParameters);
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddUnit(string[] commandParameters)
        {
            var name = commandParameters[0];
            var type = commandParameters[1];
            var attack = int.Parse(commandParameters[2]);

            var unitExists = this.units.FirstOrDefault(u => u.Name == name);

            if (unitExists != null)
            {
                Console.WriteLine($"FAIL: {name} already exists!");
            }
            else
            {
                var unit = new Unit(name, type, attack);
                this.units.Add(unit);
                Console.WriteLine($"SUCCESS: {name} added!");
            }
        }

        private void RemoveUnit(string[] commandParameters)
        {
            var name = commandParameters[0];
            var unit = this.units.FirstOrDefault(u => u.Name == name);

            if (unit == null)
            {
                Console.WriteLine($"FAIL: {name} could not be found!");
            }
            else
            {
                this.units.Remove(unit);
                Console.WriteLine($"SUCCESS: {name} removed!");
            }
        }

        private void FindUnits(string[] commandParameters)
        {
            var type = commandParameters[0];

            var foundUnits = this.units
                .Where(u => u.Type == type)
                .Take(Constants.UnitsToTake)
                .OrderByDescending(u => u.Attack)
                .ThenBy(u => u.Name)
                .ToList();

            Console.WriteLine("RESULT: " + string.Join(", ", foundUnits));
        }

        private void TopUnits(string[] commandParameters)
        {
            var numberOfUnitsToTake = int.Parse(commandParameters[0]);

            var topUnits = this.units
                .OrderByDescending(u => u.Attack)
                .Take(numberOfUnitsToTake)
                .ToList();

            Console.WriteLine("RESULT: " + string.Join(", ", topUnits));
        }
    }
}
