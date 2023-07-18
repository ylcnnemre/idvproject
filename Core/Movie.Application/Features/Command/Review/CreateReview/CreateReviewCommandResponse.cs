using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.Review.CreateReview
{
	public class CreateReviewCommandResponse
	{
		public bool Success { get; set; }
		public string Message { get; set; }
	}
}
