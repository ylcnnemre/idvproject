using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using f = Movie.Domain.Entities;
namespace Movie.Application.Features.Command.Movie.CreateMovie
{
    public class CreateMovieCommandResponse
    {
        public bool Succeeded { get; set; }
        public f.Movie Movie { get; set; }
        public string ErrorMessage { get; set; }
    }
}
