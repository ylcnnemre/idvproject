using Movie.Application.Repositories.Review;
using Movie.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using f = Movie.Domain.Entities;
namespace Movie.Persistence.Repositories.Review
{
	public class ReviewReadRepository : ReadRepository<f.Review>, IReviewReadRepository
	{
		public ReviewReadRepository(MovieContext context) : base(context)
		{
		}
	}
}
