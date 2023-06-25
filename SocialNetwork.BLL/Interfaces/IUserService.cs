using SocialNetwork.BLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUsers();

        UserDTO GetUser(Guid id);

        UserDTO AddUser(string firstName, string lastName, string userEmail, string username, int age, string gender, string adress, string phoneNumber); //mozda sve pojedinacno

        UserDTO? UpdateUser(Guid userId, string firstName, string lastName, string userEmail, string username, int age, string gender, string adress, string phoneNumber); //mozda sve pojedinacno

        UserDTO? RemoveUser(Guid id);

    }
}
