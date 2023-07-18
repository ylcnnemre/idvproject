using MediatR;
using Movie.Application.Repositories.movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.Movie.DeleteMovie
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommandRequest, DeleteMovieCommandResponse>
    {
        private readonly IMovieReadRepository movieReadRepository;
        private readonly IMovieWriteRepository movieWriteRepository;
        public DeleteMovieCommandHandler(IMovieReadRepository movieReadRepository, IMovieWriteRepository movieWriteRepository)
        {
            this.movieReadRepository = movieReadRepository;
            this.movieWriteRepository = movieWriteRepository;
        }

        public async Task<DeleteMovieCommandResponse> Handle(DeleteMovieCommandRequest request, CancellationToken cancellationToken)
        {
            var obje = await movieReadRepository.getByIdAsync(request.id);

            if (obje == null)
            {
                return new DeleteMovieCommandResponse
                {
                    Succeeded = false,
                    ErrorMessage = "bulunamadı"
                };

            }

            else
            {
                movieWriteRepository.remove(obje);


                await movieWriteRepository.saveAsync();

                return new DeleteMovieCommandResponse
                {
                    Succeeded = true,
                    DeletedMovieId = obje.Id
                };
            }
        }
    }
}
