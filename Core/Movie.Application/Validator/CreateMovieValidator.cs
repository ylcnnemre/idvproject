using FluentValidation;
using Movie.Application.Features.Command.CreateMovie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Validator
{
	public class CreateMovieValidator : AbstractValidator<CreateMovieCommandRequest>
	{
		public CreateMovieValidator() {
			RuleFor(x => x.Title).NotEmpty();
			RuleFor(x => x.Director).NotEmpty();
			RuleFor(x => x.Genre).NotEmpty();
			RuleFor(x => x.ReleaseDate).NotEmpty();
		}
	}
}
