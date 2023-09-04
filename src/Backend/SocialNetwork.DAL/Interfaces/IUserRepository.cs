using SocialNetwork.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUser();
        User? GetSingleUser(Guid id);

        User AddNewUser(string firstName, string lastName, string userEmail, string username, int? age, string? gender, string? adress, string? phoneNumber, string password); //mozda sve pojedinacno

        User? UpdateSingleUser(Guid userId, string firstName, string lastName, string userEmail, string username, int age, string gender, string adress, string phoneNumber); //mozda sve pojedinacno

        User? RemoveSingleUser(Guid id);
    }
}
