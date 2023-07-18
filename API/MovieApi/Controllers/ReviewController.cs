using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Features.Command.Review.CreateReview;
using Movie.Application.Features.Command.Review.DeleteReview;
using Movie.Application.Features.Command.Review.UpdateReview;
using System.Security.Claims;

namespace MovieApi.Controllers
{
	[Authorize(AuthenticationSchemes ="Admin",Roles ="admin,standart")]
	[ApiController]
	[Route("/api/[controller]")]
	
	public class ReviewController : Controller
	{
		private readonly IMediator mediator;

        public ReviewController(IMediator mediator)
        {
				this.mediator= mediator;
        }


        [HttpPost("[action]")]
		public async Task<IActionResult> create(CreateReviewCommandRequest request)
		{
			var result =  await mediator.Send(request);

			return Ok(result);
		}

		[HttpPost ("[action]/{id}")]
		public async Task<IActionResult> delete([FromRoute] DeleteReviewCommandRequest  request )
		{
			var response =	await mediator.Send(request);

			if(response.Success)
			{
				return Ok(response);
			}
			else
			{
				return BadRequest(response);
			}
		}

		[HttpPost("[action]") ]
		public async Task<IActionResult> update( UpdateReviewCommandRequest request )
		{
			var response=	await mediator.Send(request);
			
			if(response.success)
			{
				return Ok(response);
			}
			else
			{
				return BadRequest(response);
			}
		}


	}
}
