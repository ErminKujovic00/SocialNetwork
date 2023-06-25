using SocialNetwork.BLL.Data;
using SocialNetwork.BLL.Interfaces;
using SocialNetwork.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNetwork.DAL.Data;

namespace SocialNetwork.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }

        public IEnumerable<UserDTO> GetUsers()
        {
             IEnumerable<User> users = _userRepository.GetAllUser();
             return _mapper.Map<List<UserDTO>>(users);

            /*    List<UserDTO> users = new List<UserDTO>();
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
                return users;*/
        }


        public UserDTO GetUser(Guid id)
        {
            User? user = _userRepository.GetSingleUser(id);
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO AddUser(string firstName, string lastName, string userEmail, string username, int age, string gender, string adress, string phoneNumber)
        {
            User? user = _userRepository.AddNewUser(firstName, lastName, userEmail, username, age, gender, adress, phoneNumber);
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO? UpdateUser(Guid userId, string firstName, string lastName, string userEmail, string username, int age, string gender, string adress, string phoneNumber)
        {
            User? user = _userRepository.UpdateSingleUser(userId, firstName, lastName, userEmail, username, age, gender, adress, phoneNumber);
            return _mapper.Map<UserDTO?>(user);
        }
        public UserDTO? RemoveUser(Guid id)
        {
            User? user = _userRepository.RemoveSingleUser(id);
            return _mapper.Map<UserDTO?>(user);
        }
   
    }
}
