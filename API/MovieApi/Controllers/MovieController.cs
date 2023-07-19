using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Application.Features.Command;
using Movie.Application.Features.Command.Movie.AddFans;
using Movie.Application.Features.Command.Movie.CreateMovie;
using Movie.Application.Features.Command.Movie.DeleteMovie;
using Movie.Application.Features.Command.Movie.UpdateMovie;
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
		private readonly MovieContext context;
        public MovieController(IMediator mediator , MovieContext context )
        {
				this.mediator= mediator;
			this.context = context;
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

		[HttpPost("[action]")]
		[Authorize(AuthenticationSchemes = "Admin", Roles = "admin")]
		public async Task<IActionResult> update(UpdateMovieCommandRequest? request )
		{
			var response = await mediator.Send(request);

			if (response.Success)
			{
				return Ok(response);
			}

			return BadRequest(response);
		}


		[HttpGet("[action]")]
		[Authorize(AuthenticationSchemes = "Admin", Roles = "admin,standart")]
		public async Task<IActionResult> getall()
		{
			var result =await context.movie.ToListAsync();

			return Ok(result);
		}

		[HttpPost("[action]")]
		[Authorize(AuthenticationSchemes = "Admin", Roles = "admin")]
		public async Task<IActionResult> addFans(AddFansCommandRequest request)
		{
			var result =	await mediator.Send(request);

			if (result.success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}


	}
}
