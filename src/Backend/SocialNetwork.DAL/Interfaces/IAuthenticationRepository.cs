using SocialNetwork.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Interfaces
{
    public interface IAuthenticationRepository
    {
        Boolean RegisterUser(string firstName, string lastName, string email, string username, int age, string gender, string adress, string phoneNumber, byte[] passwordHash, byte[] passwordSalt);
        bool DoesUserExist(string email);
        User? GetUser(string email);
        void InitiateToken(User user, string jwt, DateTime expiry);

        User? GetUserByJwt(string jwt);
        void LogOutUser(User user);
    }
}
