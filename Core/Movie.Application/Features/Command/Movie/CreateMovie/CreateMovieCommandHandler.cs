using MediatR;
using Microsoft.AspNetCore.Identity;
using Movie.Application.Features.Command.User;
using Movie.Application.Repositories.movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.Movie.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommandRequest, CreateMovieCommandResponse>
    {
        private readonly IMovieWriteRepository repository;


        public CreateMovieCommandHandler(IMovieWriteRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            await repository.addAsync(new Domain.Entities.Movie
            {
                Director = request.Director,
                Genre = request.Genre,
                Title = request.Title,
                ReleaseDate = request.ReleaseDate
            });

            await repository.saveAsync();

            return new CreateMovieCommandResponse
            {
                Succeeded = true,
                Movie = new()
                {
                    Director = request.Director,
                    Genre = request.Genre,
                    Title = request.Title,
                    ReleaseDate = request.ReleaseDate
                },
                ErrorMessage = null
            };
        }
    }
}
