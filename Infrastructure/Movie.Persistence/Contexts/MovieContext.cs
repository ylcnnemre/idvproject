using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Identity;


namespace Movie.Persistence.Contexts
{
	public class MovieContext:IdentityDbContext<AppUser,AppRole,string>
	{
		private readonly IConfiguration configuration;

        public MovieContext(IConfiguration configuration)
        {
			this.configuration = configuration;
        }

		public DbSet<Domain.Entities.Movie> movie { get; set; }
		public DbSet<Rating> rating { get; set; }

		public DbSet<Review> review { get; set; }

		public DbSet<User> user { get; set; }	

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseSqlServer(configuration.GetConnectionString("sqlServer"));
		}

	}
}
