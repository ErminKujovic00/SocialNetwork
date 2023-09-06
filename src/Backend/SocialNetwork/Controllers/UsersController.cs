using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BLL.Data;
using SocialNetwork.BLL.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController> getAllUsers
        [HttpGet]
        [Authorize]
        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _userService.GetUsers();
        }

        // GET api/<UsersController>/5 getSingleUser
        [HttpGet("{id}")]
        [Authorize]
        public UserDTO Get(Guid id)
        {
            return _userService.GetUser(id);
        }

        // POST api/<UsersController> postUser
        /*[HttpPost]
        public UserDTO Post(string firstName, string lastName, string userEmail, string username, string password, int? age, string? gender, string? adress = null, string? phoneNumber = null)
        {
            return _userService.AddUser(firstName,lastName, userEmail, username, age, gender, adress, phoneNumber, password);
        }*/

        [HttpPost]
        //public UserDTO Post(UserSignUpDTO user)
        public IActionResult Post(UserSignUpDTO user)
        {
            UserDTO? userDTO = _userService.AddUser(user.FirstName, user.LastName, user.UserEmail, user.Username, user.Age, user.Gender, user.Adress, user.PhoneNumber, user.Password);
            if(userDTO == null)
            {
                return StatusCode(409, "A user with the provided email address already exists. Please use a different email or log in to your existing account.");
            }
            return Ok(userDTO);
        }

        // PUT api/<UsersController>/5 editUserProfile
        [HttpPut("{id}")]
        [Authorize]
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
        [Authorize]
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
