using PursuitPal.Core.Requests;

namespace PursuitPal.Presentation.Api.Validators
{
    public class CreateGoalRequestValidator : BaseValidator<CreateGoalRequest>
    {
        public CreateGoalRequestValidator()
        {
            RuleFor(x => x.Name).ShouldNotBeEmpty();
            RuleFor(x => x.Description).ShouldNotBeEmpty();
            RuleFor(x => x.CompletionCriteria).ShouldNotBeEmpty();
            RuleFor(x => x.FromDate).ShouldNotBeEmpty();
            RuleFor(x => x.ToDate).ShouldNotBeEmpty();
        }
    }
}
