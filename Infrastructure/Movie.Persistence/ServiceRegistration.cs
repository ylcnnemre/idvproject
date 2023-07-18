using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Movie.Application.Repositories.movie;
using Movie.Application.Repositories.Review;
using Movie.Domain.Entities.Identity;
using Movie.Persistence.Contexts;
using Movie.Persistence.Repositories.Movie;
using Movie.Persistence.Repositories.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Persistence
{
	public static class ServiceRegistration
	{

		public static void AddPersistenceService(this IServiceCollection  services)
		{
			services.AddDbContext<MovieContext>();

			services.AddIdentity<AppUser, AppRole>(options =>
			{
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;

			}).AddEntityFrameworkStores<MovieContext>();
			
			services.AddScoped<IMovieWriteRepository , MovieWriteRepository>();
			services.AddScoped<IMovieReadRepository, MovieReadRepository>();
			services.AddScoped<IReviewWriteRepository, ReviewWriteRepository>();
			services.AddScoped<IReviewReadRepository, ReviewReadRepository>();
		}

	}
}
