using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Academy.Models.Contracts;

namespace Academy.Models
{
    public class Trainer : ITrainer
    {
        private const string UsernameError = "User's username should be between 3 and 16 symbols long!";

        private string username;

        public Trainer(string username, string technologies)
        {
            this.Username = username;
            this.Technologies = new List<string>();

            this.Technologies.Add(technologies);
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(UsernameError);
                }

                if (value.Length < 3 || value.Length > 16)
                {
                    throw new ArgumentOutOfRangeException(UsernameError);
                }

                this.username = value;
            }
        }

        public IList<string> Technologies { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("* Trainer:");
            sb.AppendFormat(" - Username: {0}", this.Username);
            sb.Append(Environment.NewLine);
            sb.Append(" - Technologies: " + string.Join("; ", this.Technologies));

            return sb.ToString(); 
        }
    }
}
