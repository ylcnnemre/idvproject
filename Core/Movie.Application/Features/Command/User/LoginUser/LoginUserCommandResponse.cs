using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.User.LoginUser
{
    public class LoginUserCommandResponse
    {
        public string Token { get; set; }
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }
    }
}
