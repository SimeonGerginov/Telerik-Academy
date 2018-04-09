using System.ComponentModel.DataAnnotations;
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

        //public override string ToString()
        //{
        //    var b = new StringBuilder();
        //    b.AppendLine("    Username: " + this.UN);
        //    b.AppendLine("    Email: " + this.Email);
        //    return b.ToString();
        //}
    }
}
