using System;
using System.Text.RegularExpressions;

using SchoolSystem.CLI.Constants;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.CLI.Models.Abstractions
{
    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(GlobalConstants.NullErrorMessage);
                }

                if (!Regex.Match(value, "^[A-Za-z]+$").Success)
                {
                    throw new ArgumentException(GlobalConstants.NameCharactersErrorMessage);
                }

                if (value.Length < GlobalConstants.MinNameLength || value.Length > GlobalConstants.MaxNameLength)
                {
                    throw new ArgumentException(GlobalConstants.NameErrorMessage);
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(GlobalConstants.NullErrorMessage);
                }

                if (!Regex.Match(value, "^[A-Za-z]+$").Success)
                {
                    throw new ArgumentException(GlobalConstants.NameCharactersErrorMessage);
                }

                if (value.Length < GlobalConstants.MinNameLength || value.Length > GlobalConstants.MaxNameLength)
                {
                    throw new ArgumentException(GlobalConstants.NameErrorMessage);
                }

                this.lastName = value;
            }
        }
    }
}
