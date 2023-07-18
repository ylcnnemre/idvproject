using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.CreateMovie
{
	public class CreateMovieCommandRequest: IRequest<CreateMovieCommandResponse>
	{
		public string Title { get; set; }
		public string Director { get; set; }
		public string Genre { get; set; }
		public DateTime ReleaseDate { get; set; }
	}
}
