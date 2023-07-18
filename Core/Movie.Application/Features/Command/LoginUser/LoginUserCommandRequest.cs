using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.LoginUser
{
	public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
