using Movie.Application.Repositories.Review;
using Movie.Persistence.Contexts;
using f = Movie.Domain.Entities;

namespace Movie.Persistence.Repositories.Review
{
	public class ReviewWriteRepository : WriteRepository<f.Review>, IReviewWriteRepository
	{
		public ReviewWriteRepository(MovieContext context) : base(context)
		{
		}
	}
}
