using Microsoft.EntityFrameworkCore;
using Movie.Application.Repositories;
using Movie.Domain.Entities.Common;
using Movie.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Persistence.Repositories
{
	public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
	{

		private readonly MovieContext _context;

		public ReadRepository(MovieContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public IQueryable<T> GetAll()
		{
			var query = Table.AsQueryable();


			return query;
		}


		public async Task<T> getByIdAsync(int id)
		{
	
			var query = Table.AsQueryable();


			return await query.FirstOrDefaultAsync(x => x.Id == id );
		}


		public async Task<T> getSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
		{
			var query = Table.AsQueryable();
			if (!tracking)
			{
				query = Table.AsNoTracking();
			}
			return await query.FirstOrDefaultAsync(method);
		}

		public Task<T> getSingleAsync(Expression<Func<T, bool>> method)
		{
			throw new NotImplementedException();
		}

		public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
		{
			var query = Table.Where(method);

			return query;
		}


	}
}
