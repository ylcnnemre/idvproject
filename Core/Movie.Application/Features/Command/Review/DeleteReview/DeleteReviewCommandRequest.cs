using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.Review.DeleteReview
{
	public class DeleteReviewCommandRequest : IRequest<DeleteReviewCommandResponse>
	{
		public int id { get; set; }
	}
}
