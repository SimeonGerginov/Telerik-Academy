using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Academy.Models.Contracts;

namespace Academy.Models
{
    public class Lecture : ILecture
    {
        private const string NameError = "Lecture's name should be between 5 and 30 symbols long!";

        private string name;
        private DateTime date;
        private ITrainer trainer;

        public Lecture(string name, DateTime date, ITrainer trainer)
        {
            this.Name = name;
            this.Date = date;
            this.Trainer = trainer;
            this.Resources = new List<ILectureResource>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NameError);
                }

                if (value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentOutOfRangeException(NameError);
                }

                this.name = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                this.date = value;
            }
        }

        public ITrainer Trainer
        {
            get
            {
                return this.trainer;
            }

            set
            {
                this.trainer = value;
            }
        }

        public IList<ILectureResource> Resources { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("  * Lecture:");
            sb.AppendFormat("   - Name: {0}", this.Name);
            sb.Append(Environment.NewLine);
            sb.AppendFormat("   - Date: {0}", this.Date);
            sb.Append(Environment.NewLine);
            sb.AppendFormat("   - Trainer username: {0}", this.Trainer.Username);
            sb.Append(Environment.NewLine);
            sb.AppendLine("   - Resources:");

            if (this.Resources.Any())
            {
                foreach (var resource in this.Resources)
                {
                    sb.Append(resource.ToString());
                }
            }
            else
            {
                sb.Append("    * There are no resources in this lecture.");
            }

            return sb.ToString();
        }
    }
}
