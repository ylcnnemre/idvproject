using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.Review.UpdateReview
{
	public class UpdateReviewCommandRequest:IRequest<UpdateReviewCommandResponse>
	{
		public string comment { get; set; }
		public int reviewId  {get; set; }
	}
}
