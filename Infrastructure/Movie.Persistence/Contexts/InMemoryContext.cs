using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Persistence.Contexts
{
	public class InMemoryContext : MovieContext
	{
		IConfiguration configuration;
		public InMemoryContext(IConfiguration configuration) : base(configuration)
		{
			this.configuration=configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseInMemoryDatabase(configuration.GetConnectionString("InMemory"));
		}
	}
}
