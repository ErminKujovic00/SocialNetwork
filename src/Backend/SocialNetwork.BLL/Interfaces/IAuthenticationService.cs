using SocialNetwork.BLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        Boolean RegisterUser(UserRegisterDTO user);
        string LoginUser(UserLoginDTO user /*UserDTO user*/);
        void LogoutUser(string jwt);
    }
}
