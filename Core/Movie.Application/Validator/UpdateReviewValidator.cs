using FluentValidation;
using Movie.Application.Features.Command.Review.UpdateReview;


namespace Movie.Application.Validator
{
	public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommandRequest>
	{
        public UpdateReviewValidator()
        {
            RuleFor(x => x.comment).NotEmpty().NotNull();
            RuleFor(x => x.reviewId).NotEmpty().NotNull();
        }
    }
}
