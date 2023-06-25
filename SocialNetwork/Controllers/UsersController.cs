using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BLL.Data;
using SocialNetwork.BLL.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController> getAllUsers
        [HttpGet] 
        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _userService.GetUsers();
        }

        // GET api/<UsersController>/5 getSingleUser
        [HttpGet("{id}")]
        public UserDTO Get(Guid id)
        {
            return _userService.GetUser(id);
        }

        // POST api/<UsersController> postUser
        [HttpPost]
        public UserDTO Post(string firstName, string lastName, string userEmail, string username, int age, string gender, string adress, string phoneNumber)
        {
            return _userService.AddUser(firstName,lastName, userEmail, username, age, gender, adress, phoneNumber);
        }

        // PUT api/<UsersController>/5 editUserProfile
        [HttpPut("{id}")]
        public UserDTO? Put(Guid id, string firstName, string lastName, string userEmail, string username, int age, string gender, string adress, string phoneNumber)
        {
            if(_userService.UpdateUser(id, firstName, lastName, userEmail, username, age, gender, adress, phoneNumber) == null)
            {
                throw new Exception();
            }
            return _userService.UpdateUser(id, firstName, lastName, userEmail, username, age, gender, adress, phoneNumber);
        }

        // DELETE api/<UsersController>/5 deleteSingleUser
        [HttpDelete("{id}")]
        public UserDTO? Delete(Guid id)
        {
            if(_userService.RemoveUser(id) == null)
            {
                throw new Exception();
            }
            return _userService.RemoveUser(id);
        }
    }
}
