using Movie.Domain.Entities.Common;
using Movie.Domain.Entities.Identity;
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

		public List<Review> Reviews { get; set; }


		public List<AppUser> fans { get; set; }

	}
}
