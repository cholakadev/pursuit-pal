using FluentValidation;
using PursuitPal.Core.Requests;

namespace PursuitPal.Presentation.Api.Validators
{
    public class GetGoalsRequestValidator : BaseValidator<GetGoalsRequest>
    {
        public GetGoalsRequestValidator()
        {
            RuleFor(x => x.Statuses)
                .ShouldNotBeEmpty()
                .IsInEnum();
        }
    }
}
