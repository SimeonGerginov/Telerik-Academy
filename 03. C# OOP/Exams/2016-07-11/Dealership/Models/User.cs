using System;
using System.Collections.Generic;
using System.Text;
using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class User : IUser
    {
        private const string UsernameError = "Username cannot be null!";
        private const string FirstNameError = "First name cannot be null!";
        private const string LastNameError = "Last name cannot be null!";
        private const string PasswordError = "Password cannot be null!";

        private string username;
        private string firstName;
        private string lastName;
        private string password;
        private Role role;
        private IList<IVehicle> vehicles;

        public User(string username, string firstName, string lastName, string password, Role role)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;
            this.Vehicles = new List<IVehicle>();
        }

        private void ValidateStringRange(string value, int min, int max, string message)
        {
            if (value.Length < min || value.Length > max)
            {
                throw new ArgumentException(message);
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                Validator.ValidateNull(value, UsernameError);
                Validator.ValidateSymbols(value, Constants.UsernamePattern, Constants.InvalidSymbols);

                this.username = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                Validator.ValidateNull(value, FirstNameError);
                ValidateStringRange(value, Constants.MinNameLength, Constants.MaxNameLength,
                    Constants.StringMustBeBetweenMinAndMax);

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                Validator.ValidateNull(value, LastNameError);
                ValidateStringRange(value, Constants.MinNameLength, Constants.MaxNameLength, 
                    Constants.StringMustBeBetweenMinAndMax);

                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            private set
            {
                Validator.ValidateNull(value, PasswordError);
                ValidateStringRange(value, Constants.MinPasswordLength, Constants.MaxPasswordLength,
                    Constants.StringMustBeBetweenMinAndMax);
                Validator.ValidateSymbols(value, Constants.PasswordPattern, Constants.InvalidSymbols);

                this.password = value;
            }
        }

        public Role Role
        {
            get
            {
                return this.role;
            }

            private set
            {
                this.role = value;
            }
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return this.vehicles;
            }

            private set
            {
                this.vehicles = value;
            }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (this.Role == Role.Admin)
            {
                throw new ArgumentException(Constants.AdminCannotAddVehicles);
            }

            if (this.Role != Role.VIP && this.Vehicles.Count > 5)
            {
                throw new ArgumentException(Constants.NotAnVipUserVehiclesAdd);
            }

            this.Vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"Username: {this.Username}," +
                $" FullName: {this.FirstName} {this.LastName}, Role: {Role}");

            return sb.ToString();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (commentToRemove.Author != this.Username)
            {
                throw new ArgumentException(Constants.YouAreNotTheAuthor);
            }

            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.Vehicles.Remove(vehicle);
        }
    }
}
