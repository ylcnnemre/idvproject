using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.CreateMovie
{
	public class CreateMovieCommandResponse
	{
		public int FilmId { get; set; }
		public bool Succeeded { get; set; }
		public string ErrorMessage { get; set; }
	}
}
