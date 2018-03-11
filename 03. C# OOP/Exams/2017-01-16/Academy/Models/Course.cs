using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Academy.Models.Contracts;

namespace Academy.Models
{
    public class Course : ICourse
    {
        private const string NameError = "The name of the course must be between 3 and 45 symbols!";
        private const string LecturesPerWeekError = "The number of lectures per week must be between 1 and 7!";

        private string name;
        private int lecturesPerWeek;
        private DateTime startingDate;
        private DateTime endingDate;

        public Course(string name, int lecturesPerWeek, DateTime startingDate)
        {
            this.Name = name;
            this.LecturesPerWeek = lecturesPerWeek;
            this.StartingDate = startingDate;
            this.EndingDate = this.StartingDate.AddDays(30);

            this.OnsiteStudents = new List<IStudent>();
            this.OnlineStudents = new List<IStudent>();
            this.Lectures = new List<ILecture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NameError);
                }

                if (value.Length < 3 || value.Length > 45)
                {
                    throw new ArgumentOutOfRangeException(NameError);
                }

                this.name = value;
            }
        }

        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }

            private set
            {
                if (value < 1 || value > 7)
                {
                    throw new ArgumentOutOfRangeException(LecturesPerWeekError);
                }

                this.lecturesPerWeek = value;
            }
        }

        public DateTime StartingDate
        {
            get
            {
                return this.startingDate;
            }

            private set
            {
                this.startingDate = value;
            }
        }

        public DateTime EndingDate
        {
            get
            {
                return this.endingDate;
            }

            private set
            {
                this.endingDate = value;
            }
        }

        public IList<IStudent> OnsiteStudents { get; set; }

        public IList<IStudent> OnlineStudents { get; set; }

        public IList<ILecture> Lectures { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("* Course:");
            sb.AppendFormat(" - Name: {0}", this.Name);
            sb.Append(Environment.NewLine);
            sb.AppendFormat(" - Lectures per week: {0}", this.LecturesPerWeek);
            sb.Append(Environment.NewLine);
            sb.AppendFormat(" - Starting date: {0}", this.StartingDate);
            sb.Append(Environment.NewLine);
            sb.AppendFormat(" - Ending date: {0}", this.EndingDate);
            sb.Append(Environment.NewLine);
            sb.AppendFormat(" - Onsite students: {0}", this.OnsiteStudents.Count);
            sb.Append(Environment.NewLine);
            sb.AppendFormat(" - Online students: {0}", this.OnlineStudents.Count);
            sb.Append(Environment.NewLine);
            sb.AppendLine(" - Lectures:");

            if (this.Lectures.Any())
            {
                sb.Append(string.Join(Environment.NewLine, this.Lectures));
            }
            else
            {
                sb.Append("  * There are no lectures in this course!");
            }

            return sb.ToString();
        }
    }
}
