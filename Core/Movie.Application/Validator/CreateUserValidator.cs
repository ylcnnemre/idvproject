using FluentValidation;
using Movie.Application.Features.Command.User.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Validator
{
    public class CreateUserValidator:AbstractValidator<CreateUserCommandRequest>
	{
        public CreateUserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().NotNull().WithMessage("kullanıcı adı zorunludur");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("email alanı boş bırakılamaz").EmailAddress().WithMessage("email formatı doğru değil");
			RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Şifre en az 6 karakter uzunluğunda olmalıdır.");
			RuleFor(x => x.Role).NotEmpty().Must(BeValidRole).WithMessage("Geçersiz rol değeri.");
		}

		private bool BeValidRole(string role)
		{
			return role == "standart" || role == "admin";
		}
	}
}
