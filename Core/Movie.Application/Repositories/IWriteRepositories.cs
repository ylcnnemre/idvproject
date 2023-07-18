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
		DbSet<T> Table { get;}
		Task<bool> addAsync(T model);
		Task<bool> addRangeAsync(List<T> model);
		bool remove(T model);
		Task<bool> removeAsync(int id);
		bool removeRange(List<T> datas);
		bool update(T model);
		Task<int> saveAsync();

	}
}
