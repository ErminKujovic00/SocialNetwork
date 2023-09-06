using SocialNetwork.DAL.Data;
using SocialNetwork.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialNetworkDBContext _dbContext;
        private readonly IAuthenticationRepository _authenticationRepository;

        public UserRepository(SocialNetworkDBContext dbContext, IAuthenticationRepository authenticationRepository)
        {
            _dbContext = dbContext;
            _authenticationRepository = authenticationRepository;
        }

        public IEnumerable<User> GetAllUser()
        {
            return _dbContext.User.AsQueryable();
            
        }

        public User? GetSingleUser(Guid id)
        {
            return _dbContext.User.Where(x => x.UserId == id).FirstOrDefault();
        }

        public User? AddNewUser([Required] string firstName, [Required] string lastName, [Required] string userEmail, [Required] string username, int? age, string? gender, string? adress, string? phoneNumber, [Required] string password)   
        {
            if (!_authenticationRepository.DoesUserExist(userEmail)) return null;// throw new Exception("User already exists");

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            age ??= 0;
            if(gender == null) { gender = "null"; }
            if(adress == null) {  adress = "null"; }
            if(phoneNumber == null) {  phoneNumber = "null"; }

            User newUser = new User
            {
                UserId = new Guid(),
                FirstName = firstName,
                LastName = lastName,
                UserEmail = userEmail,
                Username = username,
                Age = age,
                Gender = gender,
                Adress = adress,
                PhoneNumber = phoneNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _dbContext.User.Add(newUser);
            _dbContext.SaveChanges();
            return newUser;
        }

        public User? UpdateSingleUser(Guid userId, string firstName, string lastName, string userEmail, string username, int age, string gender, string adress, string phoneNumber)
        {
            User? modifiedUser = _dbContext.User.Where(x => x.UserId.Equals(userId)).FirstOrDefault();
            if(modifiedUser != null)
            {
                modifiedUser.FirstName = firstName;
                modifiedUser.LastName = lastName;
                modifiedUser.UserEmail = userEmail;
                modifiedUser.Username = username;
                modifiedUser.Age = age;
                modifiedUser.Gender = gender;
                modifiedUser.Adress = adress;
                modifiedUser.Age = age;
                modifiedUser.PhoneNumber = phoneNumber;
                try
                {
                    _dbContext.SaveChanges();   

                } catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw new Exception();
                }
            }
            return modifiedUser;
        }

        public User? RemoveSingleUser(Guid id)
        {
            User? removeUser = _dbContext.User.Where(x => x.UserId.Equals(id)).FirstOrDefault();
            /*User? a = new User
            {
                FirstName = removeUser.FirstName,
                LastName = removeUser.LastName,
                UserEmail = removeUser.UserEmail,
                Username = removeUser.Username,
                UserId = removeUser.UserId,
                Password = removeUser.Password,
                PhoneNumber = removeUser.PhoneNumber,
                Age = removeUser.Age,
                Gender = removeUser.Gender
            };*/
            if(removeUser != null) { 
                _dbContext.User.Remove(removeUser);
                _dbContext.SaveChanges();
            }

            return removeUser;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            var hmac = new HMACSHA512();

            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var hmac = new HMACSHA512(passwordSalt);

            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);

        }

    }
}
