using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Common;
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

		public DbSet<Review> review { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseSqlServer(configuration.GetConnectionString("sqlServer"));
		}


		public override async Task<int> SaveChangesAsync(CancellationToken token = default)
		{
			var datas = ChangeTracker.Entries<BaseEntity>();
			foreach (var data in datas)
			{
				_ = data.State switch
				{
					EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
					EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
					_ => DateTime.UtcNow
				};
			}

			return await base.SaveChangesAsync(token);
		}

	}
}
