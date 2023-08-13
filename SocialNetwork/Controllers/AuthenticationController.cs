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
        public void RegisterUser(UserRegisterDTO user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.UserEmail) || string.IsNullOrWhiteSpace(user.Password))
                throw new Exception("Invalid request parameters");

            _authenticationService.RegisterUser(user);
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
