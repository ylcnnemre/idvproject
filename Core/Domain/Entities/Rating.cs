using Movie.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
	public class Rating: BaseEntity
	{
	
		public int Value { get; set; }

		// A rating belongs to a user
		public int UserId { get; set; }
		public User User { get; set; }

		// A rating belongs to a film
		public int FilmId { get; set; }
		public Movie Film { get; set; }

	}
}
