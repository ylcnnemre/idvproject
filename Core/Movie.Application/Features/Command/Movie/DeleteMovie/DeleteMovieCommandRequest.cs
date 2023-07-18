using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.Movie.DeleteMovie
{
    public class DeleteMovieCommandRequest : IRequest<DeleteMovieCommandResponse>
    {
        public int id { get; set; }
    }
}
