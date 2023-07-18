using Movie.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
	public class Movie  : BaseEntity
	{
		public string Title { get; set; }
		public string Director { get; set; }
		public string Genre { get; set; }
		public DateTime ReleaseDate { get; set; }

		// A film can have multiple reviews
		public List<Review> Reviews { get; set; }

		// A film can have multiple ratings
		public List<Rating> Ratings { get; set; }


		public List<User> Users { get; set; }

	}
}
