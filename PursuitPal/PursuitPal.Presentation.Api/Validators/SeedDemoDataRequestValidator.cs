using PursuitPal.Core.Requests;
using FluentValidation;

namespace PursuitPal.Presentation.Api.Validators
{
    public class SeedDemoDataRequestValidator : BaseValidator<SeedDemoDataRequest>
    {
        public SeedDemoDataRequestValidator()
        {
            RuleFor(x => x.NumberOfUsers)
                .ShouldNotBeEmpty()
                .GreaterThan(0);

            RuleFor(x => x.NumberOfGoalsPerUser)
                .ShouldNotBeEmpty()
                .GreaterThan(0);
        }
    }
}
