using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using f = Movie.Domain.Entities;
namespace Movie.Application.Repositories.Review
{
	public interface IReviewWriteRepository : IWriteRepositories<f.Review>
	{
	}
}
