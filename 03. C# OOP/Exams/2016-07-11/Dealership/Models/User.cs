using System;
using System.Collections.Generic;
using System.Linq;
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

                ValidateStringRange(value, 
                    Constants.MinNameLength, 
                    Constants.MaxNameLength, 
                    string.Format(Constants.StringMustBeBetweenMinAndMax, 
                    "Username", 
                    Constants.MinNameLength.ToString(),
                    Constants.MaxNameLength.ToString()));

                Validator.ValidateSymbols(value, Constants.UsernamePattern, 
                    string.Format(Constants.InvalidSymbols, "Username"));

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

                ValidateStringRange(value,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax,
                    "Firstname",
                    Constants.MinNameLength.ToString(),
                    Constants.MaxNameLength.ToString()));

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

                ValidateStringRange(value,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax,
                    "Lastname",
                    Constants.MinNameLength.ToString(),
                    Constants.MaxNameLength.ToString()));

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

                ValidateStringRange(value,
                    Constants.MinPasswordLength,
                    Constants.MaxPasswordLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax,
                    "Password",
                    Constants.MinPasswordLength.ToString(),
                    Constants.MaxPasswordLength.ToString()));

                Validator.ValidateSymbols(value, Constants.PasswordPattern, 
                    string.Format(Constants.InvalidSymbols, "Password"));

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

            if (this.Role != Role.VIP && this.Vehicles.Count >= 5)
            {
                throw new ArgumentException(string.Format(Constants.NotAnVipUserVehiclesAdd, 5));
            }

            this.Vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("--USER {0}--", this.Username);
            sb.AppendFormat(Environment.NewLine);

            if (!this.Vehicles.Any())
            {
                sb.AppendLine("--NO VEHICLES--");
                return sb.ToString();
            }

            int counter = 1;
            foreach (var vehicle in this.Vehicles)
            {
                sb.AppendFormat("{0}. {1}:", counter, vehicle.Type.ToString());
                sb.Append(Environment.NewLine);
                sb.Append(vehicle.ToString());
                counter++;
            }

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

        public override string ToString()
        {
            return string.Format("Username: {0}, FullName: {1} {2}, Role: {3}", this.Username,
                this.FirstName, this.LastName, this.Role.ToString());
        }
    }
}
