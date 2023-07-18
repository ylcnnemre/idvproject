using MediatR;
using Movie.Application.Repositories.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.Review.DeleteReview
{
	public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommandRequest, DeleteReviewCommandResponse>
	{
		private readonly IReviewWriteRepository writeRepository;
		private readonly IReviewReadRepository readRepository;

        public DeleteReviewCommandHandler(IReviewWriteRepository  writeRepository , IReviewReadRepository readRepository)
        {
				this.writeRepository=writeRepository;
			this.readRepository=readRepository;
        }

        public async Task<DeleteReviewCommandResponse> Handle(DeleteReviewCommandRequest request, CancellationToken cancellationToken)
		{
			var resultObject= await readRepository.getByIdAsync(request.id);

			if (resultObject != null)
			{
				writeRepository.remove(resultObject);

				await writeRepository.saveAsync();

				return new DeleteReviewCommandResponse
				{
					Success = true,
					Message = "başarılı"
				};
			}

			return new DeleteReviewCommandResponse
			{
					Success = false ,
					Message= "böyle bir yorum yok "
			};

		}
	}
}
