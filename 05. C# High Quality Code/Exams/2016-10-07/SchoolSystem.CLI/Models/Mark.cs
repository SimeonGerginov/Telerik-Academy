using System;

using SchoolSystem.CLI.Constants;
using SchoolSystem.CLI.Enums;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.CLI.Models
{
    public class Mark : IMark
    {
        private float value;
        private Subject subject; 

        public Mark(float value, Subject subject)
        {
            this.Value = value;
            this.Subject = subject;
        }

        public float Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value < GlobalConstants.MinValue || value > GlobalConstants.MaxValue)
                {
                    throw new ArgumentException(GlobalConstants.ValueErrorMessage);
                }

                this.value = value;
            }
        }

        public Subject Subject
        {
            get
            {
                return this.subject;
            }

            set
            {
                this.subject = value;
            }
        }
    }
}
