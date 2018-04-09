using System.ComponentModel.DataAnnotations;
using System.Text;

using ProjectManager.Models.Contracts;

namespace ProjectManager.Models
{
    public class User : IUser
    {
        public User(string username, string email)
        {
            this.Username = username;
            this.Email = email;
        }

        [Required(ErrorMessage = "User Username is required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "User Email is required!")]
        [EmailAddress(ErrorMessage = "User Email is not valid!")]
        public string Email { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    Username: " + this.Username);
            sb.AppendLine("    Email: " + this.Email);

            return sb.ToString();
        }
    }
}
