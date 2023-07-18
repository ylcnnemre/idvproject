using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Movie.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Persistence.Contexts;
using Movie.Domain.Entities.Common;

namespace Movie.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepositories<T> where T : BaseEntity
	{
		private readonly MovieContext _context;

		public WriteRepository(MovieContext context)
		{
			_context = context;
		}
		public DbSet<T> Table => _context.Set<T>();


		public async Task<bool> addAsync(T model)
		{
			EntityEntry<T> entityEntry = await Table.AddAsync(model);
			return entityEntry.State == EntityState.Added;
		}

		public async Task<bool> addRangeAsync(List<T> model)
		{
			await Table.AddRangeAsync(model);
			return true;
		}

		public bool remove(T model)
		{
			EntityEntry<T> entityEntry = Table.Remove(model);

			return entityEntry.State == EntityState.Deleted;
		}

		public async Task<bool> removeAsync(int id)
		{
			T model = await Table.FirstOrDefaultAsync(x => x.Id == id  );

			return remove(model);
		}

		public bool update(T model)
		{
			EntityEntry<T> entityEntry = Table.Update(model);
			return entityEntry.State == EntityState.Modified;
		}

		public async Task<int> saveAsync() => await _context.SaveChangesAsync();



		public bool removeRange(List<T> datas)
		{
			Table.RemoveRange(datas);
			return true;
		}
	}
}
