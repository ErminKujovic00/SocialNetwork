using SocialNetwork.DAL.Data;
using SocialNetwork.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {

        private readonly SocialNetworkDBContext _dbContext;
        public AuthenticationRepository(SocialNetworkDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool DoesUserExist(string email)
        {
            var user = _dbContext.User.FirstOrDefault(x => x.UserEmail == email);
            return user == null;
        }

        public User? GetUser(string email)
        {
            return _dbContext.User.AsQueryable().FirstOrDefault(x => x.UserEmail == email);
        }

        public User? GetUserByJwt(string jwt)
        {
            return _dbContext.User.AsQueryable().FirstOrDefault(x => x.Jwt == jwt);
        }

        public void InitiateToken(User user, string jwt, DateTime expiry)
        {
            user.Jwt = jwt;
            user.Expiry = expiry;
            _dbContext.User.Update(user);
            _dbContext.SaveChanges();
        }

        public void LogOutUser(User user)
        {
            user.Jwt = null;
            user.Expiry = null;
            _dbContext.User.Update(user);
            _dbContext.SaveChanges();
        }

        public Boolean RegisterUser(string firstName, string lastName, string email, string username, int age, string gender, string adress, string phoneNumber, byte[] passwordHash, byte[] passwordSalt)
        {
            User user = new User
            {
                UserEmail = email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                UserId = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Age = age,
                Gender = gender,
                Adress = adress,
                PhoneNumber = phoneNumber
            };

            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
