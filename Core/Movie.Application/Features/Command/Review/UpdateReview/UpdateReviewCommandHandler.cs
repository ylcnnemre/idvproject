using MediatR;
using Movie.Application.Repositories.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.Review.UpdateReview
{
	public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommandRequest, UpdateReviewCommandResponse>
	{
		private readonly IReviewReadRepository readRepository;
		private readonly IReviewWriteRepository writeRepository;

		public UpdateReviewCommandHandler(IReviewReadRepository readRepository, IReviewWriteRepository writeRepository)
		{
			this.readRepository = readRepository;
			this.writeRepository = writeRepository;
		}

		public async Task<UpdateReviewCommandResponse> Handle(UpdateReviewCommandRequest request, CancellationToken cancellationToken)
		{
			 var resultObject= await readRepository.getByIdAsync(request.reviewId);

			  if(resultObject != null)
			{
				resultObject.Comment = request.comment;

				await writeRepository.saveAsync();


				return new UpdateReviewCommandResponse
				{
					success = true,
					message = "güncelleme işlemi başarılı"
				};
			}
			return new UpdateReviewCommandResponse
			{
				success = false,
				message = "güncelleme işlemi başarısız"
			};


		}
	}
}
