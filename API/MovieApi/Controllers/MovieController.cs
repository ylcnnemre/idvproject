using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Features.Command;
using Movie.Application.Features.Command.Movie.CreateMovie;
using Movie.Application.Features.Command.Movie.DeleteMovie;
using Movie.Domain.Entities.Identity;
using Movie.Persistence.Contexts;
using System.Security.Claims;

namespace MovieApi.Controllers
{
    [ApiController]
	[Route("/api/[controller]")]
	
	public class MovieController : Controller
	{
		private readonly IMediator mediator;

        public MovieController(IMediator mediator )
        {
				this.mediator= mediator;
        }


        [HttpPost("[action]")]
		[Authorize(AuthenticationSchemes = "Admin" , Roles ="admin" )]
		public async Task<IActionResult> create(CreateMovieCommandRequest request)
		{
			CreateMovieCommandResponse response = await mediator.Send(request);

			return Ok(response);
		}

		[HttpPost("[action]/{id}")]
		[Authorize(AuthenticationSchemes = "Admin", Roles = "admin")]
		public async Task<IActionResult> delete([FromRoute] DeleteMovieCommandRequest request)
		{
			var result = await mediator.Send(request);

			return Ok(result);
		}


		
	}
}
