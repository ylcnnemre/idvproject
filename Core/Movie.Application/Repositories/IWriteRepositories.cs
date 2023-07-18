using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Repositories
{
	public interface IWriteRepositories<T> where T : class
	{
		Task<bool> addAsync();
		Task<bool> addRangeAsync(List<T> items);
		bool remove(T item);

		Task<bool> removeRangeAsync(int id);

		bool update(T item);
		DbSet<T> table();
		Task<int> saveAsync();

	}
}
