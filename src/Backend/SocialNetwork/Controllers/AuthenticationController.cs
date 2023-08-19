using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BLL.Data;
using SocialNetwork.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // GET: api/<AuthenticationController>
        [HttpPost]
        public IActionResult RegisterUser(UserRegisterDTO user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.UserEmail) || string.IsNullOrWhiteSpace(user.Password))
            {
                return BadRequest("Invalid request parameters");
                //throw new Exception("Invalid request parameters");
            }
            if (_authenticationService.RegisterUser(user) == false) 
            {
                return StatusCode(409, "A user with the provided email address already exists. Please use a different email or log in to your existing account.");
            }
            return Ok("Your account has been successfully created.");
        }

        [HttpPost]
        [Route("api/login")]
        public string LoginUser(UserDTO user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.UserEmail) || string.IsNullOrWhiteSpace(user.Password))
                throw new Exception("Invalid request parameters");

            return _authenticationService.LoginUser(user);
        }

        [HttpPost]
        [Route("api/logout")]
        public void LogoutUser([FromBody] string jwt)
        {
            if (string.IsNullOrWhiteSpace(jwt))
                throw new Exception("Invalid request parameters");

            _authenticationService.LogoutUser(jwt);
        }
    }
}
