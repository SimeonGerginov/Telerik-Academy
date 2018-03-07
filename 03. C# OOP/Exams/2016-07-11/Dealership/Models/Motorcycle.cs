using System;

using Dealership.Common;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Motorcycle : IMotorcycle
    {
        private string category;

        public Motorcycle(string category)
        {
            this.Category = category;
        }

        private void ValidateCategoryRange(string value, int min, int max, string message)
        {
            if (value.Length < min || value.Length > max)
            {
                throw new ArgumentException(message);
            }
        }

        public string Category
        {
            get
            {
                return this.category;
            }

            private set
            {
                Validator.ValidateNull(value, Constants.VehicleCannotBeNull);
                this.ValidateCategoryRange(value, Constants.MinCategoryLength, Constants.MaxCategoryLength,
                    Constants.StringMustBeBetweenMinAndMax);

                this.category = value;
            }
        }
    }
}
