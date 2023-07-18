using Movie.Application.Repositories.movie;
using Movie.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using f = Movie.Domain.Entities;
namespace Movie.Persistence.Repositories.Movie
{
	public class MovieReadRepository : ReadRepository<f.Movie>, IMovieReadRepository
	{
		public MovieReadRepository(MovieContext context) : base(context)
		{
		}
	}
}
