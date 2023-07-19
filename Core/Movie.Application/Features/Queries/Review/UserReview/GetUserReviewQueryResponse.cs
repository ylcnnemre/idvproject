using f= Movie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Queries.Review.UserReview
{
	public class GetUserReviewQueryResponse
	{
		public bool succeded { get; set; }
		public List<f.Review> data { get; set; }
	}
}
