using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.Review.CreateReview
{
	public class CreateReviewCommandRequest : IRequest<CreateReviewCommandResponse>
	{
		public string Comment { get; set; }
		public int movieId { get; set; }
	}
}
