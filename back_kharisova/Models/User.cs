using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace back_kharisova.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        private byte[] Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

        public string PasswordHash
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var b in MD5.HashData(Password))
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
            set { Password = Encoding.UTF8.GetBytes(value); }
        }

        public bool IsAdmin => Login == "admin";

        public bool CheckPassword(string password) => PasswordHash == password;
        public User() { }
    }
}