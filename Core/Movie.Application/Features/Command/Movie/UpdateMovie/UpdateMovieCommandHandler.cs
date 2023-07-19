using MediatR;
using Movie.Application.Repositories.movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.Movie.UpdateMovie
{
	public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommandRequest, UpdateMovieCommandResponse>
	{
		private readonly IMovieWriteRepository movieWriteRepository;
		private readonly IMovieReadRepository movieReadRepository;

		public UpdateMovieCommandHandler(IMovieWriteRepository movieWriteRepository, IMovieReadRepository movieReadRepository)
		{
			this.movieWriteRepository = movieWriteRepository;
			this.movieReadRepository = movieReadRepository;
		}

		public async  Task<UpdateMovieCommandResponse> Handle(UpdateMovieCommandRequest request, CancellationToken cancellationToken)
		{
			var movie = await movieReadRepository.getByIdAsync(request.MovieId);

			if (movie == null)
			{
				return new UpdateMovieCommandResponse
				{
					Success = false,
					Message = "Aradığınız film bulunamadı "
				};
			}

			movie.Title = request.Title ?? movie.Title  ;
			movie.Director = request.Director ?? movie.Director ;
			movie.Genre = request.Genre ?? movie.Genre ;
			if (request.ReleaseDate != null)
			{
				movie.ReleaseDate = (DateTime)request.ReleaseDate;
			}

			await movieWriteRepository.saveAsync();

			return new UpdateMovieCommandResponse
			{
				Success = true,
				Message = "Güncelleme işlemi başarılı"
			};
		}
	}
}
