using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.Movie.AddFans
{
	public class AddFansCommandRequest: IRequest<AddFansCommandResponse>
	{
		public int movieId {  get; set; }
	}
}
