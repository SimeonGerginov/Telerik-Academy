namespace Academy.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Academy.Models.Contracts;
    using Academy.Models.Enums;
    using Academy.Models.Utils.Contracts;

    public class Student : IStudent
    {
        private const string UsernameError = "User's username should be between 3 and 16 symbols long!";
        private const string TrackError = "The provided track is not valid!";

        private string username;
        private Track track;

        public Student(string username, Track track)
        {
            this.Username = username;
            this.Track = track;
            this.CourseResults = new List<ICourseResult>();
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

        public Track Track
        {
            get
            {
                return this.track;
            }

            private set
            {
                if (!Enum.IsDefined(typeof(Track), value))
                {
                    throw new ArgumentException(TrackError);
                }

                this.track = value;
            }
        }

        public IList<ICourseResult> CourseResults { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("* Student:");
            sb.AppendFormat(" - Username: {0}", this.Username);
            sb.Append(Environment.NewLine);
            sb.AppendFormat(" - Track: {0}", this.Track.ToString());
            sb.Append(Environment.NewLine);
            sb.AppendLine(" - Course results:");

            if (this.CourseResults.Any())
            {
                foreach (var courseResult in this.CourseResults)
                {
                    sb.Append("  " + courseResult.ToString());
                }
            }
            else
            {
                sb.Append("  * User has no course results!");
            }

            sb.Append(Environment.NewLine);

            return sb.ToString(); 
        }
    }
}
