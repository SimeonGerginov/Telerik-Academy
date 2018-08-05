using System;
using System.Collections.Generic;
using System.Linq;

using UnitsOfWork.Common;
using UnitsOfWork.Contracts;
using UnitsOfWork.Models;

namespace UnitsOfWork.Core
{
    public class Engine : IEngine
    {
        private readonly Dictionary<string, Unit> units;
        private readonly SortedSet<Unit> sortedUnits;
        private readonly IWriter writer;

        public Engine(IWriter writer)
        {
            this.units = new Dictionary<string, Unit>();
            this.sortedUnits = new SortedSet<Unit>();
            this.writer = writer;
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

            if (this.units.ContainsKey(name))
            {
                this.writer.AppendLine($"FAIL: {name} already exists!");
            }
            else
            {
                var unit = new Unit(name, type, attack);
                this.units[name] = unit;
                this.sortedUnits.Add(unit);

                this.writer.AppendLine($"SUCCESS: {name} added!");
            }
        }

        private void RemoveUnit(string[] commandParameters)
        {
            var name = commandParameters[0];
            
            if (!this.units.ContainsKey(name))
            {
                this.writer.AppendLine($"FAIL: {name} could not be found!");
            }
            else
            {
                this.sortedUnits.Remove(this.units[name]);
                this.units.Remove(name);

                this.writer.AppendLine($"SUCCESS: {name} removed!");
            }
        }

        private void FindUnits(string[] commandParameters)
        {
            var type = commandParameters[0];

            var foundUnits = this.sortedUnits
                .Where(u => u.Type == type)
                .Take(Constants.UnitsToTake);

            this.writer.AppendLine("RESULT: " + string.Join(", ", foundUnits));
        }

        private void TopUnits(string[] commandParameters)
        {
            var numberOfUnitsToTake = int.Parse(commandParameters[0]);

            var topUnits = this.sortedUnits
                .Take(numberOfUnitsToTake);

            this.writer.AppendLine("RESULT: " + string.Join(", ", topUnits));
        }
    }
}
