using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Repositories
{
	public interface IReadRepository<T>
	{
		public IQueryable<T> GetAll();
		IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
		Task<T> getSingleAsync(Expression<Func<T, bool>> method);
		Task<T> getByIdAsync(int id);
	}
}
