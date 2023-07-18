using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Features.Command.CreateUser;
using Movie.Application.Features.Command.LoginUser;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieApi.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class UserController : Controller
	{
		private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
			this.mediator = mediator;
        }

		[HttpPost("[action]")]
        public async Task<IActionResult> create([FromBody] CreateUserCommandRequest request )
		{
			try
			{
				CreateUserCommandResponse response = 	await	mediator.Send(request);
				return Ok(response);	
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

		[HttpPost("[action]")]
		public async Task<IActionResult> login([FromBody]  LoginUserCommandRequest request )
		{
			var response = await mediator.Send(request);
			if (!response.Succeeded)
			{
				return BadRequest(new { ErrorMessage = response.ErrorMessage });
			}

			return Ok(new { Token = response.Token });


		}



	}
}
