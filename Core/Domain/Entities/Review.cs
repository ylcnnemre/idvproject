using Movie.Domain.Entities.Common;
using Movie.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
	public class Review : BaseEntity
	{
		public string Comment { get; set; }

		// A review belongs to a user
		public string UserId { get; set; }
		public AppUser User { get; set; }

		// A review belongs to a film
		public int movieId { get; set; }
		public Movie movie { get; set; }
	}
}
