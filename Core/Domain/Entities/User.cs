using Movie.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
	public class User : BaseEntity
	{
		public string username { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public List<Review> Reviews { get; set; }
		public List<Rating> Ratings { get; set; }
		public List<Movie> films { get; set; }	

	}
}
