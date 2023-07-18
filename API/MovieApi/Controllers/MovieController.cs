using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Entities.Identity;
using System.Security.Claims;

namespace MovieApi.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	
	public class MovieController : Controller
	{


		[HttpPost("[action]")]
		[Authorize(AuthenticationSchemes = "Admin" , Roles ="admin" )]
		public IActionResult list()
		{
			
		}

	}
}
