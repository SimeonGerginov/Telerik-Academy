using System;
using System.Text;
using Dealership.Common;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        private const string AuhtorError = "Author cannot be null!";

        private string content;
        private string author;

        public Comment(string content)
        {
            this.Content = content;
        }

        private void ValidateContentRange(string value, int min, int max, string message)
        {
            if (value.Length < min || value.Length > max)
            {
                throw new ArgumentException(message);
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }

            private set
            {
                Validator.ValidateNull(value, Constants.CommentCannotBeNull);

                this.ValidateContentRange(value, 
                    Constants.MinCommentLength, 
                    Constants.MaxCommentLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, 
                    "Content",
                    Constants.MinCommentLength, 
                    Constants.MaxCommentLength));

                this.content = value;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                Validator.ValidateNull(value, AuhtorError);

                this.author = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("    {0}", this.Content);
            sb.Append(Environment.NewLine);
            sb.AppendFormat("      User: {0}", this.Author);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
