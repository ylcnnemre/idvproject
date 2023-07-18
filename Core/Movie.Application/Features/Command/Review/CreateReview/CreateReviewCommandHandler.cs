using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Movie.Application.Repositories.Review;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using f = Movie.Domain.Entities;

namespace Movie.Application.Features.Command.Review.CreateReview
{
	public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommandRequest, CreateReviewCommandResponse>
	{

		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly UserManager<AppUser> userManager;
		private readonly IReviewWriteRepository reviewWriteRepository;
		public CreateReviewCommandHandler( IHttpContextAccessor httpContextAccessor,UserManager<AppUser> userManager , IReviewWriteRepository reviewWriteRepository )
		{
			_httpContextAccessor = httpContextAccessor;
			this.userManager= userManager;
			this.reviewWriteRepository = reviewWriteRepository;
		}


		public async Task<CreateReviewCommandResponse> Handle(CreateReviewCommandRequest request, CancellationToken cancellationToken)
		{
			var userEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

            if (userEmail != null) 
            {  
				AppUser selectedUser=await userManager.FindByEmailAsync(userEmail);

				if(selectedUser !=null )
				{
					var review = new f.Review
					{
						Comment = request.Comment,
						UserId = selectedUser.Id,
						movieId = request.movieId
					};

					bool result =	await reviewWriteRepository.addAsync(review);

					await reviewWriteRepository.saveAsync();

					return new CreateReviewCommandResponse
					{
						Success = true,
						Message = "başarılı"
					};
				}
				
            }
			return new CreateReviewCommandResponse {
				Success = false,
				Message = "bir sorun oluştu"
			};

        }
	}
}
