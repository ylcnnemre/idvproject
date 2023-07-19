using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Movie.Application.Repositories.Review;
using Movie.Domain.Entities.Identity;
using f = Movie.Domain.Entities;

namespace Movie.Application.Features.Queries.Review.UserReview
{
	public class GetUserReviewQueryHandler : IRequestHandler<GetuserReviewQueryRequest, GetUserReviewQueryResponse>
	{
		private readonly UserManager<AppUser> userManager;
		private readonly IReviewReadRepository reviewReadRepository;
		public GetUserReviewQueryHandler(UserManager<AppUser> userManager,IReviewReadRepository reviewReadRepository)
		{
			this.userManager = userManager;
			this.reviewReadRepository = reviewReadRepository;
		}

		public async Task<GetUserReviewQueryResponse> Handle(GetuserReviewQueryRequest request, CancellationToken cancellationToken)
		{
			var result = await reviewReadRepository.GetWhere(item => item.UserId == request.userId).ToListAsync();

			if(result !=null)
			{
				return new GetUserReviewQueryResponse
				{
					data = result,
					succeded = true
				};

			}

			return new GetUserReviewQueryResponse
			{
				data = null,
				succeded = false
			};
			

		}
	}
}
