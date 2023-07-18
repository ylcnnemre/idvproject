using FluentValidation;
using Movie.Application.Features.Command.User.LoginUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Validator
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommandRequest>
	{
		public LoginUserValidator() {
			RuleFor(x => x.Email).NotEmpty().EmailAddress();
			RuleFor(x => x.Password).NotEmpty();
		}
	}
}
