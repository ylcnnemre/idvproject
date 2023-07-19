using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Movie.Application.Repositories.movie;
using Movie.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.Movie.AddFans
{
	public class AddFansCommandHandler : IRequestHandler<AddFansCommandRequest, AddFansCommandResponse>
	{
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly UserManager<AppUser> userManager;
		private readonly IMovieWriteRepository movieWriteRepository;
		private readonly IMovieReadRepository movieReadRepository;
		public AddFansCommandHandler(IHttpContextAccessor httpContextAccessor,UserManager<AppUser> userManager , IMovieWriteRepository movieWriteRepository ,IMovieReadRepository movieReadRepository )
        {
            this.httpContextAccessor= httpContextAccessor;
			this.userManager= userManager;
			this.movieWriteRepository= movieWriteRepository;
			this.movieReadRepository= movieReadRepository;
        }

        public async Task<AddFansCommandResponse> Handle(AddFansCommandRequest request, CancellationToken cancellationToken)
		{
			var userEmail = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

			AppUser selectedUser = await userManager.FindByEmailAsync(userEmail);


			if(selectedUser!= null)
			{
				var selectedMovie  = 	await	movieReadRepository.getByIdAsync(request.movieId);

				selectedMovie.fans.Add(selectedUser);

				await movieWriteRepository.saveAsync();

				return new AddFansCommandResponse()
				{
					success = true ,
					message= "ekleme işlemi başarılı"
				};
			}

			return new AddFansCommandResponse()
			{

				success = false,
				message = "işlem başarısız"
			};

		}
	}
}
