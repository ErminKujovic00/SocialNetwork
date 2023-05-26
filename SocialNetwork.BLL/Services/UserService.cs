using SocialNetwork.BLL.Data;
using SocialNetwork.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class UserService : IUserService
    {
        IEnumerable<UserDTO> IUserService.GetUsers()
        {
            List<UserDTO> users = new List<UserDTO>();
            users.Add(
                new UserDTO()
                {
                    UserId = new Guid(),
                    FirstName = "Ermin",
                    LastName = "Kujovic",
                    Username = "erkss",
                    UserEmail = "erminkujovic@etf.unsa.ba"
                }
            );
            users.Add(
                new UserDTO()
                {
                    UserId = new Guid(),
                    FirstName = "Brus",
                    LastName = "Wayne",
                    Username = "Batman",
                    UserEmail = "Brus@brus.enterprise.com"
                }
           );
            return users;
        }
    }
}
