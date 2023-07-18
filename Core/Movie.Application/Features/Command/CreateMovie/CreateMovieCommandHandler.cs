using MediatR;
using Microsoft.AspNetCore.Identity;
using Movie.Application.Features.Command.LoginUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.CreateMovie
{
	public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommandRequest, CreateMovieCommandResponse>
	{
		public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommandRequest request, CancellationToken cancellationToken)
		{
			return new()
			{

			};
		}
	}
}
