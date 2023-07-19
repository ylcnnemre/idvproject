using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities.Identity
{
	public class AppUser : IdentityUser
	{
		public AppUser()
		{
			Reviews = new List<Review>();
			FavoriteMovies = new List<Movie>();
		}


		public ICollection<Review> Reviews { get; set; }
		public ICollection<Movie> FavoriteMovies { get; set; }

	}
}
