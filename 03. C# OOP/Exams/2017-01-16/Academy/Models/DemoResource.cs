namespace Academy.Models
{
    using System;
    using System.Text;

    using Academy.Models.Contracts;

    public class DemoResource : ILectureResource
    {
        private const string NameError = "Resource name should be between 3 and 15 symbols long!";
        private const string UrlError = "Resource url should be between 5 and 150 symbols long!";

        private string name;
        private string url;

        public DemoResource(string name, string url)
        {
            this.Name = name;
            this.Url = url;
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

                if (value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentOutOfRangeException(NameError);
                }

                this.name = value;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(UrlError);
                }

                if (value.Length < 5 || value.Length > 150)
                {
                    throw new ArgumentOutOfRangeException(UrlError);
                }

                this.url = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    * Resource:");
            sb.AppendFormat("     - Name: {0}", this.Name);
            sb.Append(Environment.NewLine);
            sb.AppendFormat("     - Url: {0}", this.Url);
            sb.Append(Environment.NewLine);
            sb.AppendLine("     - Type: Demo");

            return sb.ToString();
        }
    }
}
