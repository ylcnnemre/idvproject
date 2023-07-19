using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Queries.Review.UserReview
{
	public class GetuserReviewQueryRequest : IRequest<GetUserReviewQueryResponse>
	{
		public string userId { get; set; }

	}
}
