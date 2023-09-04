using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Data
{
    public class User
    {
       /* public User(User neki) {
            UserId = neki.UserId;
            FirstName = neki.FirstName;
            LastName = neki.LastName;
            UserEmail = neki.UserEmail;
            Username = neki.Username;
            Age = neki.Age;
            Gender = neki.Gender;
            PhoneNumber = neki.PhoneNumber;
            Adress = neki.Adress;
            Password = neki.Password;
        }*/
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public int? Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string? Jwt { get; set; }
        public DateTime? Expiry { get; set; }
    }
}
