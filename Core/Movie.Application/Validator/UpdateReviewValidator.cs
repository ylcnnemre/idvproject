using FluentValidation;
using Movie.Application.Features.Command.Review.UpdateReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
